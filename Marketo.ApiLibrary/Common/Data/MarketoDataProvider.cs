﻿using Marketo.ApiLibrary.Common.Http.Data;
using Marketo.ApiLibrary.Common.Http.Exceptions;
using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Model;
using System;
using System.Net.Http;

namespace Marketo.ApiLibrary.Common.Data
{
    public class MarketoDataProvider : IMarketoDataProvider
    {
        private readonly IHttpApiDataProvider _apiDataProvider;

        public MarketoDataProvider(IHttpApiDataProvider apiDataProvider)
        {
            this._apiDataProvider = apiDataProvider;
        }

        public T ExecuteRequest<T>(HttpRequest request, ILoggingService<ILogInstance> logger) where T : ApiModel
        {
            var response = this._apiDataProvider.SendRequest(request, logger);
            if (!response.IsSuccessCode)
            {
                var stringContent = response.Content.ReadAsStringAsync().Result;
                throw new HttpResponseException(response.Code, stringContent);
            }

            var model = response.Content.ReadAsAsync<T>().Result;
            if (model == null)
                throw new InvalidOperationException($"Could not get the response model {typeof(T).FullName}");
            return model;
        }

        public void ExecuteRequest(HttpRequest request, ILoggingService<ILogInstance> logger)
        {
            var response = this._apiDataProvider.SendRequest(request, logger);
            if (!response.IsSuccessCode)
                throw new HttpResponseException(response.Code);
        }
    }
}
