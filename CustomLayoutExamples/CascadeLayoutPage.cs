using CustomLayouts;
using Microsoft.Maui.Controls;

namespace CustomLayoutExamples
{
    internal class CascadeLayoutPage : ContentPage
    {
        public CascadeLayoutPage()
        {
            Title = "Cascade Layout";

            var layout = new CascadeLayout { Margin = 10, Spacing = 30 };

            for (int n = 0; n < 10; n++)
            {
                var button = new Button { Text = $"Button {n}", WidthRequest = 55, HeightRequest = 85 };
                layout.Add(button);
            }

            Content = layout;
        }
    }
}
