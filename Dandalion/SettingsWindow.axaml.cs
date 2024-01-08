using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<TextBlock>("SettingsProfileTextBlock")!.PointerPressed += SettingsProfile_OnPointerPressed;
        this.FindControl<TextBlock>("LogoutTextBlock")!.PointerPressed += LogoutTextBlock_OnPointerPressed;
        this.FindControl<TextBlock>("DeleteAccountTextBlock")!.PointerPressed += DeleteAccountTextBlock_OnPointerPressed;
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

    private void SettingsProfile_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("SettingsProfileTextBlock"))) return;
        var settingsProfileWindow = new SettingsProfileWindow();
        settingsProfileWindow.Show();
        Close();
        e.Handled = true;
    }

    private void LogoutTextBlock_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("LogoutTextBlock"))) return;
        var mainWindow= new MainWindow();
        mainWindow.Show();
        Close();
        e.Handled = true;
    }

    private void DeleteAccountTextBlock_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("DeleteAccountTextBlock"))) return;
        var mainWindow= new MainWindow();
        mainWindow.Show();
        Close();
        e.Handled = true;
    }
}