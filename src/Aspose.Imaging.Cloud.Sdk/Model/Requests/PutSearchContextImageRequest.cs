// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="PutSearchContextImageRequest.cs">
//   Copyright (c) 2019 Aspose Pty Ltd. All rights reserved.
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
  /// Request model for <see cref="Aspose.Imaging.Cloud.Sdk.ImagingApi.PutSearchContextImage" /> operation.
  /// </summary>  
  public class PutSearchContextImageRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutSearchContextImageRequest"/> class.
        /// </summary>        
        public PutSearchContextImageRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PutSearchContextImageRequest"/> class.
        /// </summary>
        /// <param name="searchContextId">Search context identifier.</param>
        /// <param name="imageId">Image identifier.</param>
        /// <param name="imageData">Input image</param>
        /// <param name="folder">Folder.</param>
        /// <param name="storage">Storage</param>
        public PutSearchContextImageRequest(string searchContextId, string imageId, System.IO.Stream imageData = null, string folder = null, string storage = null)             
        {
            this.searchContextId = searchContextId;
            this.imageId = imageId;
            this.imageData = imageData;
            this.folder = folder;
            this.storage = storage;
        }
		
        /// <summary>
        /// Search context identifier.
        /// </summary>  
        public string searchContextId { get; set; }

        /// <summary>
        /// Image identifier.
        /// </summary>  
        public string imageId { get; set; }

        /// <summary>
        /// Input image
        /// </summary>  
        public System.IO.Stream imageData { get; set; }

        /// <summary>
        /// Folder.
        /// </summary>  
        public string folder { get; set; }

        /// <summary>
        /// Storage
        /// </summary>  
        public string storage { get; set; }
  }
}
