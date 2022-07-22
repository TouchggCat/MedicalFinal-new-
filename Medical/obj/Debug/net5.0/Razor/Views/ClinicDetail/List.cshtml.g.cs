#pragma checksum "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c78e3b4fd73e296b51a247fabe8106d36d70b5a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClinicDetail_List), @"mvc.1.0.view", @"/Views/ClinicDetail/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c78e3b4fd73e296b51a247fabe8106d36d70b5a7", @"/Views/ClinicDetail/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24de361111f0b04cb59052ed4f6ecd3219f4a4fd", @"/Views/_ViewImports.cshtml")]
    public class Views_ClinicDetail_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Medical.ViewModel.CClinicDetailViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Hero Start -->
<div class=""container-fluid bg-primary py-5 hero-header mb-5"">
    <div class=""row py-3"">
        <div class=""col-12 text-center"">
            <h3 class=""display-3 text-white animated zoomIn"">即時門診</h3>
        </div>
    </div>
</div>
<!-- Hero End -->

<div style=""display: flex; /* 水平置中*/ justify-content: center; /* 垂直置中 */ align-items: center; flex-wrap: wrap;"">
");
#nullable restore
#line 17 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
       

        foreach (var item in Model)
        {
            if (item.PeriodId == @ViewBag.period) { 


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-3 wow zoomIn"" data-wow-delay=""0.1s"" style=""float: left; border: solid 2px black; margin: 20px; border-radius: 15%; width: 400px; "">
            <div class=""bg-primary d-flex flex-column p-5"" style=""height: 300px; width: auto; border-radius: 15%"">
                <h2>診間:  ");
#nullable restore
#line 25 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                    Write(item.Room.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>

                <div class=""d-flex justify-content-between text-white mb-3"">
                    <h4 class=""text-white mb-3"">
                        醫生姓名:
                    </h4>
                    <p class=""mb-0"">
                        ");
#nullable restore
#line 32 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                   Write(item.Doctor.DoctorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
                <div class=""d-flex justify-content-between text-white mb-3"">
                    <h4 class=""text-white mb-3"">
                        科目:
                    </h4>
                    <p class=""mb-0"">
                        ");
#nullable restore
#line 40 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                   Write(item.Department.DeptName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
                <div class=""d-flex justify-content-between text-white mb-3"">
                    <h4 class=""text-white mb-3"">
                        現在號碼:
                    </h4>
                    <h1 class=""mb-0"" style=""color:red;font-size:larger"">
                        ");
#nullable restore
#line 48 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                   Write(item.Room.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 53 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header border-transparent\">\r\n        <h3 class=\"card-title\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">今日 ");
#nullable restore
#line 61 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                           Write(ViewBag.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 診間</font></font></h3>
    </div>
    <div class=""card-body p-0"">
        <div class=""table-responsive"">
            <table class=""table m-0"">
                <thead>
                    <tr>
                        <th><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">診間編號</font></font></th>
                        <th><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">看診醫師</font></font></th>
                        <th><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">科別</font></font></th>
                        <th><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">狀態</font></font></th>
                        <th><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">現在號碼</font></font></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 76 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                     foreach(var item in Model)
                    {
                        string online = "";
                        if (item.Online == 0)
                        {
                            online = "看診中";
                        }
                        else if (item.Online == 1)
                        {
                            online = "已結束";
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td><a href=\"pages/examples/invoice.html\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">");
#nullable restore
#line 88 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                                                           Write(item.Room.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</font></font></a></td>\r\n                        <td><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">");
#nullable restore
#line 89 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                     Write(item.Doctor.DoctorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</font></font></td>\r\n                        <td>");
#nullable restore
#line 90 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                       Write(item.Department.DeptName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <div class=\"sparkbar\" data-color=\"#00a65a\" data-height=\"20\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">");
#nullable restore
#line 92 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                                                                                 Write(item.Period.PeriodDetail);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ( ");
#nullable restore
#line 92 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                                                                                                             Write(online);

#line default
#line hidden
#nullable disable
            WriteLiteral(" )</font></font></div>\r\n                        </td>\r\n                        <td>\r\n                            <div class=\"sparkbar\" data-color=\"#00a65a\" data-height=\"20\"><font style=\"vertical-align: inherit;\"><font style=\"vertical-align: inherit;\">");
#nullable restore
#line 95 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                                                                                                                                                                 Write(item.Room.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</font></font></div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 98 "C:\Medical0722\Medical\Views\ClinicDetail\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>

    </div>

    <div class=""card-footer clearfix"">
        <a href=""javascript:void(0)"" class=""btn btn-sm btn-info float-left""><font style=""vertical-align: inherit;""><font style=""vertical-align: inherit;"">刷新</font></font></a>
    </div>

</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Medical.ViewModel.CClinicDetailViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
