using System.Text.Json.Serialization;

namespace Hired1stTest.DTO
{
    public class ForgotPassDTO
    {

        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("password_cofirm")]
        public string Password_Confirm { get; set; }
    }
}
