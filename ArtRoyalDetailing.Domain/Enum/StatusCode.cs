using System;
using System.Collections.Generic;
using System.Text;

namespace ArtRoyalDetailing.Domain.Enum
{
    public enum StatusCode
    {
        NotFound = 0,
        AlreadyExists = 1,
        OK =200,
        InternalServerError=400,
        AdminAlreadyExists=2,
        ManyWashers=3,
        IncorrectData=4
    }
}
