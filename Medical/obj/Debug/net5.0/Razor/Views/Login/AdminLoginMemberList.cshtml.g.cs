#pragma checksum "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cce3fba5e149c3349902e587f6b393a270e18bdd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_AdminLoginMemberList), @"mvc.1.0.view", @"/Views/Login/AdminLoginMemberList.cshtml")]
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
#line 1 "C:\Medical0722\Medical\Views\_ViewImports.cshtml"
using Medical;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Medical0722\Medical\Views\_ViewImports.cshtml"
using Medical.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cce3fba5e149c3349902e587f6b393a270e18bdd", @"/Views/Login/AdminLoginMemberList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24de361111f0b04cb59052ed4f6ecd3219f4a4fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_AdminLoginMemberList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Medical.Models.Member>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
  
    ViewData["Title"] = "AdminLoginMemberList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>會員資料管理頁面</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cce3fba5e149c3349902e587f6b393a270e18bdd3637", async() => {
                WriteLiteral("新增會員");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                序號\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.IdentityId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.MemberName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.BirthDay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.GenderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 40 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.IcCardNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 55 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.CityId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 67 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
          
            int count = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
             foreach (var item in Model)
            {
                count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 77 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdentityId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 80 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 83 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.MemberName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 86 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.BirthDay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 89 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.GenderId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 98 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IcCardNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 113 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CityId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 119 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 122 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.ActionLink("", "Edit", "Login", new { id = item.MemberId }, new { Class="fas fa-edit" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("  \r\n                        ");
#nullable restore
#line 123 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
                   Write(Html.ActionLink("", "Delete", "Login", new { id = item.MemberId }, new { onclick = "return confirm('確定要刪除資料嗎?')", Class="fas fa-trash" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 126 "C:\Medical0722\Medical\Views\Login\AdminLoginMemberList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Medical.Models.Member>> Html { get; private set; }
    }
}
#pragma warning restore 1591
