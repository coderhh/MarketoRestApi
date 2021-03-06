﻿using Marketo.ApiLibrary.Asset.Files.Request;

namespace Marketo.ApiLibrary.Asset.Files
{
    public interface IFilesRequestFactory
    {
        GetFilesRequest CreateGetFilesRequest(string host, string token, string folderId, int offSet = 0, int maxReturn = 200);
        GetFileByNameRequest CreateGetFileByNameRequest(string host, string token, string fileName);
        GetFileByIdRequest CreateGetFileByIdRequest(string host, string token, int fileId);
        CreateFileRequest CreateCreateFileRequest(string host, string token, string file);
        UpdateFileRequest CreateUpdateFileRequest(string host, string token, string filePath, string fileId);
    }
}