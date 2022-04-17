﻿using System;
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
        if(isMouseover)
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
    //    //define minimum size of control
    //    var minSize = new Size(minWidth, minHeight);

    //    double totalWidth = 0;
    //    double totalHeight = 0;

    //    SizeRequest sizeRequest = grid.Measure(minSize.Width, minSize.Height);

    //    System.Diagnostics.Debug.WriteLine($"MeasureOverride width={minSize.Width},height={minSize.Height}");
    //    return minSize;
    //}
    ///// <summary>
    ///// The purpose of arrange phase in layout pass is to position all child controls in relation to the control itself.
    ///// </summary>
    ///// <param name="bounds">The bounds parameter tells us how much space do we have to arrange child controls. We should treat it as final constraint (hence the name), and do not violate it.</param>
    ///// <returns>The actual size used.</returns>
    //protected override Size ArrangeOverride(Rect bounds) //bounds = { X=0, Y=0, Width=1013, Height=0 } 
    //{
    //    var size = base.ArrangeOverride(bounds);
    //    Rect rect = new Rect(0, 0, minWidth, minHeight);
    //    grid.WidthRequest = minWidth;
    //    grid.HeightRequest = minHeight;
    //    //grid.Arrange(rect); //results int Layout cycle detected.  Layout could not complete.
    //    System.Diagnostics.Debug.WriteLine($"ArrangeOverride width={minWidth},height={minWidth}");
    //    return new Size(minWidth, minHeight);
    //    //var width = bounds.Width;
    //    //var height = bounds.Height;

    //    //if (height <= minHeight)
    //    //{
    //    //    width = minWidth;
    //    //    height = minHeight;
    //    //}
    //    //grid.WidthRequest = width;
    //    //grid.HeightRequest = height;
    //    //return new Size(width, height);
    //    //if (height == minHeight)
    //    //{
    //    //    width = minWidth;
    //    //}
    //    ////align values to our ratio
    //    //if (!double.IsFinite(height))
    //    //{
    //    //    width = height * (minHeight / minWidth);
    //    //}
    //    //grid.WidthRequest = width;
    //    //grid.HeightRequest = height;
    //    ////propage calculated size to grid
    //    ////grid.Arrange(new Rect(0, 0, width, height));


    //    ////grid.Arrange(bounds);
    //    ////grid.Arrange(new Rect(new Point(bounds.Location.X+5,bounds.Location.Y+5),new Size(180,180)));
    //    //return new Size(width,height);

    //}
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        System.Diagnostics.Debug.WriteLine($"OnSizeAllocated width={width},height={height}");
    }

}