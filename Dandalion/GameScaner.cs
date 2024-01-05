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

        public static List<string> GetGameList()
        {
            return Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), gameFolder)).
                Select(f => Path.GetFileName(f))
                .ToList();
        }
    }
}