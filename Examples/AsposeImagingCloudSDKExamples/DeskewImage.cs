﻿//todo uncomment when new SDK version is deployed
//// --------------------------------------------------------------------------------------------------------------------
//// <copyright company="Aspose" file="DeskewImage.cs">
////   Copyright (c) 2018-2019 Aspose Pty Ltd. All rights reserved.
//// </copyright>
//// <summary>
////   Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
//// 
////  The above copyright notice and this permission notice shall be included in all
////  copies or substantial portions of the Software.
//// 
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
////  SOFTWARE.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------

//using Aspose.Imaging.Cloud.Sdk.Api;
//using Aspose.Imaging.Cloud.Sdk.Model.Requests;
//using System;
//using System.IO;

//namespace AsposeImagingCloudSDKExamples
//{
//    /// <summary>
//    /// Deskew image example.
//    /// </summary>
//    /// <seealso cref="AsposeImagingCloudSDKExamples.ImagingBase" />
//    class DeskewImage : ImagingBase
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="DeskewImage"/> class.
//        /// </summary>
//        /// <param name="imagingApi">The imaging API.</param>
//        public DeskewImage(ImagingApi imagingApi) : base(imagingApi)
//        {
//            PrintHeader("Deskew image example:");
//        }

//        /// <summary>
//        /// Gets the name of the example image file.
//        /// </summary>
//        /// <value>
//        /// The name of the example image file.
//        /// </value>
//        /// <remarks>
//        /// Input formats could be one of the following:
//        /// BMP, GIF, DJVU, WMF, EMF, JPEG, JPEG2000, PSD, TIFF, WEBP, PNG, DICOM, CDR, CMX, ODG, DNG and SVG
//        /// </remarks>
//        protected override string SampleImageFileName => "DeskewpSampleImage.bmp";

//        /// <summary>
//        /// Deskews the image from cloud storage.
//        /// </summary>
//        public void DeskewImageFromStorage()
//        {
//            Console.WriteLine("Deskew the image from cloud storage");

//            UploadSampleImageToCloud();

//            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Deskew 
//            // for possible output formats
//            string format = "jpg"; // Resulting image format.
//            bool resizeProportionally = true;
//            string bkColor = "green";
//            string folder = CloudPath; // Input file is saved at the Examples folder in the storage
//            string storage = null; // We are using default Cloud Storage

//            var request = new DeskewImageRequest(SampleImageFileName, format, resizeProportionally, bkColor, folder, storage);

//            Console.WriteLine($"Call DeskewImage with params:resizeProportionally:{resizeProportionally},bkColor:{bkColor}");

//            using (Stream updatedImage = this.ImagingApi.DeskewImage(request))
//            {
//                SaveUpdatedImageToOutput(updatedImage, false, format);
//            }

//            Console.WriteLine();
//        }

//        /// <summary>
//        /// Deskew an existing image, and upload updated image to Cloud Storage.
//        /// </summary>
//        public void DeskewImageAndUploadToStorage()
//        {
//            Console.WriteLine("Deskews the image and upload to cloud storage");

//            UploadSampleImageToCloud();

//            // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Deskew 
//            // for possible output formats
//            string format = "jpg"; // Resulting image format.
//            bool resizeProportionally = true;
//            string bkColor = "green";
//            string folder = CloudPath; // Input file is saved at the Examples folder in the storage
//            string storage = null; // We are using default Cloud Storage

//            var request = new DeskewImageRequest(SampleImageFileName, format, resizeProportionally, bkColor, folder, storage);

//            Console.WriteLine($"Call DeskewImage with params:resizeProportionally:{resizeProportionally},bkColor:{bkColor}");

//            using (Stream updatedImage = this.ImagingApi.DeskewImage(request))
//            {
//                UploadImageToCloud(GetModifiedSampleImageFileName(false, format), updatedImage);
//            }

//            Console.WriteLine();
//        }

//        /// <summary>
//        /// Deskews an image. Image data is passed in a request stream.
//        /// </summary>
//        public void CreateDeskewedImageFromRequestBody()
//        {
//            Console.WriteLine("Deskews the image from request body");

//            using (FileStream inputImageStream = File.OpenRead(Path.Combine(ExampleImagesFolder, SampleImageFileName)))
//            {
//                // Please refer to https://docs.aspose.cloud/display/imagingcloud/Supported+File+Formats#SupportedFileFormats-Deskew
//                // for possible output formats
//                string format = "jpg"; // Resulting image format.
//                bool resizeProportionally = true;
//                string bkColor = "green";
//                string storage = null; // We are using default Cloud Storage
//                string outPath = null; // Path to updated file (if this is empty, response contains streamed image)

//                var request = new CreateDeskewedImageRequest(inputImageStream, format, resizeProportionally, bkColor, outPath, storage);

//                Console.WriteLine($"Call DeskewImage with params:resizeProportionally:{resizeProportionally},bkColor:{bkColor}");

//                using (Stream updatedImage = this.ImagingApi.CreateDeskewedImage(request))
//                {
//                    SaveUpdatedImageToOutput(updatedImage, true, format);
//                }
//            }

//            Console.WriteLine();
//        }
//    }
//}