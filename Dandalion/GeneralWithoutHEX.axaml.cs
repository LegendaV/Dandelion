using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class GeneralWithoutHEX : Window
{
    public static bool HaveLad = GameScaner.CheckGame("LightAndDarkness");
    public static bool HaveHex = GameScaner.FileExists();

    public GeneralWithoutHEX()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<TextBlock>("LoadGameLAD")!.PointerPressed += LoadGameLAD_OnPointerPressed;
    }

    private void ProfileIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("ProfileIcon"))) return;
        var profileWindow = new ProfileWindow();
        profileWindow.Show();
        Close();
        e.Handled = true;
    }

    private void HeartIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("HeartIcon"))) return;
        switch (HaveLad)
        {
            case true when HaveHex:
            {
                var ladandhex = new LADandHEX();
                ladandhex.Show();
                Close();
                break;
            }
            case true when !HaveHex:
            {
                var lad = new LAD();
                lad.Show();
                Close();
                break;
            }
            case false when HaveHex:
            {
                var hex = new HEX();
                hex.Show();
                Close();
                break;
            }
            case false when !HaveHex:
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

    private void LoadGameLAD_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("LoadGameLAD"))) return;
        if (HaveLad) return;
        GameLoader.Load("https://github.com/LegendaV/LightAndDarkness", "d226e01e6278605f5383af38561edf806eedf665");
        HaveLad = true;
        var window = new Window
        {
            Title = "Message",
            Width = 300,
            Height = 100,
            Content = new TextBlock
            {
                Text = "LightAndDarkness скачан!",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            }
        };
        window.Show();
        e.Handled = true;
    }
}