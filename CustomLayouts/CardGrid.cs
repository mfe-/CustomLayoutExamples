using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts
{
    public class CardGrid : Grid
    {
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            var size = base.MeasureOverride(widthConstraint, heightConstraint);
            var min = Math.Min(size.Height, size.Height);
            var newSize = new Size(size.Height, size.Height);
            foreach (var item in Children)
            {
                var x = item.Measure(newSize.Width, newSize.Height);
            }
            return newSize;
        }
        protected override Size ArrangeOverride(Rect bounds)
        {
            //var arrange = base.ArrangeOverride(bounds);
            var min = Math.Min(bounds.Height, bounds.Height);
            var newSize = new Size(min, min);
            foreach (var item in Children)
            {
                var x = item.Arrange(new Rect(0, 0, newSize.Width, newSize.Height));
            }
            return newSize;
        }
    }
}
