using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using Avalonia.Input;

namespace Dandalion
{
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
            var username = this.FindControl<TextBox>("UsernameInputTextBox")!.Text;
            var password = this.FindControl<TextBox>("PasswordInputTextBox")!.Text;
            
            var formData = new Dictionary<string, string?>
            {
                { "email", username },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(formData);
            
            // Send the request
            var response = await _httpClient.PostAsync("https://localhost:7294/login", content);
            
            if (response.IsSuccessStatusCode)
            {
                var stringAsync = await response.Content.ReadAsStringAsync();
                if (!stringAsync.Contains("Пользователь не найден"))
                {
                    // Обработка успешного ответа
                    var regWindow = new RegistrationWindow();
                    regWindow.Show();
                    Close();
                }
                else
                {
                    // Обработка ошибки
                }
            }
            else
            {
                // Handle error
            }
        }

    }
}