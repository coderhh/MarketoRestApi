﻿using Marketo.ApiLibrary.Common.Model;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.SmartLists.Response
{
    public class SmartListResponse : BaseResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("folder")]
        public Folder Folder { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }
    }
}
