using System;
using System.Collections.Generic;
using System.Text;

namespace ArtRoyalDetailing.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,
        OK =200,
        InternalServerError=400
    }
}
