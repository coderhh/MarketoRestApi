﻿using MarketoApiLibrary;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using MarketoApiLibrary.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarketoApiConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ApiConfig apiConfig = ConfigurationProvider.LoadConfig();
                string host = apiConfig.Host;
                string clientId = apiConfig.ClientId;
                string clientSecret = apiConfig.ClientSecret;

                //GetSmartList(host, clientId, clientSecret);
                // The destination folder URLs are: "30844"
                //https://app-sj02.marketo.com/#FI0A1ZN76278
                //https://app-sj02.marketo.com/#FI0A1ZN76359
                //var folderIds = new List<string> { "76278", "49092", "36910", "49184", "64594", "64595", "64596",
                //                                   "43942", "51205", "51206", "51207", "51208", "53876", "55694",
                //                                   "59285", "61840", "34211", "69746","30838", "51251", "51250",
                //                                   "51249", "55029", "61035", "65917", "69019", "74231", "42278" };
                //var folderIds = new List<string>{ "76359","35467","40733","54025","51259","52904",
                //                                  "47865","46098","52951","43462","52357","49792","48470",
                //                                  "47202","54034","59952","65937","62541","59951","63661","66800"};
                //var folderIds = new List<string> { "30844" };
                //var folderIds = new List<string> { "79047", "45169","48095","47968","54651","55105","54964",
                //                                    "55162","55158","55067","55072","50671","46406","49445",
                //                                    "62842","65113","49005","47462","52936","45603",
                //                                    "51337","44073"};
                // var folderIds = new List<string> { "77128", "76383" };
                //var folderIds = new List<string> { "76383", "30846", "56935", "75680", "67334", "69523", "39438",
                //                                    "35469", "47159","54738", "45192", "49518", "51397", "40497",
                //                                    "36037","49582","54150","37783","41502","44521","50537"};

                //DownFile(host, clientId, clientSecret, folderIds, @"D:\DownloadedImageFromMarketo");
                List<string> folderIds = GetSubFolderIDs(host, clientId, clientSecret, "76383");
                DownFile(host, clientId, clientSecret, folderIds, @"D:\DownloadedImageFromMarketo");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void GetSmartList(string host, string clientId, string clientSecret)
        {
            MarketoClient client = new MarketoClient(host, clientId, clientSecret);
            bool isJson = true;
            GetSmartListResponse result = client.GetSmartList<GetSmartListResponse>(isJson);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static List<string> GetSubFolderIDs(string host, string clientId, string clientSecret, string rootFolderId)
        {
            MarketoClient client = new MarketoClient(host, clientId, clientSecret);
            GetFoldersResponse result = client.GetFolders(rootFolderId).Result;
            List<string> folderIDs = new List<string>();
            if (result.Result != null)
            {
                foreach (MarketoFolder folder in result.Result)
                {
                    folderIDs.Add(folder.Id.ToString());
                }
            }
            return folderIDs;
            //string prettyJson = JToken.Parse(result).ToString(Formatting.Indented);
        }
        private static void DownFile(string host, string clientId, string clientSecret, List<string> folderIds, string savePath)
        {
            MarketoClient client = new MarketoClient(host, clientId, clientSecret);
            foreach (string folderId in folderIds)
            {
                Console.WriteLine(folderId);
                GetFilesResponse fileResult = client.GetFiles(folderId, 0).Result;
                string saveRootPath = Path.Combine(savePath, folderId);

                if (fileResult?.Result != null)
                {
                    if (!Directory.Exists(saveRootPath))
                    {
                        Directory.CreateDirectory(saveRootPath);
                    }
                    WriteFileToDisk(fileResult, saveRootPath);
                    if (fileResult.Result.Count >= 200)
                    {
                        MarketoClient client200 = new MarketoClient(host, clientId, clientSecret);
                        GetFilesResponse fileResult200 = client200.GetFiles(folderId, 200).Result;
                        if (fileResult200?.Result != null)
                        {
                            WriteFileToDisk(fileResult200, saveRootPath);
                        }
                    }
                }
                Console.WriteLine("Done!");
            }
            Console.ReadKey();
        }
        private static void WriteFileToDisk(GetFilesResponse fileResult, string saveRootPath)
        {
            if (fileResult?.Result == null) return;
            foreach (MarketoFile file in fileResult?.Result)
            {
                string fileName = Path.Combine(saveRootPath, file.Name);
                FileDownloader.DownFile(file.Url, fileName);
                Console.WriteLine(file?.Url);
            }
        }
    }
}
