#pragma checksum "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aa14ec1c9a07f8413409a991de61d0fa5ef6d98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_CheckViewList), @"mvc.1.0.view", @"/Views/Product/CheckViewList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\_ViewImports.cshtml"
using Medical;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\_ViewImports.cshtml"
using Medical.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aa14ec1c9a07f8413409a991de61d0fa5ef6d98", @"/Views/Product/CheckViewList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24de361111f0b04cb59052ed4f6ecd3219f4a4fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_CheckViewList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Medical.ViewModel.CShoppingCartItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Product/ProductList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Product/CartViewList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Product/CheckViewList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("160"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("140"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\" style=\"width: 100%; max-width: 1024px; margin: auto; margin-bottom: 30px;\">\r\n\r\n    <ul class=\"breadcrumb\" style=\"background-color: white; font-size: 16px; margin-top: 30px;\">\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d986120", async() => {
                WriteLiteral("首頁");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d987234", async() => {
                WriteLiteral("產品列表");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d988350", async() => {
                WriteLiteral("我的購物車");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d989467", async() => {
                WriteLiteral("結帳");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
    </ul>

    <div class=""card"" style=""width: 100%;"">
        <div class=""card-header"">1.確認訂單</div>
        <div class=""card-body"">
            <hr>
            <table class=""table"" style=""width: 100%; text-align: center;"">
                <thead>
                    <tr>
                        <th>圖示</th>
                        <th>產品名稱</th>
                        <th>數量</th>
                        <th>單價</th>
                        <th>總價</th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 32 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                      int pay = 0;
                        //decimal tax = 0;
                        foreach (var item in Model)
                        {
                            pay += item.小計;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d9811565", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1487, "~/images/", 1487, 9, true);
#nullable restore
#line 38 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
AddHtmlAttributeValue("", 1496, item.prodspec.ProductImage, 1496, 27, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                <td align=\'center\' valign=\"middle\">");
#nullable restore
#line 39 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                                                              Write(item.prod.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td align=\'center\' valign=\"middle\">");
#nullable restore
#line 40 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                                                              Write(item.cart.ProductAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td align=\'center\' valign=\"middle\">");
#nullable restore
#line 41 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                                                              Write(item.prodspec.UnitPrice.ToString("C0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td align=\'center\' valign=\"middle\">");
#nullable restore
#line 42 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                                                              Write(item.小計.ToString("C0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"

                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </tbody>
            </table>
            <hr>
        </div>
        <div class=""card-footer"" style=""display: flex; flex-direction: row-reverse; align-items: center;"">

            <p>
                <span>訂單總金額:</span>&nbsp;<span style=""font-size: 24px; font-weight: bold; color: rgb(195, 50, 50);"">");
#nullable restore
#line 55 "C:\Users\user\Desktop\期末專題冠名\Medical\Views\Product\CheckViewList.cshtml"
                                                                                                                Write(pay.ToString("C0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </p>\r\n            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n            <select");
            BeginWriteAttribute("name", " name=\"", 2493, "\"", 2500, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2501, "\"", 2506, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d9816048", async() => {
                WriteLiteral("請選擇優惠券");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
        </div>
    </div>

    <br><br>
    <!-- ============================================2================================================ -->


    <div class=""card"" style=""width: 100%;"">
        <div class=""card-header"">2.取貨方式</div>
        <div class=""card-body"">
            <span>收件人 : &nbsp;</span> <input type=""text"" value=""收件人姓名"">
            <hr>
            <div class=""row"">
                <div class=""col-md-6"">


                    <span>選擇取貨方式 : </span> <input type=""radio"" name=""r1""> <span>宅配</span>
                    <br><br>
                    <span>收件地址 :</span>
                    <select");
            BeginWriteAttribute("name", " name=\"", 3219, "\"", 3226, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3227, "\"", 3232, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d9818160", async() => {
                WriteLiteral("請選擇縣市");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                    <br><br>\r\n                    <span>地址:</span> &nbsp; <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 3416, "\"", 3423, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3424, "\"", 3429, 0);
            EndWriteAttribute();
            WriteLiteral(@" value=""請輸入地址"" style=""width: 300px;"">

                </div>
                <div class=""col-md-6"">


                    <input type=""radio"" name=""r1""> <span>超商取貨(7-11)</span>
                    <br><br>
                    <span>收件地址 :</span>
                    <select");
            BeginWriteAttribute("name", " name=\"", 3713, "\"", 3720, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3721, "\"", 3726, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aa14ec1c9a07f8413409a991de61d0fa5ef6d9820261", async() => {
                WriteLiteral("請選擇門市");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                    <br><br>\r\n                    <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 3886, "\"", 3893, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3894, "\"", 3899, 0);
            EndWriteAttribute();
            WriteLiteral(@" value=""超商地址"" style=""width: 300px; color: rgb(139, 140, 140);"" readonly>

                </div>
            </div>

            <hr>

        </div>
        <div class=""card-footer"" style=""height: 70px;"">


        </div>
    </div>

    <br><br>
    <!-- =============================================== 3 =================================================== -->


    <div class=""card"" style=""width: 100%;"">
        <div class=""card-header"">3.付款方式</div>
        <div class=""card-body"">
            <span>選擇付款方式: &nbsp;</span>
            <input type=""radio"" name=""r2""> <span>信用卡</span> &nbsp;
            <input type=""radio"" name=""r2""> <span>貨到付款</span>
            <hr>

            <div>
                <span>信用卡 / 金融卡</span> <br><br>
                <span>卡片詳情</span> <br>
                <input type=""text""");
            BeginWriteAttribute("name", " name=\"", 4741, "\"", 4748, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 4749, "\"", 4754, 0);
            EndWriteAttribute();
            WriteLiteral(" value=\"信用卡號碼\" style=\"width: 500px; color: rgb(139, 140, 140);\"> <br><br>\r\n                <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 4864, "\"", 4871, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 4872, "\"", 4877, 0);
            EndWriteAttribute();
            WriteLiteral(" value=\"到期日(MM/YY)\" style=\"width: 300px; color: rgb(139, 140, 140);\">\r\n                <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 4983, "\"", 4990, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 4991, "\"", 4996, 0);
            EndWriteAttribute();
            WriteLiteral(" value=\"安全驗證碼\" style=\"width: 196px; color: rgb(139, 140, 140);\">\r\n                <br><br>\r\n                <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 5123, "\"", 5130, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 5131, "\"", 5136, 0);
            EndWriteAttribute();
            WriteLiteral(" value=\"持卡者名字\" style=\"width: 500px; color: rgb(139, 140, 140);\">\r\n                <br><br>\r\n                <span>帳單地址</span><br>\r\n                <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 5302, "\"", 5309, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 5310, "\"", 5315, 0);
            EndWriteAttribute();
            WriteLiteral(" value=\"帳單地址\" style=\"width: 500px; color: rgb(139, 140, 140);\"> <br><br>\r\n                <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 5424, "\"", 5431, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 5432, "\"", 5437, 0);
            EndWriteAttribute();
            WriteLiteral(@" value=""郵遞區號"" style=""width: 500px; color: rgb(139, 140, 140);"">
                <br><br>
            </div>
        </div>

        <div class=""card-footer"" style=""height: 70px;"" "" >


        </div>
    </div>

    <br>
    <div style="" text-align: end;"">
        <button type=""button"" class=""btn btn-dark"" style=""margin-top: 10px; margin-right: 20px; width: 200px; border-radius: 25px;"">送出訂單</button>
    </div>


</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Medical.ViewModel.CShoppingCartItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
