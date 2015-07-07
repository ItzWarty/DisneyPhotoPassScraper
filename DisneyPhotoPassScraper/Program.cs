using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml.Serialization;

namespace DisneyPhotoPassScraper {
   class Program {
      private static readonly WebClient wc = new WebClient();

      static void Main() {
         Console.WriteLine("Photopass Scraper by ItzWarty 6 July 2015 licensed under GPLv3.");
         Console.WriteLine("Obtain your AccountId from the 'did' cookie on the photo pass website.");
         Console.WriteLine("Delete imageList.xml next to images directory if there are new photos to scrape.");
         Console.WriteLine();

         Environment.CurrentDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
         Directory.CreateDirectory("output");

         Console.Write("AccountId?: ");
         var accountId = Guid.Parse(Console.ReadLine());
         var accountOutputPath = Path.Combine("output", accountId.ToString());
         Directory.CreateDirectory(accountOutputPath);

         var imageList = GetImageList(accountOutputPath, accountId);
         Console.WriteLine();

         Console.WriteLine("Pulling " + imageList.Items.Count + " images!");
         var imagesOutputPath = Path.Combine(accountOutputPath, "images");
         Directory.CreateDirectory(imagesOutputPath);

         foreach (var image in imageList.Items) {
            DownloadImage(imagesOutputPath, image);
         }
         Console.WriteLine();
         Console.WriteLine("Done!");
      }

      // https://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
      public static long GetUnixTimeMillis() {
         TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
         TimeSpan unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
         return (long)unixTicks.TotalMilliseconds;
      }

      public static ImageInfoList GetImageList(string accountDirectory, Guid accountId) {
         var kImageListCache = "imageList.xml";
         var imageListCachePath = Path.Combine(accountDirectory, kImageListCache);
         if (!File.Exists(imageListCachePath)) {
            Console.Write("Downloading Image List: ");
            var data = wc.DownloadData("http://www.disneyphotopass.com/api/photostore/getImageList.aspx?AccountId=" + accountId + "&type=ALL&cacheKiller=" + GetUnixTimeMillis());
            File.WriteAllBytes(imageListCachePath, data);
            Console.WriteLine("Done!");
         } else {
            Console.WriteLine("Have Image List Cached!");
         }
         XmlSerializer xs = new XmlSerializer(typeof(ImageInfoList));
         using (var fs = File.Open(imageListCachePath, FileMode.Open)) {
            return (ImageInfoList)xs.Deserialize(fs);
         }
      }

      private static void DownloadImage(string imagesDirectory, ImageInfo image) {
         var filePath = Path.Combine(imagesDirectory, image.ImageId + ".jpg");
         if (!File.Exists(filePath)) {
            Console.Write("Downloading " + image.ImageId + ": ");
            var data = wc.DownloadData("http://www.disneyphotopass.com/api/photostore/Getlowresimage.pix?ImageID=" + image.ImageId);
            File.WriteAllBytes(filePath, data);
            Console.WriteLine("Done!");
         } else {
            Console.WriteLine("Have " + image.ImageId + ".");
         }
         File.SetCreationTime(filePath, image.CapturedOn);
         File.SetLastWriteTime(filePath, image.UpdatedOn);
      }
   }
}
