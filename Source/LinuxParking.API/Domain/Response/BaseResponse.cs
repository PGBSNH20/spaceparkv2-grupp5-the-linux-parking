namespace LinuxParking.API.Domain.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        protected BaseResponse(bool success)
        {
            Success = success;
        }
    }
}