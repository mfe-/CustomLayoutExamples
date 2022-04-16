using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts;

public class CardListLayoutManager : Microsoft.Maui.Layouts.StackLayoutManager
{
    private readonly StackLayout stackLayout;

    public CardListLayoutManager(StackLayout stackLayout) : base(stackLayout)
    {
        this.stackLayout = stackLayout;
    }
    public double Spacing { get; private set; }
    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        var padding = stackLayout.Padding;

        widthConstraint -= padding.HorizontalThickness;
        heightConstraint -= padding.VerticalThickness;

        double totalWidth = 0;
        double maxWidth = 0;
        double totalHeight = 0;

        var totalAmountItems = stackLayout.Count;
        foreach (var child in stackLayout)
        {
            var current = child.Measure(widthConstraint, heightConstraint);
            maxWidth = Math.Max(current.Width, maxWidth);
            totalWidth += current.Width;
            totalHeight = Math.Max(current.Height, totalHeight);
        }
        if (widthConstraint < totalWidth)
        {
            var a = totalAmountItems * maxWidth;
            var remaining = a - widthConstraint;
            Spacing = (remaining / totalAmountItems);
        }
        else
        {
            Spacing = 0;
        }

        return new Size(totalWidth + padding.HorizontalThickness,
            totalHeight + padding.VerticalThickness);
    }
    public override Size ArrangeChildren(Rect bounds)
    {
        var padding = stackLayout.Padding;

        double x = padding.Left;
        double y = padding.Top;

        double totalWidth = 0;
        double totalHeight = 0;

        foreach (var child in stackLayout)
        {
            var width = child.DesiredSize.Width;
            var height = child.DesiredSize.Height;
            child.Arrange(new Rect(x, y, width, height));
            totalWidth = Math.Max(totalHeight, y + height);
            x += (width - Spacing);
        }

        return new Size(totalWidth + padding.HorizontalThickness,
            totalHeight + padding.VerticalThickness);
    }
}
