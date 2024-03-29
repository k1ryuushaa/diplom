#pragma checksum "C:\Users\bykov\Desktop\diplom\diplom\ArtRoyalDetailing\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b89966cf22702d760b06b2b5a590085760a4de3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b89966cf22702d760b06b2b5a590085760a4de3f", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97f27d8e858e53a6fde28bcc2e81f4974a845338", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""auth-modal"">
    <div class=""backDepth"" onclick=""closeModal()""></div>
    <div class=""modall"">
        <h3>Регистрация</h3>
        <input type=""text"" placeholder=""Фамилия"" id=""username"" name=""Surname"">
        <input type=""text"" placeholder=""Имя"" id=""username"" name=""Name"">
        <input type=""text"" placeholder=""Логин"" id=""username"" name=""Login"">
        <input type=""text"" placeholder=""Номер телефона"" id=""username"" onfocus=""maskValid(this)"" name=""PhoneNumber"">
        <input type=""text"" placeholder=""Электронная почта"" id=""username"" name=""Email"">
        <input type=""text"" placeholder=""Код подтвержения"" id=""username"" style=""display:none"" name=""EmailCode"">
        <div class=""passwordBox"">
            <input type=""password"" placeholder=""Пароль"" id=""password"">
            <ion-icon name=""eye-outline"" id=""eye"" onclick=""showPass()""></ion-icon>
        </div>
        <button type=""submit"" onclick=""register(this)"">Зарегистрироваться</button>
    </div>
    <script>
        var onCheckMa");
            WriteLiteral(@"il = false
        let code = """"
        closeModal = () => {
            if (!onCheckMail)
                document.querySelector('.backDepth').parentNode.parentNode.innerHTML = ''
        }
        let passss = true
        showPass = () => {
            if (passss) {
                document.querySelector('#password').setAttribute('type', 'text')
                passss = !passss
            }
            else {
                document.querySelector('#password').setAttribute('type', 'password')
                passss = !passss
            }

        }
        maskValid = (input) => {
            var keyCode;
            function mask(event) {
                event.keyCode && (keyCode = event.keyCode);
                var pos = this.selectionStart;
                if (pos < 3) event.preventDefault();
                var matrix = ""+7 (___) ___-____"",
                    i = 0,
                    def = matrix.replace(/\D/g, """"),
                    val = this.value.replace(/\D/g, """);
            WriteLiteral(@"""),
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
                if (!reg.test(this.value) || this.value.length < 5 || keyCode > 47 && keyCode < 58) this.value = new_value;
                if (event.type == ""blur"" && this.value.length < 5) this.value = """"
            }

            input.addEventListener(""input"", mask, false);
            input.addEventListener(""focus"", mask, false);
            input.addEvent");
            WriteLiteral(@"Listener(""blur"", mask, false);
            input.addEventListener(""keydown"", mask, false)

        }
        register = (button) => {
            let surnameVal = document.getElementsByName(""Surname"")[0].value
            let firstnameVal = document.getElementsByName(""Name"")[0].value
            let loginVal = document.getElementsByName(""Login"")[0].value
            let phoneVal = document.getElementsByName(""PhoneNumber"")[0].value
            let emailVal = document.getElementsByName(""Email"")[0].value
            let passwordVal = document.getElementById(""password"").value
            if (surnameVal == """" || firstnameVal == """" || loginVal == """" || phoneVal == """" || emailVal == """" || passwordVal == """") {
                createAlert(""Ошибка"", ""Не все поля заполнены"", ""error"")
                return
            }
            if (!onCheckMail) {
                var model = {
                    login: loginVal,
                    phone: phoneVal,
                    email: emailVal,
          ");
            WriteLiteral(@"          name: firstnameVal
                }
                $.ajax({
                    url: '/Account/RegisterConfirm',
                    type: ""POST"",
                    contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                    data: model,
                    async: true,
                    processData: true,
                    cache: false,
                    success: function (data) {
                        if (data.data == false) {
                            createAlert(""Ошибка"", data.description, ""error"")
                            return
                        }
                        if (data.data == true) {
                            createAlert(""Подтверждение"", ""На вашу почту пришёл код, введите его для подтверждения регистрации"", ""success"")
                            code = data.description
                            onCheckMail = true
                            button.innerHTML = ""Отправить""
                            document.get");
            WriteLiteral(@"ElementsByName(""EmailCode"")[0].style.display = ""block""
                            return
                        }
                    },
                    error: function (xhr) {
                        createAlert('Ошибка', ""Ошибка сервера"", 'error')
                    }
                });

            }
            else {
                if (document.getElementsByName(""EmailCode"")[0].value == code) {
                    var model = {
                        Login: loginVal,
                        PhoneNumber: phoneVal,
                        Email: emailVal,
                        Name: firstnameVal,
                        Surname: surnameVal,
                        Password: passwordVal
                    }
                    $.ajax({
                        url: '/Account/Register',
                        type: ""POST"",
                        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                        data: model,
                        ");
            WriteLiteral(@"async: true,
                        processData: true,
                        cache: false,
                        success: function (data) {
                            if (data.data == true) {
                                closeModal()
                                window.location.reload()
                                return
                            }
                            if (data.data==false) {
                                createAlert(""Ошибка"", data.description, ""error"")
                                return
                            }
                        },
                        error: function (xhr) {
                            createAlert('Ошибка', ""Ошибка сервера"", 'error')
                        }
                    });
                }
                else {
                    createAlert(""Ошибка"",""Код подтверждения неверный"",""error"")
                }
            }
        }
    </script>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
