using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ArtRoyalDetailing.Domain.Enum
{
    public enum Role
    {
        [Description("Клиент")]
        Client =1,
        [Description("Мойщик")]
        Washer = 2,
        [Description("Администратор")]
        Admin = 3
    }
}
