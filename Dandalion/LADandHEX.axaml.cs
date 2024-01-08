using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class LADandHEX : Window
{
    public LADandHEX()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<TextBlock>("PlayGameLAD")!.PointerPressed += PlayGameLAD_OnPointerPressed;
    }

    private void ProfileIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("ProfileIcon"))) return;
        var profileWindow = new ProfileWindow();
        profileWindow.Show();
        Close();
        e.Handled = true;
    }
    
    private void HomeIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("HomeIcon"))) return;
        if (GameScaner.FileExists())
        {
            var generalScreenWindow = new GeneralScreenWindow();
            generalScreenWindow.Show();
            Close();
        }
        else
        {
            var generalWithout = new GeneralWithoutHEX();
            generalWithout.Show();
            Close();
        }
        e.Handled = true;
    }
    
    private void SettingIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("SettingIcon"))) return;
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
        Close();
        e.Handled = true;
    }

    private void PlayGameLAD_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("PlayGameLAD"))) return;
        var downloadedGames = GameScaner.GetGameList();
        var game = downloadedGames.Where(g => g.StartsWith("LightAndDarkness")).First();
        GameRunner.Run(game, "Light and Darkness.exe"); 
        e.Handled = true;
    }
    
    private void PlayGameHEX_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("PlayGameHEX"))) return;
        var downloadedGames = GameScaner.GetGameList();
        var game = downloadedGames.Where(g => g.StartsWith("Hex")).First();
        GameRunner.Run(game, "Hex.exe");
        e.Handled = true;
    }
}