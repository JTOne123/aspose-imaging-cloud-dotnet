﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiTester.cs">
//   Copyright (c) 2018 Aspose.Imaging for Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Cloud.Sdk.Test.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    using Aspose.Imaging.Cloud.Sdk.Model;
    using Aspose.Imaging.Cloud.Sdk.Model.Requests;
    using Aspose.Storage.Cloud.Sdk.Model;
    using Aspose.Storage.Cloud.Sdk.Model.Requests;

    using Aspose.Storage.Cloud.Sdk.Api;
    using Newtonsoft.Json;

    using NUnit.Framework;

    /// <summary>
    /// Base class for API tester
    /// </summary>
    public abstract class ApiTester
    {
        #region Consts

        /// <summary>
        /// The server access file
        /// </summary>
        private const string ServerAccessFile = "serverAccess.json";

        /// <summary>
        /// The application key
        /// </summary>
        private const string AppKey = "xxx";

        /// <summary>
        /// The application SID
        /// </summary>
        private const string AppSid = "xxx";

        /// <summary>
        /// The base URL
        /// </summary>
        private const string BaseUrl = "http://api.aspose.cloud/";

        /// <summary>
        /// The local test folder
        /// </summary>
        protected const string LocalTestFolder = "..\\..\\..\\..\\TestData\\";

        /// <summary>
        /// The cloud test folder
        /// </summary>
        protected const string CloudTestFolder = "CloudTestDotNet";

        /// <summary>
        /// The cloud references folder
        /// </summary>
        protected const string CloudReferencesFolder = "CloudTestReferences";

        /// <summary>
        /// The default storage
        /// </summary>
        protected const string DefaultStorage = "Imaging-QA";

        /// <summary>
        /// The size difference division
        /// </summary>
        protected const long SizeDiffDivision = 20;

        /// <summary>
        /// Original test data folder
        /// </summary>
        private const string OriginalDataFolder = "CloudTest";

        #endregion

        #region Fields

        protected List<FileResponse> InputTestFiles;

        /// <summary>
        /// Aspose.Imaging API
        /// </summary>
        protected ImagingApi ImagingApi;

        /// <summary>
        /// Aspose.Storage API
        /// </summary>
        protected StorageApi StorageApi;

        /// <summary>
        /// The basic export formats
        /// </summary>
        protected readonly string[] BasicExportFormats = new string[]
        {
            "bmp",
            "gif",
            "jpg",
            "png",
            "psd",
            "tiff"
        };

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate that tests properties.
        /// </summary>
        /// <param name="originalProperties">The original properties.</param>
        /// <param name="resultProperties">The result properties.</param>
        protected delegate void PropertiesTesterDelegate(ImagingResponse originalProperties, ImagingResponse resultProperties);

        /// <summary>
        /// Typical GET request delegate that accepts image file name from Storage.
        /// </summary>
        /// <param name="fileName">File name of the image.</param>
        /// <returns></returns>
        protected delegate Stream GetRequestInvokerDelegate(string fileName, string outPath);

        /// <summary>
        /// Typical POST request delegate that accepts input image stream.
        /// </summary>
        /// <param name="inputStream">The input image stream.</param>
        /// <returns></returns>
        protected delegate Stream PostRequestInvokerDelegate(Stream inputStream, string outPath);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether resulting images should be removed from cloud storage.
        /// </summary>
        /// <value>
        ///   <c>true</c> if resulting images should be removed from cloud storage; otherwise, <c>false</c>.
        /// </value>
        public bool RemoveResult { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [automatic recover reference] (i.e. if resulting images of failed tests are considered as new valid references).
        /// Please, change this value ONLY if you clearly understand the consequences, or it may lead to replacement of the images you need, so they will be lost.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic recover reference]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoRecoverReference { get; set; } = false;

        #endregion

        #region Configuration

        [TestFixtureSetUp]
        public void InitFixture()
        {
            this.CreateApiInstances();
            if (this.StorageApi.GetIsExist(new GetIsExistRequest(CloudTestFolder, null, DefaultStorage)).FileExist.IsExist.Value)
            {
                this.StorageApi.DeleteFolder(new DeleteFolderRequest(CloudTestFolder, DefaultStorage, true));
                this.StorageApi.PutCreateFolder(new PutCreateFolderRequest(CloudTestFolder, DefaultStorage, DefaultStorage));
            }
        }

        [TestFixtureTearDown]
        public void FinilizeFixture()
        {
            if (this.StorageApi.GetIsExist(new GetIsExistRequest(CloudTestFolder, null, DefaultStorage)).FileExist.IsExist.Value)
            {
                this.StorageApi.DeleteFolder(new DeleteFolderRequest(CloudTestFolder, DefaultStorage, true));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the API instances using given access parameters.
        /// </summary>
        /// <param name="appKey">The application key.</param>
        /// <param name="appSid">The application sid.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="authType">Type of the authentication.</param>
        /// <param name="debug">if set to <c>true</c> [debug].</param>
        /// <exception cref="System.ArgumentException">Please, specify valid access data (AppKey, AppSid, Base URL)</exception>
        protected void CreateApiInstances(string appKey = AppKey, string appSid = AppSid, string baseUrl = BaseUrl, string apiVersion = "v2",
            Client.AuthType authType = Client.AuthType.OAuth2, bool debug = false)
        {
            if (appKey == AppKey || appSid == AppSid || string.IsNullOrEmpty(baseUrl))
            {
                string serverAccessPath = Path.Combine(LocalTestFolder, ServerAccessFile);
                FileInfo serverFileInfo = new FileInfo(serverAccessPath);
                if (serverFileInfo.Exists && serverFileInfo.Length > 0)
                {
                    var accessData = JsonConvert.DeserializeObject<ServerAccessData>(File.ReadAllText(serverAccessPath));
                    appKey = accessData.AppKey;
                    appSid = accessData.AppSid;
                    baseUrl = accessData.BaseURL;
                }
                else
                {
                    throw new ArgumentException("Please, specify valid access data (AppKey, AppSid, Base URL)");
                }
            }

            this.ImagingApi = new ImagingApi(appKey, appSid, baseUrl, apiVersion, authType, debug);
            this.StorageApi = new StorageApi(new Storage.Cloud.Sdk.Configuration()
            {
                ApiBaseUrl = baseUrl,
                AppKey = appKey,
                AppSid = appSid
            });

            InputTestFiles = FetchInputTestFilesInfo();
        }

        /// <summary>
        /// Tests the typical GET request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="saveResultToStorage">if set to <c>true</c> [save result to storage].</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="resultFileName">Name of the result file.</param>
        /// <param name="localSubfolder">The local subfolder.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        protected void TestGetRequest(string testMethodName, bool saveResultToStorage, string parametersLine, string inputFileName, string resultFileName, string localSubfolder,
            GetRequestInvokerDelegate requestInvoker, PropertiesTesterDelegate propertiesTester, string folder = CloudTestFolder, string storage = DefaultStorage)
        {
            this.TestRequest(testMethodName, saveResultToStorage, parametersLine, inputFileName, resultFileName, localSubfolder,
                () => this.ObtainGetResponseLength(inputFileName, saveResultToStorage ? $"{folder}/{resultFileName}" : null, requestInvoker),
                propertiesTester, folder, storage);
        }

        /// <summary>
        /// Tests the typical POST request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="saveResultToStorage">if set to <c>true</c> [save result to storage].</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="resultFileName">Name of the result file.</param>
        /// <param name="localSubfolder">The local subfolder.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        protected void TestPostRequest(string testMethodName, bool saveResultToStorage, string parametersLine, string inputFileName, string resultFileName, string localSubfolder,
            PostRequestInvokerDelegate requestInvoker, PropertiesTesterDelegate propertiesTester, string folder = CloudTestFolder, string storage = DefaultStorage)
        {
            this.TestRequest(testMethodName, saveResultToStorage, parametersLine, inputFileName, resultFileName, localSubfolder,
                () => this.ObtainPostResponseLength(folder + "/" + inputFileName, saveResultToStorage ? $"{folder}/{resultFileName}" : null, storage, requestInvoker),
                propertiesTester, folder, storage);
        }

        /// <summary>
        /// Checks the size difference.
        /// </summary>
        /// <param name="size1">The size 1.</param>
        /// <param name="size2">The size 2.</param>
        /// <param name="diffDivision">The difference division.</param>
        /// <exception cref="System.Exception">Size differs by more than {100 / diffDivision}%</exception>
        protected void CheckSizeDiff(long size1, long size2, long diffDivision = SizeDiffDivision)
        {
            long avg = (size1 + size2) / 2;
            long diffVal = avg / diffDivision;
            if (Math.Abs(size1 - size2) > diffVal)
            {
                throw new Exception($"Size differs by more than {100 / diffDivision}%: {size1} bytes VS {size2} bytes");
            }
        }

        /// <summary>
        /// Checks if input file exists.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <returns></returns>
        protected bool CheckInputFileExists(string inputFileName)
        {
            foreach (FileResponse storageFileInfo in InputTestFiles)
            {
                if (storageFileInfo.Name == inputFileName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the storage file information.
        /// </summary>
        /// <param name="folder">The folder which contains a file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="storage">The storage.</param>
        /// <returns></returns>
        protected FileResponse GetStorageFileInfo(string folder, string fileName,
            string storage)
        {
            FilesResponse fileListResponse = this.StorageApi.GetListFiles(new GetListFilesRequest(folder, storage));

            foreach (FileResponse storageFileInfo in fileListResponse.Files)
            {
                if (storageFileInfo.Name == fileName)
                {
                    return storageFileInfo;
                }
            }

            return null;
        }

        /// <summary>
        /// Fetches the input test files info.
        /// </summary>
        /// <returns></returns>
        private List<FileResponse> FetchInputTestFilesInfo()
        {
            var filesResponse = this.StorageApi.GetListFiles(new GetListFilesRequest(OriginalDataFolder, DefaultStorage));
            return filesResponse.Files;
        }

        /// <summary>
        /// Obtains the length of the typical GET request response.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="outPath">The output path to save the result.</param>
        /// <returns></returns>
        private long ObtainGetResponseLength(string inputFileName, string outPath, GetRequestInvokerDelegate requestInvoker)
        {
            using (var response = requestInvoker.Invoke(inputFileName, outPath))
            {
                if (string.IsNullOrEmpty(outPath))
                {
                    Assert.NotNull(response);
                    return response.Length;
                }

                return 0;
            }
        }

        /// <summary>
        /// Obtains the length of the typical POST request response.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="requestInvoker">The request invoker.</param>
        /// <param name="outPath">The output path to save the result.</param>
        /// <param name="storage">The storage.</param>
        /// <returns></returns>
        private long ObtainPostResponseLength(string inputPath, string outPath, string storage, PostRequestInvokerDelegate requestInvoker)
        {
            using (Stream iStream = this.StorageApi.GetDownload(new GetDownloadRequest(inputPath, null, storage)))
            {
                using (var response = requestInvoker.Invoke(iStream, outPath))
                {
                    if (string.IsNullOrEmpty(outPath))
                    {
                        Assert.NotNull(response);
                        return response.Length;
                    }

                    return 0;
                }
            }
        }

        /// <summary>
        /// Tests the typical request.
        /// </summary>
        /// <param name="testMethodName">Name of the test method.</param>
        /// <param name="saveResultToStorage">if set to <c>true</c> [save result to storage].</param>
        /// <param name="parametersLine">The parameters line.</param>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="resultFileName">Name of the result file.</param>
        /// <param name="referenceSubfolder">The result reference subfolder.</param>
        /// <param name="invokeRequestFunc">The invoke request function that returns response length.</param>
        /// <param name="propertiesTester">The properties tester.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="storage">The storage.</param>
        private void TestRequest(string testMethodName, bool saveResultToStorage, string parametersLine, string inputFileName, string resultFileName, string referenceSubfolder,
            Newtonsoft.Json.Serialization.Func<long> invokeRequestFunc, PropertiesTesterDelegate propertiesTester, string folder = CloudTestFolder, string storage = DefaultStorage)
        {
            Console.WriteLine(testMethodName);

            if (!CheckInputFileExists(inputFileName))
            {
                throw new ArgumentException(
                    $"Input file {inputFileName} doesn't exist in the specified storage folder: {folder}. Please, upload it first.");
            }

            if (!this.StorageApi.GetIsExist(new GetIsExistRequest(folder + "/" + inputFileName, null, storage)).FileExist.IsExist.Value)
            {
                var downStream = this.StorageApi.GetDownload(new GetDownloadRequest(OriginalDataFolder + "/" + inputFileName, null, storage));
                Assert.NotNull(downStream);
                var putResponse = this.StorageApi.PutCreate(new PutCreateRequest(folder + "/" + inputFileName, downStream, null, storage));
                Assert.AreEqual(HttpStatusCode.OK.ToString(), putResponse.Status.ToUpperInvariant());
            }

            bool passed = false;
            string outPath = null;
            string referencePath = CloudReferencesFolder + "/" + referenceSubfolder;

            try
            {
                Console.WriteLine(parametersLine);

                if (saveResultToStorage)
                {
                    outPath = folder + "/" + resultFileName;

                    // remove output file from the storage (if exists)
                    if (this.StorageApi.GetIsExist(new GetIsExistRequest(outPath, null, storage)).FileExist.IsExist.Value)
                    {
                        this.StorageApi.DeleteFile(new DeleteFileRequest(outPath, null, storage));
                    }
                }

                FileResponse referenceInfo = this.GetStorageFileInfo(referencePath, resultFileName, storage);
                if (referenceInfo == null)
                {
                    throw new ArgumentException(
                        $"Reference result file {resultFileName} doesn't exist in the specified storage folder: {referencePath}. Please, upload it first.");
                }

                long referenceLength = referenceInfo.Size.Value;

                long responseLength = invokeRequestFunc.Invoke();

                if (saveResultToStorage)
                {
                    FileResponse resultInfo = this.GetStorageFileInfo(folder, resultFileName, storage);
                    if (resultInfo == null)
                    {
                        throw new ArgumentException(
                            $"Result file {resultFileName} doesn't exist in the specified storage folder: {folder}. Result isn't present in the storage by an unknown reason.");
                    }

                    this.CheckSizeDiff(referenceLength, resultInfo.Size.Value);

                    ImagingResponse resultProperties =
                        this.ImagingApi.GetImageProperties(new GetImagePropertiesRequest(resultFileName, folder, storage));
                    Assert.NotNull(resultProperties);
                    ImagingResponse originalProperties =
                        this.ImagingApi.GetImageProperties(new GetImagePropertiesRequest(inputFileName, folder, storage));
                    Assert.NotNull(originalProperties);

                    propertiesTester?.Invoke(originalProperties, resultProperties);
                }
                else
                {
                    // check resulting image from response stream
                    this.CheckSizeDiff(referenceLength, responseLength);
                }

                passed = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (saveResultToStorage && !passed && this.AutoRecoverReference && this.StorageApi.GetIsExist(new GetIsExistRequest(outPath, null, storage)).FileExist.IsExist.Value)
                {
                    var moveFileResponse = this.StorageApi.PostMoveFile(new PostMoveFileRequest(outPath, referencePath + "/" + resultFileName, null, storage, storage));
                    Assert.AreEqual(HttpStatusCode.OK.ToString(), moveFileResponse.Status);
                }
                else if (saveResultToStorage && this.RemoveResult && this.StorageApi.GetIsExist(new GetIsExistRequest(outPath, null, storage)).FileExist.IsExist.Value)
                {
                    this.StorageApi.DeleteFile(new DeleteFileRequest(outPath, null, storage));
                }

                Console.WriteLine($"Test passed: {passed}");
            }
        }

        #endregion
    }
}
