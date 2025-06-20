namespace finance_api.Dtos.UserDtos
{
    public class RegisterUserDto
    {
        /*public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; } */

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
