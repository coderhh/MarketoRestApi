﻿using System.Threading.Tasks;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using MarketoApiLibrary.Service;

namespace MarketoApiLibrary
{
    public class MarketoAssetClient
    {
        private readonly string _host;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _token;
        private readonly IFilesRequestFactory _fileRequestFactory;

        public MarketoAssetClient(string host, string clientId, string clientSecret)
        {
            _host = host;
            _clientId = clientId;
            _clientSecret = clientSecret;
            ITokenProvider tokenProvider = new TokenProvider();
            _token = tokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
            _fileRequestFactory = new FilesRequestFactory();
        }

        // Files
        public void GetFileByName(string fileName)
        {

        }
       
        public void GetFileById(string fileId)
        {

        }

        /// <summary>
        /// GET /rest/asset/v1/files.json
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="offSet"></param>
        /// <returns></returns>
        public async Task<GetFilesResponse> GetFiles(string folderId, int offSet)
        {
            var request = _fileRequestFactory.CreateGetFilesRequest(_host, _token, folderId, offSet);
            var result = await FilesHttpProcessor.GetFiles(request);
            return result;
        }
        
        public void CreateFile()
        {

        }
      
    }
}