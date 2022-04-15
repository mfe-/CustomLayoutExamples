using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts;

public class CardListLayoutManager : Microsoft.Maui.Layouts.StackLayoutManager
{
    private readonly CardListLayout cardListLayout;

    public CardListLayoutManager(CardListLayout cardListLayout) : base(cardListLayout)
    {
        this.cardListLayout = cardListLayout;
    }
    public double Spacing { get; private set; }
    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        var padding = cardListLayout.Padding;

        widthConstraint -= padding.HorizontalThickness;
        heightConstraint -= padding.VerticalThickness;

        double x = padding.Left;
        double y = padding.Top;
        double totalWidth = 0;
        double maxWidth = 0;
        double totalHeight = 0;

        var totalAmountItems = cardListLayout.Count;
        foreach (var child in cardListLayout)
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
        var padding = cardListLayout.Padding;
        var spacing = cardListLayout.Spacing;

        double x = padding.Left;
        double y = padding.Top;

        double totalWidth = 0;
        double totalHeight = 0;

        foreach (var child in cardListLayout)
        {
            var width = child.DesiredSize.Width;
            var height = child.DesiredSize.Height;
            child.Arrange(new Rect(x, y, width, height));
            totalWidth = Math.Max(totalWidth, x + width);
            totalWidth = Math.Max(totalHeight, y + height);
            x += (width - Spacing);
        }

        return new Size(totalWidth + padding.HorizontalThickness,
            totalHeight + padding.VerticalThickness);
    }
}
