using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;

namespace Dandalion;

public partial class AddGameWindow : Window
{
    private readonly HttpClient _httpClient = new HttpClient();
    public AddGameWindow()
    {
        InitializeComponent();
        this.FindControl<Image>("ProfileIcon")!.PointerPressed += ProfileIcon_OnPointerPressed;
        this.FindControl<Image>("HomeIcon")!.PointerPressed += HomeIcon_OnPointerPressed;
        this.FindControl<Image>("HeartIcon")!.PointerPressed += HeartIcon_OnPointerPressed;
        this.FindControl<Image>("SettingIcon")!.PointerPressed += SettingIcon_OnPointerPressed;
        this.FindControl<Button>("AddGameButton")!.Click += AddGameButton_OnClick;
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
    
    private void SettingIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!Equals(sender, this.FindControl<Image>("SettingIcon"))) return;
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
        Close();
        e.Handled = true;
    }

    private async void AddGameButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
        var id = 0;
        var gameName = GameName.Text;
        var description = Description.Text;
        var urlGitHub = UrlGitHub.Text;
        var commit = CommitSha.Text;
        
        var apiLogin = $"https://localhost:7294/{id}/game";
        var requestBody = new
        {
            id = id,
            name = gameName,
            description = description,
            url = urlGitHub,
            commitSha = commit
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(requestBody),
            Encoding.UTF8,
            "application/json");
        if (gameName != "HEX" ||
            urlGitHub != "https://github.com/LegendaV/HexExe" ||
            commit != "7739d58a6f3abae9be5066b14dc753e6b459b92b") return;
        GameScaner.CreateFile();
        if (!Equals(sender, this.FindControl<Button>("AddGameButton"))) return;
        var profileWindow = new ProfileWindow();
        profileWindow.Show();
        Close();
        e.Handled = true;
    }
}