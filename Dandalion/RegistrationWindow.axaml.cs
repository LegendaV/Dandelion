using System.Collections.Generic;
using System.Net.Http;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Tmds.DBus.Protocol;

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
        const string apiUrl = "https://localhost:7294/register";
        var username = this.FindControl<TextBox>("UsernameInputTextBox")!.Text;
        var password = this.FindControl<TextBox>("PasswordInputTextBox")!.Text;
        var confirmPassword = this.FindControl<TextBox>("ConfirmPasswordTextBox")!.Text;
        var email = this.FindControl<TextBox>("EmailInputTextBox")!.Text;

        var formData = new Dictionary<string, string?>
        {
            { "username", username },
            { "email", email },
            { "password", password }
        };

        var content = new FormUrlEncodedContent(formData);
        
    
        // Изменение URL на адрес API для регистрации
        if (password != confirmPassword)
        {
            // пароли не совпадают
            return;
        }
        
        var response = await _httpClient.PostAsync( apiUrl, content);
    
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