namespace DecadePerfume.MVVM.View;

public partial class AdminDashboardView : FlyoutPage
{
	public AdminDashboardView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void Dashboard_Clicked(object sender, EventArgs e)
    {
        //Detail = new NavigationPage(new AdminHomeView());
        IsPresented = false;
    }

    private void Products_Clicked(object sender, EventArgs e)
    {
        //Detail = new NavigationPage(new ProductManagementView());
        IsPresented = false;
    }

    private void Category_Clicked(object sender, EventArgs e)
    {
        //Detail = new NavigationPage(new CategoryManagementView());
        IsPresented = false;
    }

    private void Inventory_Clicked(object sender, EventArgs e)
    {
        //Detail = new NavigationPage(new InventoryView());
        IsPresented = false;
    }

    private void Reports_Clicked(object sender, EventArgs e)
    {
        //Detail = new NavigationPage(new ReportsView());
        IsPresented = false;
    }

    private void Users_Clicked(object sender, EventArgs e)
    {
        Detail = new NavigationPage(new UserManagementView());
        IsPresented = false;
    }

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