namespace Test.Application.ResponsesDto
{
    public class BadRequestResponse : BaseResponse
    {
        public BadRequestResponse(string message) : base(message)
        {
        }
    }
}