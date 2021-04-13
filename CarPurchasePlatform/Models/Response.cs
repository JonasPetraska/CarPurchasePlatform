using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class Response
    {
        public string ErrorMessage { get; set; }
        public ErrorTypeEnum ResponseType { get; set; }

        public Response(string errorMessage, ErrorTypeEnum type)
        {
            ErrorMessage = errorMessage;
            ResponseType = type;
        }

        public Response(string errorMessage)
        {
            ErrorMessage = errorMessage;
            ResponseType = ErrorTypeEnum.NoSuccess;
        }

        protected Response()
        {

        }
    }

    public class Response<T> : Response
    {
        public T Content { get; set; }

        public Response(T content)
        {
            Content = content;
            ResponseType = ErrorTypeEnum.Success;
        }

        public Response(string errorMessage, ErrorTypeEnum type) : base(errorMessage, type)
        {
        }

        public Response(string errorMessage) : base(errorMessage)
        {
        }
    }

    public enum ErrorTypeEnum
    {
        Success,
        NoSuccess
    }
}
