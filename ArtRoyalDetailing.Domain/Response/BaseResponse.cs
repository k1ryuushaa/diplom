using ArtRoyalDetailing.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtRoyalDetailing.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        StatusCode StatusCode { get; }
        T Data { get; }
    }
}
