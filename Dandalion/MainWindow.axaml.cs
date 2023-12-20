using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using System.Text;
using Avalonia.Input;
using Newtonsoft.Json;

namespace Dandalion;

public partial class MainWindow : Window
{
    private readonly HttpClient _httpClient = new HttpClient();

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

    private async void OnLoginButtonClickAsync(object? sender, RoutedEventArgs e)
    {
        /*
        const string apiLogin = "https://localhost:7294/login";
        var username = this.FindControl<TextBox>("UsernameLoginTextBox")!.Text;
        var password = this.FindControl<TextBox>("PasswordLoginTextBox")!.Text;

        var requestBody = new
        {
            email = username,
            password = password
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(requestBody), 
            Encoding.UTF8,
            "application/json");
        
        var response = await _httpClient.PostAsync(apiLogin, content);
        */
        if (true)
        {
            //var stringAsync = await response.Content.ReadAsStringAsync();
            if (true)
            {
                // Обработка успешного ответа
                var generalScreenWindow = new GeneralScreenWindow();
                generalScreenWindow.Show();
                Close();
            }
            else
            {
                // Обработка ошибки входа
            }
        }
        else
        {
            // Обработка других ошибок HTTP
        }
    }
}