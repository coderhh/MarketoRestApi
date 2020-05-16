﻿using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Mis.Request
{
    public class CustomObjectsRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string DedupeBy { get; set; }
        public List<Dictionary<string, dynamic>> Input { get; set; }
    }
}