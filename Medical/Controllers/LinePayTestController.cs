using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Helpers;
using static Medical.CoreLinePay;
using Newtonsoft.Json;
using System.Text;
using Medical.ViewModel;

namespace Medical.Controllers
{
    public class LinePayTestController : Controller
    {
        public IActionResult test()
        {
            return View();
        }
        //public async Task<IActionResult> OnPostSubmitAsync()
        //{
        //    var result = await RequestLinePayAsync(213);
        //    return Redirect(result.info.paymentUrl.web);
        //}

        public async Task RequestLinePayAsync(int amount)
        {
            using (var httpClient = new HttpClient())
            {
                //Setting
                var channelId = "1657329218";
                var channelSecret = "d5a97c039996d5b4c7dc0b4a3f48b784";
                var baseUri = "https://sandbox-api-pay.line.me";
                var apiUri = "/v3/payments/request";
                string orderId = Guid.NewGuid().ToString();

                //設定 Body
                var requsetBody = new LinePayRequest()
                {
                    amount = amount,
                    currency = "TWD",
                    orderId = Guid.NewGuid().ToString(),
                    redirectUrls = new Redirecturls()
                    {
                        confirmUrl = "https://localhost:44302/LinePayTest/confirm"
                    },
                    packages = new List<Package>()
                    {
                        new Package(){ id="package-1",name = "MedicalLinePay",
                            amount = amount,
                            products = new List<Product2>(){

                                new Product2(){
                                    id = "prod1",
                                    name = "testProd1",
                                    //imageUrl=""
                                    quantity = 1,
                                    price = amount
                                }
                            }
                        }
                    }
                };
                var body = JsonConvert.SerializeObject(requsetBody);
                //加密
                string Signature = HasLinePayRequest(channelSecret,apiUri,body,orderId,channelSecret);

                //設定 Header
                httpClient.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
                httpClient.DefaultRequestHeaders.Add("X-LINE-ChannelSecret", channelSecret);
                httpClient.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", orderId);
                httpClient.DefaultRequestHeaders.Add("X-LINE-Authorization", Signature);

                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(baseUri + apiUri, content);
                var result = await response.Content.ReadAsStringAsync();

                JsonConvert.DeserializeObject<LinePayRequest>(result);
            }

        }


        private static string HasLinePayRequest(string channelSecret, string apiUrl,
            string body, string orderId, string key)
        {
            var request = channelSecret + apiUrl + body + orderId;

            key = key ?? "";

            var encoding = new System.Text.UTF8Encoding();

            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(request);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

                return Convert.ToBase64String(hashmessage);
            }
        }

        [HttpGet("Confirm")]
        public async Task<IActionResult>Confirm([FromQuery] string orderId,[FromQuery]string transactionId)
        {
            return Ok();
        }

        
    }
}
