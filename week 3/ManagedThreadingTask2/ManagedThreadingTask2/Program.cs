using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace Solution
{
    internal class Program
    {
        public const string UrlPath = "https://jsonplaceholder.typicode.com/photos";
        public const string PhotosFilename = "photos.json";
        public static void Main()
        {
            Console.WriteLine("Start");
            CheckInfoJson();
            GetPhotoUrls();
        }
        public static void Downloader(string path)
        {
            var client = new WebClient();  //have some problems with web client
            try
            {
                client.DownloadFile(path, PhotosFilename);
                client.Dispose();
            }
            catch
            {
                Console.WriteLine("error occured");
            }
        }

        public static void CheckInfoJson()
        {
            if (File.Exists(PhotosFilename))
            {
                Console.WriteLine("File already exists");
            }
            else
            {
                Downloader(UrlPath);
            }
        }

        public static List<string> GetPhotoUrls()
        {
            var strings = new List<String>();
            JObject jsonObject = JObject.Parse(File.ReadAllText(PhotosFilename));

            Console.WriteLine(jsonObject.Count);
            return strings;
        }

        public static JObject ReadJsonFile(string path)
        {
            StreamReader file = File.OpenText(path);
            JsonTextReader reader = new(file);
            JObject jObject = (JObject)JToken.ReadFrom(reader);

            return jObject;
        }
    }
}