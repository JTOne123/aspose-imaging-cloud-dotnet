// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="TiffApiTests.cs">
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

using Aspose.Imaging.Cloud.Sdk.Test.Base;

namespace Aspose.Imaging.Cloud.Sdk.Test.Api
{
	using System;
	using System.IO;
	using System.Net;
	using NUnit.Framework;

	using Com.Aspose.Storage.Model;
	
	using Aspose.Imaging.Cloud.Sdk.Model;
	using Aspose.Imaging.Cloud.Sdk.Model.Requests;
	
    /// <summary>
    ///  Class for testing TiffApi
    /// </summary>
    [TestFixture]
    public class TiffApiTests : ApiTester
    {
        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
			// you can pass your own parameters here
            this.CreateApiInstances();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test GetTiffToFax
        /// </summary>
        [Test]
        public void GetTiffToFaxTest()
        {
            string name = "test.tiff";
            string outName = $"{name}_fax.tiff";
            string folder = CloudTestFolder;
            string storage = DefaultStorage;

            this.TestGetRequest(
                "GetTiffToFaxTest",
                true,
                $"Input image: {name}",
                name,
                outName,
                "Tiff",
                delegate (string fileName, string outPath)
                {
                    var request = new GetTiffToFaxRequest(name, storage, folder, outPath);
                    return ImagingApi.GetTiffToFax(request);
                },
                delegate (ImagingResponse originalProperties, ImagingResponse resultProperties)
                {
                    Assert.NotNull(resultProperties.TiffProperties);
                    Assert.AreEqual(resultProperties.BitsPerPixel, 1);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.VerticalResolution), 196);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.HorizontalResolution), 204);
                    Assert.AreEqual(resultProperties.Width, 1728);
                    Assert.AreEqual(resultProperties.Height, 2200);
                },
                folder,
                storage);
        }

        /// <summary>
        /// Test GetImageTiff
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        [TestCase(true)]
        [TestCase(false)]
        public void GetImageTiffTest(bool saveResultToStorage)
        {
            string name = "test.tiff";
            string compression = "adobedeflate";
            string resolutionUnit = "inch";
            int bitDepth = 1;
            double horizontalResolution = 150;
            double verticalResolution = 150;
            bool? fromScratch = null;
            string outName = $"{name}_specific.tiff";
            string folder = CloudTestFolder;
            string storage = DefaultStorage;

            this.TestGetRequest(
                "GetImageTiffTest",
                saveResultToStorage,
                $"Input image: {name}; Compression: {compression}; Bit depth: {bitDepth}; Horizontal resolution: {horizontalResolution}; Vertical resolution: {verticalResolution}",
                name,
                outName,
                "Tiff",
                delegate (string fileName, string outPath)
                {
                    var request = new GetImageTiffRequest(name, compression, resolutionUnit, bitDepth, fromScratch, horizontalResolution, verticalResolution, outPath,
                        folder, storage);
                    return ImagingApi.GetImageTiff(request);
                },
                delegate (ImagingResponse originalProperties, ImagingResponse resultProperties)
                {
                    Assert.NotNull(resultProperties.TiffProperties);
                    Assert.AreEqual(resultProperties.BitsPerPixel, bitDepth > 1 ? bitDepth * 4 : bitDepth);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.VerticalResolution), (int)verticalResolution);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.HorizontalResolution), (int)horizontalResolution);

                    Assert.NotNull(originalProperties.TiffProperties);
                    Assert.AreEqual(originalProperties.TiffProperties.Frames.Count, resultProperties.TiffProperties.Frames.Count);
                    Assert.AreEqual(originalProperties.Width, resultProperties.Width);
                    Assert.AreEqual(originalProperties.Height, resultProperties.Height);
                },
                folder,
                storage);
        }

        /// <summary>
        /// Test PostProcessTiff
        /// </summary>
        /// <param name="saveResultToStorage">If result should be saved to storage</param>
        [TestCase(true)]
        [TestCase(false)]
        public void PostImageTiffTest(bool saveResultToStorage)
        {
            string name = "test.tiff";
            string compression = "adobedeflate";
            string resolutionUnit = "inch";
            int bitDepth = 1;
            double horizontalResolution = 150;
            double verticalResolution = 150;
            bool? fromScratch = null;
            string outName = $"{name}_specific.tiff";
            string folder = CloudTestFolder;
            string storage = DefaultStorage;

            this.TestPostRequest(
                "PostImageTiffTest",
                saveResultToStorage,
                $"Input image: {name}; Compression: {compression}; Bit depth: {bitDepth}; Horizontal resolution: {horizontalResolution}; Vertical resolution: {verticalResolution}",
                name,
                outName,
                "Tiff",
                delegate (Stream inputStream, string outPath)
                {
                    var request = new PostImageTiffRequest(inputStream, compression, resolutionUnit, bitDepth, fromScratch, horizontalResolution, verticalResolution, outPath);
                    return ImagingApi.PostImageTiff(request);
                },
                delegate (ImagingResponse originalProperties, ImagingResponse resultProperties)
                {
                    Assert.NotNull(resultProperties.TiffProperties);
                    Assert.AreEqual(resultProperties.BitsPerPixel, bitDepth > 1 ? bitDepth * 4 : bitDepth);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.VerticalResolution), (int)verticalResolution);
                    Assert.AreEqual((int)Math.Ceiling((double)resultProperties.HorizontalResolution), (int)horizontalResolution);

                    Assert.NotNull(originalProperties.TiffProperties);
                    Assert.AreEqual(originalProperties.TiffProperties.Frames.Count, resultProperties.TiffProperties.Frames.Count);
                    Assert.AreEqual(originalProperties.Width, resultProperties.Width);
                    Assert.AreEqual(originalProperties.Height, resultProperties.Height);
                },
                folder,
                storage);
        }

        /// <summary>
        /// Test PostTiffAppend
        /// </summary>
        public void PostTiffAppendTest()
        {
            bool passed = false;
            Console.WriteLine("PostTiffAppendTest");

            string inputFileName = "test.tiff";
            string folder = CloudTestFolder;

            if (!CheckInputFileExists(inputFileName))
            {
                throw new ArgumentException(
                    $"Input file {inputFileName} doesn't exist in the specified storage folder: {folder}. Please, upload it first.");
            }

            string resultFileName = $"{inputFileName}_merged.tiff";
            string outPath = null;
            string inputPath = CloudTestFolder + "/" + inputFileName;
            string storage = DefaultStorage;
            string referencePath = CloudReferencesFolder + "/Tiff";

            try
            {
                Console.WriteLine($"Input image: {inputFileName}");

                outPath = CloudTestFolder + "/" + resultFileName;

                // remove output file from the storage (if exists)
                if (StorageApi.GetIsExist(outPath, "", storage).FileExist.IsExist)
                {
                    StorageApi.DeleteFile(outPath, "", storage);
                }

                var storageResponseMessage = StorageApi.GetDownload(inputPath, "", storage);
                Assert.NotNull(storageResponseMessage);
                Assert.AreEqual(storageResponseMessage.Code, (int)HttpStatusCode.OK);
                storageResponseMessage = StorageApi.PutCreate(outPath, "", storage, storageResponseMessage.ResponseStream);
                Assert.NotNull(storageResponseMessage);
                Assert.AreEqual(storageResponseMessage.Code, (int)HttpStatusCode.OK);
                Assert.IsTrue(StorageApi.GetIsExist(outPath, "", storage).FileExist.IsExist);

                var request = new PostTiffAppendRequest(resultFileName, inputFileName, storage, folder);
                var response = ImagingApi.PostTiffAppend(request);
                Assert.NotNull(response);
                Assert.AreEqual((int)response.Code, (int)HttpStatusCode.OK);

                FilesList.StorageFileInfo referenceInfo = GetStorageFileInfo(referencePath, resultFileName, storage);
                if (referenceInfo == null)
                {
                    throw new ArgumentException(
                        $"Reference result file {resultFileName} doesn't exist in the specified storage folder: {referencePath}. Please, upload it first.");
                }

                long referenceLength = referenceInfo.Size;

                FilesList.StorageFileInfo resultInfo = GetStorageFileInfo(folder, resultFileName, storage);
                if (resultInfo == null)
                {
                    throw new ArgumentException(
                        $"Result file {resultFileName} doesn't exist in the specified storage folder: {folder}. Result isn't present in the storage by an unknown reason.");
                }

                this.CheckSizeDiff(referenceLength, resultInfo.Size);

                ImagingResponse resultProperties =
                    ImagingApi.GetImageProperties(new GetImagePropertiesRequest(resultFileName, folder, storage));
                Assert.NotNull(resultProperties);
                ImagingResponse originalProperties =
                    ImagingApi.GetImageProperties(new GetImagePropertiesRequest(inputFileName, folder, storage));
                Assert.NotNull(originalProperties);

                Assert.NotNull(resultProperties.TiffProperties);
                Assert.NotNull(originalProperties.TiffProperties);
                Assert.AreEqual(originalProperties.TiffProperties.Frames.Count * 2, resultProperties.TiffProperties.Frames.Count);
                Assert.AreEqual(originalProperties.Width, resultProperties.Width);
                Assert.AreEqual(originalProperties.Height, resultProperties.Height);

                passed = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (this.RemoveResult && StorageApi.GetIsExist(outPath, "", storage).FileExist.IsExist)
                {
                    StorageApi.DeleteFile(outPath, "", storage);
                }

                Console.WriteLine($"Test passed: {passed}");
            }
        }
    }
}
