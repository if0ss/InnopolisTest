namespace Test.Application.ResponsesDto
{
    public class BadRequestResponse
    {
        public BadRequestResponse(string message)
        {
            Message = message;
        }

        private string Message { get; }
    }
}