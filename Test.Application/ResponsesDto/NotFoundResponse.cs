using Microsoft.AspNetCore.Mvc;

namespace Test.Application.ResponsesDto
{
    public class NotFoundResponse : NotFoundResult
    {
        public NotFoundResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}