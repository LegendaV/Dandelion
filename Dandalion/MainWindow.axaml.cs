using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using System.Text;
using Avalonia.Input;
using Avalonia.Layout;
using Newtonsoft.Json;

namespace Dandalion;

public partial class MainWindow : Window
{
    private readonly HttpClient _httpClient = new HttpClient();
    
    private string token { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
        this.FindControl<TextBlock>("CreateAccount")!.PointerPressed += CreateAccount_PointerPressed;
        this.FindControl<Button>("LoginButton")!.Click += OnLoginButtonClickAsync;
    }

    private void CreateAccount_PointerPressed(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
    {
        var regWindow = new RegistrationWindow();
        regWindow.Show();
        Close();
    }

    public static void ShareToken()
    {
        
    }
    private async void OnLoginButtonClickAsync(object? sender, RoutedEventArgs e)
    {
        const string apiLogin = "https://localhost:7294/login";
        var username = this.FindControl<TextBox>("UsernameLoginTextBox")!.Text;
        var password = this.FindControl<TextBox>("PasswordLoginTextBox")!.Text;

        var requestBody = new
        {
            login = username,
            password = password
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(apiLogin, content);
        var stringAsync = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }
        else if (stringAsync == "Пользователь не найден")
        {
            var window = new Window
            {
                Title = "Error",
                Width = 300,
                Height = 100,
                Content = new TextBlock
                {
                    Text = "Пользователь не найден",
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            window.Show();
        }
    }
}