#pragma checksum "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\LK.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58bc3a9d50a3dfac9be7daf4e27fe0deffa8f242"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LK_LK), @"mvc.1.0.view", @"/Views/LK/LK.cshtml")]
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
#line 1 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\_ViewImports.cshtml"
using ArtRoyalDetailing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\_ViewImports.cshtml"
using ArtRoyalDetailing.Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58bc3a9d50a3dfac9be7daf4e27fe0deffa8f242", @"/Views/LK/LK.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    public class Views_LK_LK : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\LK.cshtml"
  
    ViewBag.Title = "Личный кабинет";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br>
<section id=""scrollsection"" onclick=""changeColor()"">
    <div class=""scroll text-scroll"">
        <div>
            •Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет
        </div>
        <div>
            •Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет•Личный кабинет
        </div>
    </div>
</section>
<br />
<br />
<br />
<div class=""row justify-content-center"">
    <div class=""col-xl-auto ml-2"">
        <div class=""menushka"">
            <span id=""menuheader"">
                <ion-icon name=""grid-outline""></ion-icon>
                МЕНЮ
                <ion-icon name=""grid-outline""></ion-icon>
            </span>
            <div>
                <label class=""menuItem"" style=""padding:3px;width: 100%;"">
                    <input type=""radio"" name=""group"" />
                    <div class=""menuItemText"">Мой профиль</div>
                </label>
                <label class=""menuItem"" style=""padding:3px;");
            WriteLiteral(@"width: 100%;"">
                    <input type=""radio"" name=""group"" id=""workers"" onchange=""openWorkersPage()"" />
                    <div class=""menuItemText"">Сотрудники</div>
                </label>
                <label class=""menuItem"" style=""padding:3px;width: 100%;"">
                    <input type=""radio"" name=""group"" />
                    <div class=""menuItemText"">История обслуживания</div>
                </label>
                <label class=""menuItem"" style=""padding:3px;width: 100%;"">
                    <input type=""radio"" id=""salary"" name=""group"" onchange=""openSalaryPage()"" />
                    <div class=""menuItemText"">Зарплата</div>
                </label>
            </div>
        </div>
    </div>
    <div class=""col colForPages"">
");
            WriteLiteral("       \r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"">
    openSalaryPage = () => {
        $('.colForPages').html("""");
        $.ajaxSetup({ cache: false });
        $.get(""/LK/GetSalaryPage"", function (data) {
            $('.colForPages').html(data);
        });
    }
    openWorkersPage = () => {

        $('.colForPages').html("""");
        $.ajaxSetup({ cache: false });
        $.get(""/LK/GetWorkersPage"", function (data) {
            $('.colForPages').html(data);
        });
    }
    document.querySelector('#workers').checked = true
    openWorkersPage()
</script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
