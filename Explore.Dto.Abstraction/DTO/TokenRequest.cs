using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ExploreSolution.DTO
{
    public class TokenRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}