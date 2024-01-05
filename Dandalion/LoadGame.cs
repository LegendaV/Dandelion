using System.IO;
using System.IO.Compression;
using System.Net;

namespace Dandalion
{
    public static class GameLoader
    {
        private static string outputFolder = "Games";
        public static void Load(string repositoryUrl, string commitSha)
        {
            string downloadUrl = $"{repositoryUrl}/archive/{commitSha}.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadUrl, "temp.zip");
                ZipFile.ExtractToDirectory("temp.zip", Path.Combine(Directory.GetCurrentDirectory(), outputFolder));
                File.Delete("temp.zip");
            }
        }
    }
}