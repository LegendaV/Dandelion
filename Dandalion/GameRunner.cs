using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandalion
{
    public static class GameRunner
    {
        private static string gameFolder = "Games";

        public static void Run(string path, string exeFileName)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), gameFolder, path);
            var exeFiles = Directory.GetFiles(fullPath, "*.exe");

            exeFiles = exeFiles.Where(f => Path.GetFileName(f).ToLower() == exeFileName.ToLower()).ToArray();

            if (exeFiles.Length == 0)
            {
                return;
            }

            try
            {
                var process = new Process();
                process.StartInfo.FileName = exeFiles.First();

                process.Start();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при запуске exe-файла: " + ex.Message);
            }
        }
    }
}
