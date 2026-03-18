namespace DecadePerfume.MVVM.View;

public partial class AdminDashboardView : FlyoutPage
{
	public AdminDashboardView()
	{
		InitializeComponent();
        IsPresented = true;
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void Dashboard_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new ContentPage
        {
            Title = "Dashboard",
            BackgroundColor = Colors.Black,
            Content = new StackLayout
            {
                Padding = 30,
                Children =
                {
                    new Label
                    {
                        Text = "Admin Dashboard",
                        FontSize = 24,
                        TextColor = Color.FromArgb("#F7D060"),
                        HorizontalOptions = LayoutOptions.Center
                    }
                }
            }
        });

        IsPresented = false;
    }

    private void Products_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new ProductManagementView());
        IsPresented = false;
    }

    private void Category_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new CategoryManagementView());
        IsPresented = false;
    }

    private void Inventory_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new InventoryView());
        IsPresented = false;
    }

    private void Reports_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new ReportsView());
        IsPresented = false;
    }

    private void Users_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new UserManagementView());
        IsPresented = false;
    }

    private void POS_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new POSView());
        IsPresented = false;
    }

    //private void Orders_Clicked(object sender, EventArgs e)
    //{
    //    Detail = new NavigationPage(new OrdersView());
    //    IsPresented = false;
    //}

    //private void Profile_Clicked(object sender, EventArgs e)
    //{
    //    Detail = new NavigationPage(new ProfileView());
    //    IsPresented = false;
    //}

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Logout",
            "Are you sure you want to logout?",
            "Yes",
            "No");

        if (confirm)
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}