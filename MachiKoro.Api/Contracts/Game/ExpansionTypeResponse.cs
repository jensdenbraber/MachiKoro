﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExpansionTypeResponse
{
    [EnumMember(Value = "Basic")]
    Basic,

    [EnumMember(Value = "Harbor Expansion")]
    HarborExpansion
}