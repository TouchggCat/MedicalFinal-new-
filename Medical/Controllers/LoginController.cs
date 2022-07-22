using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class LoginController : Controller
    {
        private readonly MedicalContext _context;

        public LoginController(MedicalContext context)  //注入
        {
            _context = context;
        }
        //======================================================================


        public IActionResult LoginSuccess()
        {
            return View();
        }

        public IActionResult Login(string repath)
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {
                return RedirectToAction("LoginSuccess");   //已登入的證明
            }
           
            if (repath!=null)
            {
                ViewBag.reserve = "reserve";
            }
           
            //ViewData["ReUrl"] = reUrl;
            return View(new CLoginViewModel());

        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel vModel)
        {
            string jasonUser = "";
            //先設定email登入
            //Member mb = (new MedicalContext()).Members.FirstOrDefault(n => n.Email == vModel.txtAccount);
            Member mb = (new MedicalContext()).Members.FirstOrDefault(n => n.Email.Equals(vModel.txtAccount));  //linQ不分大小寫

            if (mb != null)
            {
                if (mb.Email.Equals(vModel.txtAccount) && mb.Password.Equals(vModel.txtPassword)&&vModel.reserve != null && mb.Role == 1)
                {
                    jasonUser = JsonSerializer.Serialize(mb);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USE, jasonUser);
                    //從預約頁面來的
                    return RedirectToAction("ReserveList", "Reserve");
                }

                if (mb.Email.Equals(vModel.txtAccount) && mb.Password.Equals(vModel.txtPassword) && mb.Role == 1)
                {
                    //LogbySession(mb);
                    jasonUser = JsonSerializer.Serialize(mb);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USE, jasonUser);
                    return RedirectToAction("Index", "Home");
                }
                else if (mb.Email.Equals(vModel.txtAccount) && mb.Password.Equals(vModel.txtPassword) && mb.Role == 2)
                {
                    jasonUser = JsonSerializer.Serialize(mb);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USE, jasonUser);
                    return RedirectToAction("List", "Consultation", new { area = "Doctors" });
                }
                else if (mb.Email.Equals(vModel.txtAccount) && mb.Password.Equals(vModel.txtPassword) && mb.Role == 3)
                {
                    jasonUser = JsonSerializer.Serialize(mb);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USE, jasonUser);
                    return RedirectToAction("Index", "Home",new {area="Admin" });
                }
            }
            //TODO 身分別登入不同頁面
            return View();
        }



        public IActionResult Register()
        {
            CMemberViewModel memVModel = new CMemberViewModel()
            {
                mem = _context.Members.ToList(),
                roleTypes = _context.RoleTypes.ToList(),
                MemCity=_context.Cities.ToList(),
                MemGender=_context.Genders.ToList()
            };
            return View(memVModel);
        }

        [HttpPost]
        public IActionResult Register(CMemberViewModel vModel)
        {
            if (vModel.Email != null && vModel.Password!= null)
            {

                sendMail();

                _context.Members.Add(vModel.member);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


        private void sendMail()
        {
          //待寫入內容,註冊成功發送信件
        }

 
        public IActionResult Logout()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {

                HttpContext.Session.Remove(CDictionary.SK_LOGINED_USE);
                    return RedirectToAction("Index", "Home");
        
            }
            return RedirectToAction("Index", "Home");
        }

        //================================================

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPassword(CLoginViewModel vModel)  //參數=>收信者email
        {
            Member member =_context.Members.FirstOrDefault(q => q.Email==vModel.txtAccount);
            if (member != null)
            {
                CMemberViewModel.gmail = vModel.txtAccount;
                string account = "giraffegtest@gmail.com";
                string password = "kusbvagcbkfqcynb";      
                SmtpClient client = new SmtpClient();
                //SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);  //這樣寫也可以，設定google server+port
                client.Host = "smtp.gmail.com"; //設定google server
                client.Port = 587;              //google port
                client.Credentials = new NetworkCredential(account, password);  //寄信人，內容寫在上方方便修改  //credential (n.)憑據；證書

                client.EnableSsl = true;           //是否啟用SSL驗證  =>SSL憑證是在網頁伺服器(主機)與網頁瀏覽器(客戶端)之間建立一個密碼連結的標準規範

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(account, "漢斯眼科");   //前面是發信email後面是顯示的名稱
                mail.To.Add(vModel.txtAccount);  //收信者email from 參數
                mail.Subject = "[漢斯眼科]一密碼重設通知信";  //標題
                mail.SubjectEncoding = System.Text.Encoding.UTF8;   //標題使用UTF8編碼
                mail.IsBodyHtml = true;   //內容使用html
                mail.Body = $"<h1>漢斯眼科會員一{member.MemberName}，您好:</h1><br><h2>如欲重新設定密碼<a href='https://localhost:44302/Login/ResetPassword?email={vModel.txtAccount}'>請點我</a></h2>";
                mail.BodyEncoding = System.Text.Encoding.UTF8;       //內文使用UTF8編碼
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    mail.Dispose();
                    client.Dispose();//釋放資源
                }
                return Content("<script>alert('信件已送出，請至信箱查看');window.location.href='https://localhost:44302/'</script>", "text/html", System.Text.Encoding.UTF8);
                //window.location.href跳轉業面
            }
            else
                return Content("<script>alert('未註冊的帳號，請確認輸入是否正確');window.location.href='https://localhost:44302/'</script>", "text/html", System.Text.Encoding.UTF8);

        }

        public IActionResult ResetPassword(string email)
        {
            //把忘記密碼輸入的信箱傳入參數
            CLoginViewModel LogVM = new CLoginViewModel();
            Member mem = new Member();
            mem= _context.Members.Where(n => n.Email == email).FirstOrDefault();
            LogVM.txtAccount = mem.Email;

            return View(LogVM);
        }
        [HttpPost]
        public IActionResult ResetPassword(CLoginViewModel LogVM)
        {
            if (LogVM != null)
            {
                Member mem = _context.Members.Where(n => n.Email == LogVM.txtAccount).FirstOrDefault();
                mem.Password = LogVM.txtPassword;
                _context.SaveChanges();
                return Content("<script>alert('修改密碼成功');window.location.href='https://localhost:44302/';</script>", "text/html", System.Text.Encoding.UTF8);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
