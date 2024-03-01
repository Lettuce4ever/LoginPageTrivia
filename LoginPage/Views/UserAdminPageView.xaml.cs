namespace LoginPage.Views;
using LoginPage.ViewModels;

public partial class UserAdminPageView : ContentPage
{
	public UserAdminPageView()
	{
		InitializeComponent();
		this.BindingContext = new UserAdminPageViewModel();

	}
}