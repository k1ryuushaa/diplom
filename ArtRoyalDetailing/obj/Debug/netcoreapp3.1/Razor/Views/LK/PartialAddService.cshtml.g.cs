#pragma checksum "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9886663b2d111d4fff8755bd6691d84c8f566a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LK_PartialAddService), @"mvc.1.0.view", @"/Views/LK/PartialAddService.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9886663b2d111d4fff8755bd6691d84c8f566a", @"/Views/LK/PartialAddService.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    public class Views_LK_PartialAddService : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ServiceType>>
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
            WriteLiteral(@"<div class=""defaultContainer"">
    <table class=""table table-borderless"">
        <tbody>
            <tr>
                <td scope=""col"">Наименование услуги</td>
                <td scope=""col"" style=""min-width:210px""><input type=""text"" id=""serviceName"" class=""inputSelectBox"" placeholder=""Введите наименование"" /></td>
            </tr>
            <tr>
                <td>Тип услуги</td>
                <td>
                    <select type=""text"" id=""serviceType"" class=""inputSelectBox"" style=""letter-spacing:2px;"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d9886663b2d111d4fff8755bd6691d84c8f566a4067", async() => {
                WriteLiteral("Выберите тип");
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
#line 16 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml"
                         foreach (var type in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d9886663b2d111d4fff8755bd6691d84c8f566a6181", async() => {
#nullable restore
#line 18 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml"
                                                    Write(type.TypeName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml"
                               WriteLiteral(type.IdType);

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
#line 19 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </td>
            </tr>
            <tr>
                <td>Класс A</td>
                <td><input type=""text"" id=""c1"" class=""inputSelectBox"" placeholder=""Введите стоимость"" /></td>
            </tr>
            <tr>
                <td>Класс B, C, D</td>
                <td><input type=""text"" id=""c2"" class=""inputSelectBox"" placeholder=""Введите стоимость"" /></td>
            </tr>
            <tr>
                <td>Кроссовер/ Универсал/ Класс E, F</td>
                <td><input type=""text"" id=""c3"" class=""inputSelectBox"" placeholder=""Введите стоимость"" /></td>
            </tr>
            <tr>
                <td>Внедорожник</td>
                <td><input type=""text"" id=""c4"" class=""inputSelectBox"" placeholder=""Введите стоимость"" /></td>
            </tr>
            <tr>
                <td>Минивэн</td>
                <td><input type=""text"" id=""c5"" class=""inputSelectBox"" placeholder=""Введите стоимость"" /></td>
            </tr>
      ");
            WriteLiteral(@"  </tbody>
    </table>
    <button id=""btn"" onclick=""addService()"">Добавить услугу</button>
</div>
<script>
    addService = () => {
        let serviceName = document.querySelector(""#serviceName"").value
        let serviceType = document.querySelector(""#serviceType"").value
        let serviceC1 = document.querySelector(""#c1"").value
        let serviceC2 = document.querySelector(""#c2"").value
        let serviceC3 = document.querySelector(""#c3"").value
        let serviceC4 = document.querySelector(""#c4"").value
        let serviceC5 = document.querySelector(""#c5"").value
        if (serviceName == """" || serviceType == """" || serviceC1 == """" || serviceC2 == """" || serviceC3 == """" || serviceC4 == """" || serviceC5 == """") {
            createAlert(""Ошибка"", ""Некоторые поля пустые"", ""error"")
            return;
        }
        var model = {
            ServiceName:serviceName,
            ServiceType: serviceType,
            CostOne: serviceC1,
            CostTwo: serviceC2,
            CostTh");
            WriteLiteral("ree: serviceC3,\r\n            CostFour: serviceC4,\r\n            CostFive: serviceC5\r\n        }\r\n        $.ajax({\r\n                url: \'");
#nullable restore
#line 70 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialAddService.cshtml"
                 Write(Url.Action("AddService", "LK"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                data: model,
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                processData: true,
                cache: false,
                async: true,
                success: function (data) {
                    if (data.data == true)
                        createAlert('Успешно', data.description, 'success')
                    if (data.data == false)
                        createAlert('Ошибка', data.description, 'error')
                },
                error: function (xhr) {
                    alert(JSON.stringify(xhr))
                    createAlert('Ошибка', ""Запрос не отправлен"", 'error')
                }
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ServiceType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
