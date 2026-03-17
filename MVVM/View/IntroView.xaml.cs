namespace DecadePerfume.MVVM.View;

public partial class IntroView : ContentPage
{
    public IntroView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void SignIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginView());
    }

    private async void SignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterView());
    }
}