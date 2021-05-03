namespace LinuxParking.Domain.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public BaseResponse(bool success)
        {
            Success = success;
        }
    }
}