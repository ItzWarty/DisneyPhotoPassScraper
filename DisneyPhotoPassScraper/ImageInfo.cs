using System;
using System.Xml.Serialization;

namespace DisneyPhotoPassScraper {
   public class ImageInfo {
      // Not a Guid as can be "StockPhoto"
      [XmlAttribute("account")]
      public string AccountId { get; set; }

      [XmlAttribute("id")]
      public Guid ImageId { get; set; }

      [XmlAttribute("ordinality")]
      public int Ordinality { get; set; }

      [XmlAttribute("updatedOn")]
      public DateTime UpdatedOn { get; set; }

      [XmlAttribute("width")]
      public int Width { get; set; }

      [XmlAttribute("height")]
      public int Height { get; set; }

      [XmlAttribute("isEdited")]
      public string IsEditedString { get; set; }

      public bool IsEdited => bool.Parse(IsEditedString);

      [XmlAttribute("location")]
      public string Location { get; set; }

      [XmlAttribute("locationCode")]
      public string LocationCode { get; set; }

      [XmlAttribute("subLocation")]
      public string SubLocation { get; set; }

      [XmlAttribute("expiresOn")]
      public DateTime ExpiresOn { get; set; }

      [XmlAttribute("type")]
      public string Type { get; set; }

      [XmlAttribute("album")]
      public string Album { get; set; }

      [XmlAttribute("category")]
      public string Category { get; set; }

      [XmlAttribute("capturedOn")]
      public DateTime CapturedOn { get; set; }
   }
}
