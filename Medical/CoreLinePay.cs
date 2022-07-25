using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical
{
    public class CoreLinePay
    {
        static void Main(string[] args)
        {
            string channelSecret = "d5a97c039996d5b4c7dc0b4a3f48b784";
            string requestUri = "/v3/payments/request";

            LineForm json = new LineForm
            {
                Amount = 4000,
                Currency = "TWD",
                OrderId = Guid.NewGuid().ToString(),
                Packages = new List<Package>
                {
                    new Package
                    {
                        Id = "2",
                        Amount = 5000,
                        Name = "測試",
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "測試商品",
                                Quantity = 2,
                                Price = 2500
                            }
                        }
                    }
                },
                RedirectUrls = new RedirectUrls
                {
                    ConfirmUrl = "https://6ddcf789.ngrok.io/confitmUrl",
                    CancelUrl = "https://6ddcf789.ngrok.io/cancelUrl"
                }

            };
        }

        public class Product
        {
            public string Name { get; set; }

            public int Quantity { get; set; }

            public int Price { get; set; }
        }

        public class Package
        {
            public string Id { get; set; }

            public int Amount { get; set; }

            public string Name { get; set; }

            public List<Product> Products { get; set; }
        }

        public class RedirectUrls
        {
            public string ConfirmUrl { get; set; }

            public string CancelUrl { get; set; }
        }

        public class LineForm
        {
            //[JsonPropertyName("amount")]
            public int Amount { get; set; }

            //[JsonPropertyName("currency")]
            public string Currency { get; set; }

            //[JsonPropertyName("orderId")]
            public string OrderId { get; set; }

            //[JsonPropertyName("packages")]
            public List<Package> Packages { get; set; }

            //[JsonPropertyName("redirectUrls")]
            public RedirectUrls RedirectUrls { get; set; }
        }
    }
}
