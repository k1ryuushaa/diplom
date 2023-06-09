#pragma checksum "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cc83b44ed880e0bedb82faab2dbff52adf68db3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LK_PartialClientHistory), @"mvc.1.0.view", @"/Views/LK/PartialClientHistory.cshtml")]
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
#line 1 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\_ViewImports.cshtml"
using ArtRoyalDetailing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\_ViewImports.cshtml"
using ArtRoyalDetailing.Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cc83b44ed880e0bedb82faab2dbff52adf68db3", @"/Views/LK/PartialClientHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_LK_PartialClientHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Contracts>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
  
    List<ContractsServices> contractServices = ViewBag.contractServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
 if (Model != null && Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"appointmentsContainer\">\r\n    <div id=\"header\">\r\n        Ваша история обслуживания:\r\n    </div>\r\n");
#nullable restore
#line 10 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
     foreach (var appointment in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"m-2\">\r\n            <div class=\"col appointmentDiv\" style=\"height: auto;\">\r\n                <h4 class=\"text-center m-0 font-italic\" style=\"letter-spacing: 7px;\">Запись #");
#nullable restore
#line 14 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                        Write(appointment.IdContract);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                <div class=""row p-2"">
                    <table class=""col table table-borderless text-light"" style=""background: #4802465b; border-radius: 20px; margin: 3px; max-height: 220px;"">
                        <tbody>
                            <tr>
                                <td class=""col-1"" style=""font-weight: bold; font-size: 13px; vertical-align: middle;"">Номер телефона клиента</td>
                                <td class=""col-2"" style=""min-width: 150px; vertical-align: middle;""><div class=""text-control"">");
#nullable restore
#line 20 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                         Write(appointment.ClientNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div></td>
                            </tr>
                            <tr>
                                <td class=""col-1"" style=""font-weight: bold; font-size: 13px; vertical-align: middle;"">Класс автомобиля</td>
                                <td class=""col-2"" style=""min-width: 150px; vertical-align: middle;""><div class=""text-control"">");
#nullable restore
#line 24 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                         Write(appointment.AutoClass);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div></td>
                            </tr>
                            <tr>
                                <td class=""col-1"" style=""font-weight: bold; font-size: 13px; vertical-align: middle;"">Гос. номер</td>
                                <td class=""col-2"" style=""min-width: 150px; vertical-align: middle;""><div class=""text-control"">");
#nullable restore
#line 28 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                         Write(appointment.GosNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div></td>
                            </tr>
                        </tbody>
                    </table>
                    <table class=""col table table-borderless"" style=""background: #4802465b; border-radius: 20px;margin: 4px; height:max-content"" id=""tableServices"">
                        <thead>
                            <tr class=""text-center table-header"">
                                <td scope=""col"" style=""vertical-align: middle;""><span style=""font-weight: bold;font-size: 16px;"">Услуга</span></td>
                                <td scope=""col"" style=""vertical-align: middle;""><span style=""font-weight: bold;font-size: 16px;"">Стоимость</span></td>
                                <td scope=""col"" style=""vertical-align: middle;""><span style=""font-weight: bold;font-size: 16px;"">Мойщик</span></td>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 41 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                             foreach (var appointmentServices in contractServices.Where(x => x.IdContract == appointment.IdContract))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr style=\"height:55px;\" id=\"tableRow\">\r\n                                    <td class=\"col-2\" style=\"min-width: 100px; vertical-align: middle;\"><div class=\"text-control\">");
#nullable restore
#line 44 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                             Write(appointmentServices.IdServiceNavigation.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></td>\r\n                                    <td class=\"col-2\" style=\"min-width: 100px; vertical-align: middle;\"><div class=\"text-control\">");
#nullable restore
#line 45 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                             Write(appointmentServices.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></td>\r\n                                    <td class=\"col-2\" style=\"min-width: 100px; vertical-align: middle;\"><div class=\"text-control\">");
#nullable restore
#line 46 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                             Write(appointmentServices.IdWasherNavigation.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                                                                              Write(appointmentServices.IdWasherNavigation.UserSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></td>\r\n                                </tr>\r\n");
#nullable restore
#line 48 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                    <table class=""col table table-borderless text-light"" style=""background: #4802465b; border-radius: 20px; margin: 3px; max-height: 220px;"">
                        <tbody>
                            <tr>
                                <td class=""col-1"" style=""font-weight: bold; font-size: 13px; vertical-align: middle;"">Дата записи</td>
                                <td class=""col-2"" style=""min-width: auto; vertical-align: middle;""><div class=""text-control"">");
#nullable restore
#line 55 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                        Write(appointment.DateContract.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div></td>
                            </tr>
                            <tr>
                                <td style=""font-weight: bold;font-size: 13px; vertical-align: middle;"">Время записи</td>
                                    <td class=""col-2"" style=""min-width: 150px; vertical-align: middle;""><div class=""text-control"">");
#nullable restore
#line 59 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                             Write(appointment.StartTime.Value.ToString(@"hh\:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 59 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
                                                                                                                                                                                Write(appointment.EndTime.Value.ToString(@"hh\:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 66 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 68 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"defaultContainer\">\r\n    <div id=\"nullRes\" style=\"font-size:25px\">Пока ничего нет</div>\r\n</div>\r\n");
#nullable restore
#line 74 "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\LK\PartialClientHistory.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Contracts>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
