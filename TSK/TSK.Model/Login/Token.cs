﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TSK.Model
{
    public class Token
    {
        [JsonPropertyName("token")]
        public string AccessToken { get; set; } = string.Empty;

        public int MinutesTillExpires { get; set; }
    }
}
