using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts
{
    public class MyMauiButton : Button
    {
        public MyMauiButton()
        {
            
        }
        public static readonly BindableProperty IsMouseOverProperty = BindableProperty.Create(nameof(MyMauiButton), typeof(bool), typeof(MyMauiButton), false,
            propertyChanged: IsMouseOverChanged);

        private static void IsMouseOverChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MyMauiButton mauiButton)
            {
                System.Diagnostics.Debug.WriteLine($"IsMouseOverChanged {mauiButton.IsMouseOver}");
            }
        }
        protected bool IsPointerEntered = false;
        protected bool IsPointerExited = false;
        public bool IsMouseOver
        {
            get { return (bool)GetValue(IsMouseOverProperty); }
            set { SetValue(IsMouseOverProperty, value); }
        }
    }
}
