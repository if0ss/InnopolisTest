using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ResponsesDto
{
    public class BadRequestResponse : BadRequestResult
    {
        public BadRequestResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

    }
}