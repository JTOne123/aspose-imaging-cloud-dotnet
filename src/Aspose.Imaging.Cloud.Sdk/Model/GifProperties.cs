// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="GifProperties.cs">
//   Copyright (c) 2018 Aspose Pty Ltd.
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

namespace Aspose.Imaging.Cloud.Sdk.Model 
{
  using System;  
  using System.Collections;
  using System.Collections.Generic;
  using System.Runtime.Serialization;
  using System.Text;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Converters;

  /// <summary>
  /// Represents information about image in GIF format.
  /// </summary>  
  public class GifProperties 
  {                       
        /// <summary>
        /// Gets or sets the background color.
        /// </summary>  
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether background color is used.
        /// </summary>  
        public bool? HasBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether image has trailer.
        /// </summary>  
        public bool? HasTrailer { get; set; }

        /// <summary>
        /// Gets or sets the pixel aspect ratio.
        /// </summary>  
        public int? PixelAspectRatio { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class GifProperties {\n");
          sb.Append("  BackgroundColor: ").Append(this.BackgroundColor).Append("\n");
          sb.Append("  HasBackgroundColor: ").Append(this.HasBackgroundColor).Append("\n");
          sb.Append("  HasTrailer: ").Append(this.HasTrailer).Append("\n");
          sb.Append("  PixelAspectRatio: ").Append(this.PixelAspectRatio).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}