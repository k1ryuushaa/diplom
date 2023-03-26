using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtRoyalDetailing.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Укажите логин")]
        [MaxLength(35,ErrorMessage ="Максимальная длина имени = 35 символов")]
        [MinLength(2,ErrorMessage ="Имя должно содержать не менее 2 символов")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Укажите пароль")]
        [MinLength(6,ErrorMessage ="Пароль должен содержать не менее 6 символов")]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Укажите номер телефона")]
        public string PhoneNumber { get; set; }
    }
}
