// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="CreateImageFrameRangeRequest.cs">
//   Copyright (c) 2018-2020 Aspose Pty Ltd. All rights reserved.
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

namespace Aspose.Imaging.Cloud.Sdk.Model.Requests 
{
  using Aspose.Imaging.Cloud.Sdk.Model; 

  /// <summary>
  /// Request model for <see cref="Aspose.Imaging.Cloud.Sdk.Api.ImagingApi.CreateImageFrameRange" /> operation.
  /// </summary>  
  public class CreateImageFrameRangeRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateImageFrameRangeRequest"/> class.
        /// </summary>        
        public CreateImageFrameRangeRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateImageFrameRangeRequest"/> class.
        /// </summary>
        /// <param name="imageData">Input image</param>
        /// <param name="startFrameId">Index of the first frame in range.</param>
        /// <param name="endFrameId">Index of the last frame in range.</param>
        /// <param name="newWidth">New width.</param>
        /// <param name="newHeight">New height.</param>
        /// <param name="x">X position of start point for cropping rectangle.</param>
        /// <param name="y">Y position of start point for cropping rectangle.</param>
        /// <param name="rectWidth">Width of cropping rectangle.</param>
        /// <param name="rectHeight">Height of cropping rectangle.</param>
        /// <param name="rotateFlipMethod">RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is RotateNoneFlipNone.</param>
        /// <param name="saveOtherFrames">If result will include all other frames or just a specified frame.</param>
        /// <param name="outPath">Path to updated file (if this is empty, response contains streamed image).</param>
        /// <param name="storage">Your Aspose Cloud Storage name.</param>
        public CreateImageFrameRangeRequest(System.IO.Stream imageData, int? startFrameId, int? endFrameId, int? newWidth = null, int? newHeight = null, int? x = null, int? y = null, int? rectWidth = null, int? rectHeight = null, string rotateFlipMethod = null, bool? saveOtherFrames = null, string outPath = null, string storage = null)             
        {
            this.imageData = imageData;
            this.startFrameId = startFrameId;
            this.endFrameId = endFrameId;
            this.newWidth = newWidth;
            this.newHeight = newHeight;
            this.x = x;
            this.y = y;
            this.rectWidth = rectWidth;
            this.rectHeight = rectHeight;
            this.rotateFlipMethod = rotateFlipMethod;
            this.saveOtherFrames = saveOtherFrames;
            this.outPath = outPath;
            this.storage = storage;
        }
        
        /// <summary>
        /// Input image
        /// </summary>  
        public System.IO.Stream imageData { get; set; }

        /// <summary>
        /// Index of the first frame in range.
        /// </summary>  
        public int? startFrameId { get; set; }

        /// <summary>
        /// Index of the last frame in range.
        /// </summary>  
        public int? endFrameId { get; set; }

        /// <summary>
        /// New width.
        /// </summary>  
        public int? newWidth { get; set; }

        /// <summary>
        /// New height.
        /// </summary>  
        public int? newHeight { get; set; }

        /// <summary>
        /// X position of start point for cropping rectangle.
        /// </summary>  
        public int? x { get; set; }

        /// <summary>
        /// Y position of start point for cropping rectangle.
        /// </summary>  
        public int? y { get; set; }

        /// <summary>
        /// Width of cropping rectangle.
        /// </summary>  
        public int? rectWidth { get; set; }

        /// <summary>
        /// Height of cropping rectangle.
        /// </summary>  
        public int? rectHeight { get; set; }

        /// <summary>
        /// RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is RotateNoneFlipNone.
        /// </summary>  
        public string rotateFlipMethod { get; set; }

        /// <summary>
        /// If result will include all other frames or just a specified frame.
        /// </summary>  
        public bool? saveOtherFrames { get; set; }

        /// <summary>
        /// Path to updated file (if this is empty, response contains streamed image).
        /// </summary>  
        public string outPath { get; set; }

        /// <summary>
        /// Your Aspose Cloud Storage name.
        /// </summary>  
        public string storage { get; set; }
  }
}
