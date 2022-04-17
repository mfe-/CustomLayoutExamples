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
            Loaded += MyMauiButton_Loaded;
        }

        private const string VisualCommonStates = "CommonStates";
        private const string VisualStateMouseOver = "MouseOver";
        private const string VisualStateNormal = "Normal";

        private void MyMauiButton_Loaded(object? sender, EventArgs e)
        {
            var vsg = this.GetValue(VisualStateManager.VisualStateGroupsProperty) as IList<VisualStateGroup>;
            if (vsg?.Count == 0)
            {
                var visualStateGroup = new VisualStateGroup();
                visualStateGroup.Name = VisualCommonStates;
                var normalVisualState = new VisualState() { Name = VisualStateNormal };
                visualStateGroup.States.Add(normalVisualState);
                vsg.Add(visualStateGroup);
            }

            //var visualStateGroupCommon = vsg?.First(a => a.Name == VisualCommonStates);

            //if (visualStateGroupCommon != null && visualStateGroupCommon.States.Any(a => a.Name == VisualStateMouseOver))
            //{
            //    var visualStateMouseOver = new VisualState() { Name = VisualStateMouseOver };
            //    visualStateMouseOver.Setters.Add(new Setter()
            //    {
            //        Property = TextColorProperty,
            //        Value = Colors.Black
            //    });

            //    visualStateGroupCommon.States.Add(visualStateMouseOver);
            //}
        }

        public static readonly BindableProperty IsMouseOverProperty = BindableProperty.Create(nameof(MyMauiButton), typeof(bool), typeof(MyMauiButton), false,
            propertyChanged: IsMouseOverChanged);

        private static void IsMouseOverChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MyMauiButton mauiButton)
            {
                mauiButton.Dispatcher.Dispatch(() => mauiButton.OnMouseOverChanged(mauiButton.IsMouseOver));
            }
        }
        private void OnMouseOverChanged(bool mouseover)
        {
            if (mouseover)
            {
                _ = VisualStateManager.GoToState(this, VisualStateMouseOver);
            }
            else
            {
                _ = VisualStateManager.GoToState(this, VisualStateNormal);
            }
        }
        public bool IsMouseOver
        {
            get { return (bool)GetValue(IsMouseOverProperty); }
            set { SetValue(IsMouseOverProperty, value); }
        }
    }
}
