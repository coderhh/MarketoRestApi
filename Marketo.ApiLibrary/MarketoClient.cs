﻿using Marketo.ApiLibrary.Asset.Files;
using Marketo.ApiLibrary.Asset.Files.Request;
using Marketo.ApiLibrary.Asset.Files.Response;
using Marketo.ApiLibrary.Asset.Folders;
using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Asset.Folders.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Mis.Provider;
using Marketo.ApiLibrary.Mis.Request;
using Marketo.ApiLibrary.Mis.Service;

namespace Marketo.ApiLibrary
{
    public class MarketoClient
    {
        //private readonly string _host;
        //private readonly string _clientId;
        //private readonly string _clientSecret;
        //private readonly string _token;
        //private readonly IRequestFactory _requestFactorty;
        //private readonly IAuthenticationTokenProvider _tokenProvider;
        //public MarketoClient(string host, string clientId, string clientSecret)
        //{
        //    _host = host;
        //    _clientId = clientId;
        //    _clientSecret = clientSecret;
        //    _tokenProvider = new AuthenticationTokenProvider();
        //    _token = _tokenProvider.GetToken().Token;
        //    _requestFactorty = new RequestFactory();
        //}


        //public Task<FoldersResponse> GetFolders(string rootFolderId)
        //{
        //    GetFoldersRequest request = _requestFactorty.CreateGetFoldersRequest(_host, _token, rootFolderId);
        //    var folders = FoldersHttpProcessor.GetFolders<FoldersResponse>(request);
        //    return folders;
        //}

        //public void BulkExportLeads()
        //{
        //    Console.WriteLine("============================Getting token==============================");
        //    Console.WriteLine("============================Creating job==============================");

        //    LeadsExportRequest leadsExportRequest = _requestFactorty.CreateGetLeadsExportRequest(_host, _token);

        //    string job = LeadsHttpProcessor.CreateJob(leadsExportRequest);
        //    Console.WriteLine("============================Getting exportedId==============================");
        //    JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
        //    JToken result = jobObject["result"];
        //    string exportedId = result[0]["exportId"].ToString();
        //    leadsExportRequest.ExportId = exportedId;

        //    Console.WriteLine("============================Enqueuing job " + exportedId + "==============================");
        //    LeadsHttpProcessor.EnqueueJob(leadsExportRequest);
        //    string status = LeadsHttpProcessor.GetJobStatus(leadsExportRequest);
        //    while (status != "Completed")
        //    {
        //        System.Threading.Thread.Sleep(1 * 60 * 1000);
        //        status = status = LeadsHttpProcessor.GetJobStatus(leadsExportRequest);
        //        //Console.WriteLine("==============================Waiting job to be completed=====================================");
        //        Console.WriteLine("==============================" + status + "=====================================");
        //    }

        //    if (LeadsHttpProcessor.GetJobStatus(leadsExportRequest) == "Completed")
        //    {
        //        Console.WriteLine("==========================Job Completed, Start to retrieving===============================");
        //        string extractedData = LeadsHttpProcessor.RetrieveData(leadsExportRequest);
        //        System.IO.File.WriteAllText(@"D:\List_Import_Leads.csv", extractedData);
        //        Console.WriteLine("==========================Done!===============================");
        //        Console.ReadKey();
        //    }
        //}

        //public async Task<FilesResponse> GetFiles(string folderId, int offSet)
        //{
        //    GetFilesRequest request = _requestFactorty.CreateGetFilesRequest(_host, _token, folderId, offSet);
        //    FilesResponse result = await FilesHttpProcessor.GetFiles<FilesResponse>(request);
        //    return result;

        //}
        //public void BulkExportActivities()
        //{
        //    Console.WriteLine("============================Getting token==============================");
        //    Console.WriteLine("============================Creating job==============================");

        //    ActivitiesExportRequest request = _requestFactorty.CreateActivitiesExportRequest(_host, _token);
        //    string job = ActivitiesHttpProcessor.CreateJob(request);
        //    Console.WriteLine("============================Getting exportedId==============================");
        //    JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
        //    JToken result = jobObject["result"];
        //    string exportedId = result[0]["exportId"].ToString();
        //    request.ExportId = exportedId;
        //    Console.WriteLine("============================Enqueuing job " + exportedId + "==============================");
        //    ActivitiesHttpProcessor.EnqueueJob(request);
        //    string status = ActivitiesHttpProcessor.GetJobStatus(request);
        //    while (status != "Completed")
        //    {
        //        System.Threading.Thread.Sleep(1 * 60 * 1000);
        //        status = ActivitiesHttpProcessor.GetJobStatus(request);
        //        //Console.WriteLine("==============================Waiting job to be completed=====================================");
        //        Console.WriteLine("==============================" + status + "=====================================");

        //    }

        //    if (ActivitiesHttpProcessor.GetJobStatus(request) == "Completed")
        //    {
        //        Console.WriteLine("==========================Job Completed, Start to retrieving===============================");
        //        string extractedData = ActivitiesHttpProcessor.Export(request).Result;
        //        System.IO.File.WriteAllText(@"D:\activitity_results001.csv", extractedData);
        //        Console.WriteLine("==========================Done!===============================");
        //        Console.ReadKey();
        //    }
        //}
        //public string DescribeCustomObjects()
        //{
        //    CustomObjectsRequest request = _requestFactorty.CreateCustomObjectsRequest(_host, _token);
        //    string result = CustomObjectProcessor.DescribeCustomObjects(request);
        //    return result;
        //}
        //public string SyncCustomObjects()
        //{
        //    CustomObjectsRequest request = _requestFactorty.CreateCustomObjectsRequest(_host, _token);
        //    string result = CustomObjectProcessor.SyncCustomObjects(request);
        //    return result;
        //}
    }
}

