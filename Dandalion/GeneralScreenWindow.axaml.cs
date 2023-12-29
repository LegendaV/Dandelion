using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class GeneralScreenWindow : Window
{
    public GeneralScreenWindow()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<TextBlock>("PlayGame")!.PointerPressed += PlayGame_OnPointerPressed;
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
        var favoriteGamesWindow = new FavoriteGamesWindow();
        favoriteGamesWindow.Show();
        Close();
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

    private void PlayGame_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        //if (!Equals(sender, this.FindControl<TextBlock>("PlayGame"))) return;
        //запуск игры
        throw new System.NotImplementedException();
        //e.Handled = true;
    }
}