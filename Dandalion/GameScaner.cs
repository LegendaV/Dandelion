using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandalion
{
    public static class GameScaner
    {
        private static string gameFolder = "Games";
        public static bool FileExists() => File.Exists("config.txt");

        public static void CreateFile()
        {
            if (!File.Exists("config.txt"))
                File.Create("config.txt");
        }

        public static bool CheckGame(string nameGame)
        {
            var games = GetGameList();
            return games.Any(game => game.StartsWith(nameGame));
        }

        public static List<string> GetGameList()
        {
            return Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), gameFolder))
                .Select(f => Path.GetFileName(f))
                .ToList();
        }
    }
}