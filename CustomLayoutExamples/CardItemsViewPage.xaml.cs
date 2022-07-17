using Microsoft.Maui.Controls;

namespace CustomLayoutExamples;

public partial class CardItemsViewPage : ContentPage
{
	public CardItemsViewPage()
	{
		InitializeComponent();
		Loaded += CardItemsViewPage_Loaded;
	}

	private void CardItemsViewPage_Loaded(object? sender, EventArgs e)
	{
		if(this.BindingContext is CardItemsViewPageViewModel cardItemsViewPageViewModel)
		{
			cardItemsViewPageViewModel.Page = this;
		}
	}
}