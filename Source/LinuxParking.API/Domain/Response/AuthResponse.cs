namespace LinuxParking.API.Domain.Response
{
    public class AuthResponse : BaseResponse
    {
        public string Token { get; set; }
        private AuthResponse(bool success, string message, string token) : base(success, message)
        {
            Token = token;
        }

        public AuthResponse(string msg, string token) : this(true, msg, token) { }
        public AuthResponse(string msg) : this(true, msg, string.Empty) { }
    }
}