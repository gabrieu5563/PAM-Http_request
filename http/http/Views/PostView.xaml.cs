using http.Viewmodel;

namespace http.Views;

public partial class PostView : ContentPage
{
	public PostView()
	{
		InitializeComponent();
		BindingContext = new PoatViewModel();
	}
}