#pragma checksum "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6f6d495dd96eb9200fbceb9cc3f6597d0f13643"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LK_PartialWorkersPage), @"mvc.1.0.view", @"/Views/LK/PartialWorkersPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6f6d495dd96eb9200fbceb9cc3f6597d0f13643", @"/Views/LK/PartialWorkersPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    public class Views_LK_PartialWorkersPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml"
  
    Layout = null;
    ViewBag.Title = "Сотрудники";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""workersContainer"">
    <label class=""point"">
        <input type=""radio"" id=""addWorker"" onchange=""workerAddShow(this.checked)"" name=""groupWorkers"" />
        <div class=""pText""><div>⮟</div> Добавить нового сотрудника <div>⮟</div></div>
    </label>
    <div class=""formAddWorker"">
        <table class=""table table-borderless"" id=""tbWorker"">
            <tbody>
                <tr>
                    <td class=""col-1"">Имя</td>
                    <td class=""col-4""><input type=""text"" class=""inputSelectBox"" id=""userName"" placeholder=""Введите имя"" /></td>
                </tr>
                <tr>
                    <td>Фамилия</td>
                    <td><input type=""text"" class=""inputSelectBox"" id=""userSurname"" placeholder=""Введите фамилию"" /></td>
                </tr>
                <tr>
                    <td>Номер телефона</td>
                    <td><input type=""text"" class=""inputSelectBox tel"" id=""userPhone"" onfocus=""maskValid(this)"" placeholder=""Введите номер телефона");
            WriteLiteral("\" /></td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Роль</td>\r\n                    <td>\r\n                        <select type=\"text\" class=\"inputSelectBox\" id=\"userRole\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6f6d495dd96eb9200fbceb9cc3f6597d0f136435110", async() => {
                WriteLiteral("Выберите роль");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml"
                             foreach (var role in (List<Roles>)ViewBag.Roles)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6f6d495dd96eb9200fbceb9cc3f6597d0f136437259", async() => {
#nullable restore
#line 34 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml"
                                                        Write(role.RoleName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml"
                                   WriteLiteral(role.RoleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialWorkersPage.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Логин</td>
                    <td><input type=""text"" class=""inputSelectBox"" id=""userLogin"" placeholder=""Введите логин"" /></td>
                </tr>
                <tr>
                    <td>Пароль</td>
                    <td><input type=""text"" class=""inputSelectBox"" id=""userPassword"" placeholder=""Введите пароль"" /></td>
                </tr>
                <tr>
                    <td>Электронная почта</td>
                    <td><input type=""text"" class=""inputSelectBox"" id=""userEmail"" placeholder=""Введите почту"" /></td>
                </tr>
            </tbody>
        </table>
        <button onclick=""addWorker(this)"">Добавить</button>
    </div>
    <label class=""point"">
        <input type=""radio"" name=""groupWorkers"" onchange=""workerListShow(this.checked)"" />
        <div class=""pText""><div>⮟</div> Список сотрудников <div>⮟</div></div>
    </label>
");
            WriteLiteral(@"    <div class=""formWorkerList"">
        
    </div>
</div>


<script>
    workerAddShow = (value) => {
        if (value == true) {
            workerListShow(false)
        }
        let elem = document.querySelector("".formAddWorker"")
        elem.style.animation = value ? ""fadein 1s forwards"" : ""fadeout 1s forwards""
        elem.style.height = value ? ""100%"" : ""0px""
    }
    addWorker = (el) => {
        let table = document.querySelector('#tbWorker')
        let userName = table.querySelector('#userName').value
        let userSurname = table.querySelector('#userSurname').value
        let userPhone = table.querySelector('#userPhone').value
        let userLogin = table.querySelector('#userLogin').value
        let userPassword = table.querySelector('#userPassword').value
        let userEmail = table.querySelector('#userEmail').value
        let userRole = table.querySelector('#userRole').value
        if (userName == """" || userSurname == """" ||
            userPhone == """" || use");
            WriteLiteral(@"rLogin == """" ||
            userPassword == """" || userEmail == """" ||
            userRole == """") {
            createAlert(""Ошибка"", ""Заполните все поля"", ""error"")
            return;
        }
        if (userPhone.length != 17) {
            createAlert(""Ошибка"", ""Дозаполните номер телефона"", ""error"")
            return;
        }

    }
    workerListShow = (value) => {
        if (value == true) {
            workerAddShow(false)
            $.ajaxSetup({ cache: false });
            $.get(""/LK/GetWorkersTable"", function (data) {
                $('.formWorkerList').html(data);
            });
        }
        let elem = document.querySelector("".formWorkerList"")
        elem.style.animation = value ? ""fadein 1s forwards"" : ""fadeout 1s forwards""
        elem.style.height = value ? ""100%"" : ""0px""
        if(value==false)
            $('.formWorkerList').html("""");
    }

    maskValid = (input) => {
            var keyCode;
            function mask(event) {
                eve");
            WriteLiteral(@"nt.keyCode && (keyCode = event.keyCode);
                var pos = this.selectionStart;
                if (pos < 3) event.preventDefault();
                var matrix = ""+7 (___) ___-____"",
                    i = 0,
                    def = matrix.replace(/\D/g, """"),
                    val = this.value.replace(/\D/g, """"),
                    new_value = matrix.replace(/[_\d]/g, function (a) {
                        return i < val.length ? val.charAt(i++) || def.charAt(i) : a
                    });
                i = new_value.indexOf(""_"");
                if (i != -1) {
                    i < 5 && (i = 3);
                    new_value = new_value.slice(0, i)
                }
                var reg = matrix.substr(0, this.value.length).replace(/_+/g,
                    function (a) {
                        return ""\\d{1,"" + a.length + ""}""
                    }).replace(/[+()]/g, ""\\$&"");
                reg = new RegExp(""^"" + reg + ""$"");
                if (!reg.test(this.value");
            WriteLiteral(@") || this.value.length < 5 || keyCode > 47 && keyCode < 58) this.value = new_value;
                if (event.type == ""blur"" && this.value.length < 5) this.value = """"
            }

            input.addEventListener(""input"", mask, false);
            input.addEventListener(""focus"", mask, false);
            input.addEventListener(""blur"", mask, false);
            input.addEventListener(""keydown"", mask, false)

        }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
