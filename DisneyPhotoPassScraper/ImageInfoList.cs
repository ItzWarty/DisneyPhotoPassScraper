using System.Collections.Generic;
using System.Xml.Serialization;

namespace DisneyPhotoPassScraper {
   [XmlRoot(Namespace = "urn:Imaging-StoreFront-v3.6", ElementName = "ImageInfoList")]
   public class ImageInfoList {
      [XmlElement("ImageInfo")]
      public List<ImageInfo> Items { get; } = new List<ImageInfo>();
   }
}