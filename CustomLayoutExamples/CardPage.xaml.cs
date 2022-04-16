using Microsoft.Maui.Controls;

namespace CustomLayoutExamples;

public partial class CardPage : ContentPage
{
	public CardPage()
	{
		InitializeComponent();
        Loaded += CardPage_Loaded;
	}

    private void CardPage_Loaded(object sender, System.EventArgs e)
    {
        labelhw.Text = $"cardcontrol width = {cardcontrol.Width} height={cardcontrol.Height}";
    }
}