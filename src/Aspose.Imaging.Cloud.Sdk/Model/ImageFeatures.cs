// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ImageFeatures.cs">
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
  /// Image features.
  /// </summary>  
  public class ImageFeatures 
  {                       
        /// <summary>
        /// Gets the image identifier.
        /// </summary>  
        public string ImageId { get; set; }

        /// <summary>
        /// Gets the features count.
        /// </summary>  
        public int? FeaturesCount { get; set; }

        /// <summary>
        /// Gets the feature length in bits.
        /// </summary>  
        public int? FeatureLengthInBits { get; set; }

        /// <summary>
        /// Gets the features.
        /// </summary>  
        public byte[] Features { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class ImageFeatures {\n");
          sb.Append("  ImageId: ").Append(this.ImageId).Append("\n");
          sb.Append("  FeaturesCount: ").Append(this.FeaturesCount).Append("\n");
          sb.Append("  FeatureLengthInBits: ").Append(this.FeatureLengthInBits).Append("\n");
          sb.Append("  Features: ").Append(this.Features).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
