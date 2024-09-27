namespace Domain.ViewModels
{
    public class LoginViewModel
    {
        public string? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        //public string? NewToken { get; set; }
        public string? ExpirationTimeToken { get; set; }
        //public string? ExpirationTimeNewToken { get; set; }

        //public string? DataZalogowania { get; set; }
        //public string? DataWylogowania { get; set; }
        public string? Role { get; set; }
    }
}
