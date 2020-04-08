﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MarketoApiLibrary
{
    public class IdentityResponse
    {
        [JsonProperty("access_token")]
        public string  AccessToken { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
