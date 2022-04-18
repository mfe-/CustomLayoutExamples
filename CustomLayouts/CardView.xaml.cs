using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CustomLayouts;

public partial class CardView : ContentView
{
    private const double minWidth = 55;
    private const double minHeight = 85;
    public CardView()
    {
        InitializeComponent();
    }
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(object), typeof(CardView), default(object));

    public object Card
    {
        get { return (object)GetValue(CardProperty); }
        set { SetValue(CardProperty, value); }
    }

    public static readonly BindableProperty IsMouseOverProperty = BindableProperty.Create(nameof(Card), typeof(bool), typeof(CardView), false, propertyChanged: MouseOverPropertyChanged);

    private static void MouseOverPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CardView cardView)
        {
            cardView.Dispatcher.Dispatch(() => cardView.OnMouseOverChanged(cardView.IsMouseOver));
        }
    }
    private async void OnMouseOverChanged(bool isMouseover)
    {
        if (isMouseover)
        {
            BackgroundColor = Colors.Red;
            await this.TranslateTo(0, -TranslationYOffset, 250, Easing.Linear);
            await this.TranslateTo(0, 0, 250, Easing.Linear);
        }
        else
        {
            BackgroundColor = Colors.Yellow;
        }
    }

    public bool IsMouseOver
    {
        get { return (bool)GetValue(IsMouseOverProperty); }
        set { SetValue(IsMouseOverProperty, value); }
    }


    public static readonly BindableProperty TranslationYOffsetProperty = BindableProperty.Create(nameof(TranslationYOffset), typeof(double), typeof(CardView), 3d);
    /// <summary>
    /// How much additional space the animation requires for Y
    /// </summary>
    public double TranslationYOffset
    {
        get { return (double)GetValue(TranslationYOffsetProperty); }
        set { SetValue(TranslationYOffsetProperty, value); }
    }

    //protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
    //{
    //    var size = base.MeasureOverride(widthConstraint, heightConstraint);
    //    var min = Math.Min(size.Height, size.Height);
    //    var newSize = new Size(size.Height, size.Height);
    //    foreach (var item in Children)
    //    {
    //        if (item is VisualElement visualElement)
    //        {
    //            var x = visualElement.Measure(newSize.Width, newSize.Height, MeasureFlags.None);
    //        }
    //        else
    //        {
    //            throw new NotSupportedException("Implement a method which does something similar like Measure");
    //        }
    //        //var x = item.Measure(newSize.Width, newSize.Height);
    //    }
    //    return newSize;
    //}
    //protected override Size ArrangeOverride(Rect bounds)
    //{
    //    //var arrange = base.ArrangeOverride(bounds);
    //    var min = Math.Min(bounds.Height, bounds.Height);
    //    var newSize = new Size(min, min);
    //    foreach (var item in Children)
    //    {
    //        if (item is VisualElement visualElement)
    //        {
    //            //visualElement.WidthRequest = newSize.Width;
    //            //visualElement.HeightRequest = newSize.Height;
    //            visualElement.Arrange(new Rect(0, 0, newSize.Width, newSize.Height));
    //        }
    //        else
    //        {
    //            throw new NotSupportedException("Implement a method which does something similar like Arrange");
    //        }
    //    }
    //    return newSize;
    //}
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        System.Diagnostics.Debug.WriteLine($"OnSizeAllocated width={width},height={height}");
    }

}