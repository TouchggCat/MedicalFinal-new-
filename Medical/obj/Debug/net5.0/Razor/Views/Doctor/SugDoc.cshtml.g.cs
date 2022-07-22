#pragma checksum "C:\Medical0722\Medical\Views\Doctor\SugDoc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fa6c9482cc70e46c9d91c8a5c2210a5ae8f9387"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_SugDoc), @"mvc.1.0.view", @"/Views/Doctor/SugDoc.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fa6c9482cc70e46c9d91c8a5c2210a5ae8f9387", @"/Views/Doctor/SugDoc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24de361111f0b04cb59052ed4f6ecd3219f4a4fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_SugDoc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("css", async() => {
                WriteLiteral(@"
    <style>
        .dialogue {
            width: 500px;
            padding: 20px;
            box-shadow: 0 0 10px #000;
            background-color: #E0DFC0;
            border-radius: 20px;
        }

        .user {
            display: flex;
            align-items: flex-start;
            margin-bottom: 20px;
        }

            .user .avatar {
                width: 60px;
                text-align: center;
                flex-shrink: 0;
            }

            .user .pic {
                border-radius: 50%;
                overflow: hidden;
            }

                .user .pic .img {
                    width: 100%;
                    vertical-align: middle;
                }

            .user .name {
                color: #333;
            }

            .user .text {
                background-color: #aaa;
                padding: 16px;
                border-radius: 10px;
                position: relative;
            }


        .rem");
                WriteLiteral(@"ote .text {
            margin-left: 20px;
            margin-right: 80px;
            color: #eee;
            background-color: #4179f1;
        }

            .remote .text &::before {
                border-right: 10px solid #4179f1;
                left: -10px;
            }

        .local {
            justify-content: flex-end;
        }

            .local .text {
                margin-right: 20px;
                margin-left: 80px;
                order: -1;
                background-color: #fff;
                color: #333;
            }

                .local .text &::before {
                    border-left: 10px solid #fff;
                    right: -10px;
                }
    </style>
");
            }
            );
            WriteLiteral(@"<!-- Hero Start -->
<div class=""container-fluid bg-primary py-5 hero-header mb-5"">
    <div class=""row py-3"">
        <div class=""col-12 text-center"">
            <h3 class=""display-3 text-white animated zoomIn"">推薦機器人</h3>
        </div>
    </div>
</div>
<!-- Hero End -->
<br>
<div class=""dialogue"">
    <div class=""user remote"">
        <div class=""avatar"">
            <div class=""pic"">
                <img src=""https://picsum.photos/100/100?random=12"" />
            </div>
            <div class=""name"">You</div>
        </div>
        <div class=""text"">
            <input type=""button"" value=""我要掛號"" onclick=""Register()"">
            <input type=""button"" value=""交通指引""");
            BeginWriteAttribute("onclick", " onclick=\"", 2478, "\"", 2488, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <input type=\"button\" value=\"衛教健保\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2537, "\"", 2547, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        </div>
    </div>
    <div class=""user local"">
        <div class=""avatar"">
            <div class=""pic"">
                <img src=""https://picsum.photos/100/100?random=16"" />
            </div>
            <div class=""name"">Me</div>
        </div>
        <div class=""text"">這是我的對話文字</div>        
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function Register() {
            Usertext = `<div class=""avatar"">
            <div class=""pic"">
                <img src=""https://picsum.photos/100/100?random=16"" />
            </div>
            <div class=""name"">Me</div>
        </div>
        <div class=""text"">這是我的對話文字</div>`
            document.querySelector('.local').innerHTML += Usertext;
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
