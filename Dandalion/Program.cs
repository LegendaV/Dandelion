using Avalonia;
using System;
using System.IO;
using System.Linq;

namespace Dandalion;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    /*
    public static void Main1()
    {
        GameLoader.Load("https://github.com/LegendaV/LightAndDarkness", "d226e01e6278605f5383af38561edf806eedf665");
        var downloadedGames = GameScaner.GetGameList();
        var game = downloadedGames.Where(g => g.StartsWith("LightAndDarkness")).First();
        GameRunner.Run(game, "Light and Darkness.exe"); 
    }
    */
}