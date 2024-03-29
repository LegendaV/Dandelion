﻿using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Dandalion;

public partial class HEX : Window
{
    public HEX()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<TextBlock>("PlayGameHEX")!.PointerPressed += PlayGameHEX_OnPointerPressed;
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
        var generalScreenWindow = new GeneralScreenWindow();
        generalScreenWindow.Show();
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

    private void PlayGameHEX_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<TextBlock>("PlayGameHEX"))) return;
        var downloadedGames = GameScaner.GetGameList();
        var game = downloadedGames.Where(g => g.StartsWith("Hex")).First();
        GameRunner.Run(game, "Hex.exe");
        e.Handled = true;
    }
}