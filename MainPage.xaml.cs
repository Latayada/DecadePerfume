using DecadePerfume.MVVM.View;

namespace DecadePerfume
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Get_Clicked(object sender, EventArgs e)
        {
        
            Application.Current.MainPage = new NavigationPage(new IntroView());
        }
    }
}
