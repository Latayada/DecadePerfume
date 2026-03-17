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
                Color = Color.FromArgb("#F7D060"),
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

        if (string.IsNullOrWhiteSpace(username))
        {
            ErrorLabel.Text = "Please enter username.";
            UsernameEntry.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ErrorLabel.Text = "Please enter password.";
            PasswordEntry.Focus();
            return;
        }

        var user = RegisterView.GetRegisteredUsers()
                    .FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            ErrorLabel.Text = "User is not registered.";
            return;
        }

        if (user.Password != password)
        {
            ErrorLabel.Text = "Incorrect password.";
            PasswordEntry.Text = "";
            PasswordEntry.Focus();
            return;
        }

        // Navigate based on role
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