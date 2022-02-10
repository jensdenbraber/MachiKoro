﻿using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.RefreshToken
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
