using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hired1stTest.DTO
{
    public class RegisterDTO
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [Required]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [Required]
        [JsonPropertyName("password_confirm")]
        public string PasswordConfrim { get; set; }
    }
}
