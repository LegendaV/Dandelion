using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class SettingsProfileWindow : Window
{
    public SettingsProfileWindow()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<TextBlock>("SettingsTextBlock")!.PointerPressed += Settings_OnPointerPressed;
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
    
    private void HeartIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("HeartIcon"))) return;
        switch (GeneralScreenWindow.HaveLad)
        {
            case true when GeneralScreenWindow.HaveHex:
            {
                var ladandhex = new LADandHEX();
                ladandhex.Show();
                Close();
                break;
            }
            case true when !GeneralScreenWindow.HaveHex:
            {
                var lad = new LAD();
                lad.Show();
                Close();
                break;
            }
            case false when GeneralScreenWindow.HaveHex:
            {
                var hex = new HEX();
                hex.Show();
                Close();
                break;
            }
            case false when !GeneralScreenWindow.HaveHex:
            {
                var favoriteGamesWindow = new FavoriteGamesWindow();
                favoriteGamesWindow.Show();
                Close();
                break;
            }
            default:
            {
                var favoriteGamesWindow = new FavoriteGamesWindow();
                favoriteGamesWindow.Show();
                Close();
                break;
            }
        }
        e.Handled = true;
    }

    private void Settings_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("SettingsTextBlock"))) return;
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
        Close();
        e.Handled = true;
    }
}