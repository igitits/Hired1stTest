using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hired1stTest.DTO
{
    public class LoginDTO
    {
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password{ get; set; }
    }
}
