using System.Net.Http;
using System.Text;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Newtonsoft.Json;

namespace Dandalion;

public partial class RegistrationWindow : Window
{
    private readonly HttpClient _httpClient = new HttpClient();
    public RegistrationWindow()
    {
        InitializeComponent();
        var textBlock = this.FindControl<TextBlock>("SignIn");
        if (textBlock != null) textBlock.PointerPressed += SignIn_PointerPressed;
    }
    private void SignIn_PointerPressed(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
    
    private async void OnRegisterButtonClickAsync(object? sender, RoutedEventArgs e)
    {
        const string apiRegister = "https://localhost:7294/register";
        var username = this.FindControl<TextBox>("UsernameRegisterTextBox")!.Text;
        var email = this.FindControl<TextBox>("EmailRegisterTextBox")!.Text;
        var password = this.FindControl<TextBox>("PasswordRegisterTextBox")!.Text;
        var confirmPassword = this.FindControl<TextBox>("ConfirmPasswordRegisterTextBox")!.Text;
        
        var requestBody = new
        {
            userName = username,
            login = email,
            password = password
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(requestBody), 
            Encoding.UTF8,
            "application/json");

        if (password != confirmPassword) return;
        var response = await _httpClient.PostAsync(apiRegister, content);
    
        if (response.IsSuccessStatusCode)
        {
            var stringAsync = await response.Content.ReadAsStringAsync();

            // Проверка ответа API на успешную регистрацию
            if (!stringAsync.Contains("Ошибка регистрации"))
            {
                // Обработка успешного ответа, например, переход на страницу входа
                var loginWindow = new MainWindow();
                loginWindow.Show();
                Close();
            }
            else
            {
                // Обработка ошибки регистрации
            }
        }
        else
        {
            // Обработка других ошибок HTTP
        }
    }
}