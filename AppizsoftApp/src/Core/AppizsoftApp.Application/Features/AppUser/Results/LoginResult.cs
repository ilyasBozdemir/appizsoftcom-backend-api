namespace AppizsoftApp.Application.Features.AppUser.Results
{
    public class LoginResult 
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
