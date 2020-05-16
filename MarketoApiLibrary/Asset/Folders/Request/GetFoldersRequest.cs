﻿using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFoldersRequest : BaseRequest
    {
        public Dictionary<string, dynamic> Root = new Dictionary<string, dynamic>();
        public int Offset { get; set; }//integer offset for paging
        public int MaxDepth { get; set; }//depth of tree to traverse, default 2
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
        public string WorkSpace { get; set; }//filter for workspace
    }
}