#pragma checksum "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "054ab1871b291e9231d33a15e69bd44b15151fd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LK_PartialSalaryForWorker), @"mvc.1.0.view", @"/Views/LK/PartialSalaryForWorker.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"054ab1871b291e9231d33a15e69bd44b15151fd4", @"/Views/LK/PartialSalaryForWorker.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    public class Views_LK_PartialSalaryForWorker : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArtRoyalDetailing.Domain.Models.Users>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
  
    var appointments = (List<ArtRoyalDetailing.Domain.Models.Contracts>)ViewBag.Appointments;
    var appoinmentServices = (List<ArtRoyalDetailing.Domain.Models.ContractsServices>)ViewBag.AppointmentsServices;
    var lastSalary = (Salary)ViewBag.LastSalary;
    int salary = 0;
    bool group = false;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
 if (lastSalary != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"containerForSalary\">\r\n    <div id=\"nullRes\">Последний расчёт был ");
#nullable restore
#line 12 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                                      Write(lastSalary.DateSalary.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" на сумму ");
#nullable restore
#line 12 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                                                                                                Write(lastSalary.Salary1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" руб.</div>\r\n</div>\r\n");
#nullable restore
#line 14 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"containerForSalary\">\r\n");
#nullable restore
#line 16 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
     if(appointments!=null&&appoinmentServices!=null&&appoinmentServices.Count>0&&appointments.Count>0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-borderless mb-0"">
        <thead>
            <tr>
                <td>
                    Запись 
                </td>
                <td>
                    Дата
                </td>
                <td>
                    Класс авто
                </td>
                <td>
                    Услуга
                </td>
                <td>
                    Стоимость услуги (руб.)
                </td>
                <td>
                    З/П (руб.)
                </td>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 42 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
             foreach (var appointment in appointments)
            {
                {group = true;}
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                 foreach (var service in appoinmentServices)
                {
                    if (appointment.IdContract == service.IdContract)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n");
#nullable restore
#line 50 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                             if (group)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 53 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                           Write(appointment.IdContract);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 56 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                           Write(appointment.DateContract.Value.ToString("D"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 59 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                           Write(appointment.AutoClass);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 61 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                            { group = false; }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                            </td>\r\n                            <td>\r\n                            </td>\r\n");
#nullable restore
#line 69 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 71 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                           Write(service.IdServiceNavigation.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 74 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                           Write(service.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td style=\"font-weight:bold\">\r\n                                ");
#nullable restore
#line 77 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                            Write(Math.Round((double)service.Cost.Value * 0.3,2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 78 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                                  salary += (int)((double)service.Cost.Value * 0.3);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 81 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style=""font-weight: bold;font-size: 20px;text-align: end;"">
                    ИТОГО:
                </td>
                <td style=""font-size: 20px;"">
                    ");
#nullable restore
#line 95 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                Write(salary);

#line default
#line hidden
#nullable disable
            WriteLiteral("руб.\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <button onclick=\"setSalary()\">Рассчитать</button>\r\n");
#nullable restore
#line 101 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
    }
    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div id=\"nullRes\">Пока ничего не заработал</div>\r\n");
#nullable restore
#line 104 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<script>\r\n    setSalary = () => {\r\n        let worker =");
#nullable restore
#line 108 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
               Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        $.ajax({\r\n                url: \'");
#nullable restore
#line 110 "D:\Users\bykov\source\repos\ArtRoyalDetailing — копия\ArtRoyalDetailing\Views\LK\PartialSalaryForWorker.cshtml"
                 Write(Url.Action("SetSalary", "LK"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                data: { workerId: worker },
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                processData: true,
                cache: false,
                async: true,
                success: function (data) {
                    if (data.data == true) {
                        createAlert('Зарплата выдана', data.description, 'success')
                    }
                    else {
                        createAlert('Ошибка', data.description, 'error')
                    }
                    $('.containerForSalary')[1].html('<div id=""nullRes"">Пока ничего не заработал</div>')
                },
                error: function (xhr) {
                    alert(JSON.stringify(xhr))
                    createAlert('Ошибка', ""Запрос не отправлен"", 'error')
                }
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArtRoyalDetailing.Domain.Models.Users> Html { get; private set; }
    }
}
#pragma warning restore 1591