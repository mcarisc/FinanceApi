using System.ComponentModel.DataAnnotations;

namespace finance_api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
