namespace LoginPage.Views;
using LoginPage.ViewModels;

public partial class UserAdminPageView : ContentPage
{
	public UserAdminPageView(UserAdminPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;

	}
}