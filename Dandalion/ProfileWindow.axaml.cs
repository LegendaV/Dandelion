using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class ProfileWindow : Window
{
    public ProfileWindow()
    {
        InitializeComponent();
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<Button>("AddGame")!.Click += AddGame_OnClick;
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
    
    private void SettingIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("SettingIcon"))) return;
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
        Close();
        e.Handled = true;
    }

    private void AddGame_OnClick(object? sender, RoutedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Button>("AddGame"))) return;
        var addGameWindow = new AddGameWindow();
        addGameWindow.Show();
        Close();
        e.Handled = true;
    }
}