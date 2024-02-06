using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Hired1stTest.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [Required]
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
        public string Password { get; private set; }
        public void SetPassword(string password) 
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                Password = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
