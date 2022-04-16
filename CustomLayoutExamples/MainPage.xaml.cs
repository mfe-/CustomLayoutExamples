using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomLayoutExamples;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;

        //NavigateCommand = new Command<object>(async s => await NavigateToAsync(s));
        //asdfCommand = new Command(() => { });
        CascadeLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new CascadeLayoutPage()); };
        HorizontalWrapLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new HorizontalWrapLayoutPage()); };
        ColumnLayoutButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new ColumnLayoutPage()); };
        CustomColumnButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new CustomColumnPage()); };
        CardViewButton.Clicked += CardViewButton_Clicked;
        CardListLayoutButton.Clicked += CardListLayoutButton_Clicked;
        CardItemsViewPageButton.Clicked += CardItemsViewPageButton_Clicked;
        //CardListLayoutButton_Clicked(this, EventArgs.Empty);
        //CardItemsViewPageButton_Clicked(this, EventArgs.Empty);
    }


    

    private async void CardItemsViewPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CardItemsViewPage());
    }

    private async void CardListLayoutButton_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new CardListLayoutPage());
    }

    private async void CardViewButton_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new CardPage());
    }
    private async void MyButtonHandlerButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ButtonHandlerPage());
    }



    public ICommand asdfCommand { get; }

    public ICommand NavigateCommand { get; }

    public async Task NavigateToAsync(object pageType)
    {
        var typePage = Type.GetType(pageType.ToString());
        if (typePage == null) throw new InvalidOperationException($"Please pass a valid Type for {pageType}");
        var instance = Activator.CreateInstance(typePage);
        if (instance is Page page)
        {
            await Navigation.PushAsync(page);
        }
    }

    
}
