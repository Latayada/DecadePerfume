using DecadePerfume.MVVM.Model;

namespace DecadePerfume.MVVM.View;

public partial class RegisterView : ContentPage
{
    private static List<Users> _registeredUsers = new()
    {
        new Users
        {
            Username = "admin",
            Password = "123",
            Role = "admin"
        }
    };

    private bool _isPasswordVisible = false;
    private bool _isConfirmPasswordVisible = false;

    public RegisterView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    //Password
    private void EyeIcon_Clicked(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        PasswordEntry.IsPassword = !_isPasswordVisible;

        if (sender is Image img)
        {
            img.Source = new FontImageSource
            {
                Glyph = _isPasswordVisible ? "\ue801" : "\ue800",
                FontFamily = "Fontello",
                Color = Color.FromArgb("#F7D060"),
                Size = 20
            };
        }
    }

    //ConfrimPassword
    private void ConfirmEyeIcon_Clicked(object sender, EventArgs e)
    {
        _isConfirmPasswordVisible = !_isConfirmPasswordVisible;
        ConfirmPasswordEntry.IsPassword = !_isConfirmPasswordVisible;

        if (sender is Image img)
        {
            img.Source = new FontImageSource
            {
                Glyph = _isConfirmPasswordVisible ? "\ue801" : "\ue800",
                FontFamily = "Fontello",
                Color = Color.FromArgb("#F7D060"),
                Size = 20
            };
        }
    }

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        ErrorLabel.Text = "";

        string email = EmailEntry.Text?.Trim();
        string contact = ContactEntry.Text?.Trim();
        string username = UsernameEntry.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(contact) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            ErrorLabel.Text = "Please fill in all fields.";
            return;
        }

        if (password.Length < 4)
        {
            ErrorLabel.Text = "Password must be at least 4 characters.";
            return;
        }

        if (password != confirmPassword)
        {
            ErrorLabel.Text = "Passwords do not match.";
            return;
        }

        if (_registeredUsers.Any(u => u.Username == username))
        {
            ErrorLabel.Text = "Username already exists.";
            return;
        }

        _registeredUsers.Add(new Users
        {
            Email = email,
            Contact = contact,
            Username = username,
            Password = password,
            Role = "user"
        });

        await DisplayAlert("Success", "Registration successful! Please login.", "OK");

        await Navigation.PushAsync(new LoginView());

        ClearInputs();
    }

    private void ClearInputs()
    {
        EmailEntry.Text = "";
        ContactEntry.Text = "";
        UsernameEntry.Text = "";
        PasswordEntry.Text = "";
        ConfirmPasswordEntry.Text = "";

        PasswordEntry.IsPassword = true;
        ConfirmPasswordEntry.IsPassword = true;

        _isPasswordVisible = false;
        _isConfirmPasswordVisible = false;
    }

    private async void SignInHere_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginView());
    }

    public static List<Users> GetRegisteredUsers()
    {
        return _registeredUsers;
    }
}