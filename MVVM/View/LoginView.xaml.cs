using DecadePerfume.MVVM.Model;

namespace DecadePerfume.MVVM.View;

public partial class LoginView : ContentPage
{
    private bool _isPasswordVisible = false;

    public LoginView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    // Toggle password visibility
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
                Color = Color.FromArgb("#000000"),
                Size = 20
            };
        }
    }
    private async void ForgotPassword_Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password",
            "Please contact the administrator to reset your password.",
            "OK");
    }
    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        ErrorLabel.Text = "";

        string username = UsernameEntry.Text?.Trim();
        string password = PasswordEntry.Text?.Trim();

        // BOTH EMPTY
        if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please input username and password.";
            return;
        }

        // USERNAME EMPTY
        if (string.IsNullOrWhiteSpace(username))
        {
            ErrorLabel.Text = "Please input username.";
            UsernameEntry.Focus();
            return;
        }

        // PASSWORD EMPTY
        if (string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please input password.";
            PasswordEntry.Focus();
            return;
        }

        var users = RegisterView.GetRegisteredUsers();

        // CHECK IF USER EXISTS
        var user = users.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            ErrorLabel.Text = "User is not registered.";
            return;
        }

        // WRONG USERNAME & PASSWORD (extra strict check)
        bool usernameExists = users.Any(u => u.Username == username);
        bool passwordMatch = users.Any(u => u.Password == password);

        if (!usernameExists && !passwordMatch)
        {
            ErrorLabel.Text = "Incorrect username and password.";
            return;
        }

        // WRONG PASSWORD ONLY
        if (user.Password != password)
        {
            ErrorLabel.Text = "Incorrect password.";
            PasswordEntry.Text = "";
            PasswordEntry.Focus();
            return;
        }

        // SUCCESS LOGIN
        if (user.Role == "admin")
            Navigation.PushAsync(new AdminDashboardView());
        else
            Navigation.PushAsync(new UserManagementView());

        Clear();
    }
  

    public void Clear()
    {
        UsernameEntry.Text = "";
        PasswordEntry.Text = "";
        PasswordEntry.IsPassword = true;
        _isPasswordVisible = false;
    }

    private void UsernameEntry_Completed(object sender, EventArgs e)
    {
        PasswordEntry.Focus();
    }

    private void PasswordEntry_Completed(object sender, EventArgs e)
    {
        LoginButton_Clicked(sender, e);
    }

    private async void SignUpHere_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterView());
    }
}