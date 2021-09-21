namespace Test.Application.ResponsesDto
{
    public class BaseResponse
    {
        public BaseResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}