using CustomLayouts;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;
using Application = Microsoft.Maui.Controls.Application;

namespace CustomLayoutExamples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("IsMouseOver", (handler, view) =>
            {
                if (view is MyMauiButton myMauiButton)
                {
#if WINDOWS
                    handler.PlatformView.PointerEntered += (sender, e) =>
                    {
                        myMauiButton.IsMouseOver = true;
                        System.Diagnostics.Debug.WriteLine($"PointerEntered {myMauiButton.IsMouseOver}");
                    };
                    handler.PlatformView.PointerExited += (sender, e) =>
                    {
                        myMauiButton.IsMouseOver = false;
                        System.Diagnostics.Debug.WriteLine($"PointerExited {myMauiButton.IsMouseOver}");
                    };
                    //handler.PlatformView.Background = Colors.SaddleBrown.ToPlatform();
#endif
                }
            });
        }


    }
}
