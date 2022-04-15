using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts
{
    internal class CustomControl : View, IContentView
    {
        Grid grid;
        public CustomControl()
        {
            grid = new Grid();
        }
        public IView? PresentedContent => grid;

        public Thickness Padding => new Thickness(0, 0);

        object? IContentView.Content => grid;

        public Size CrossPlatformArrange(Rect bounds)
        {
            var size= grid.CrossPlatformArrange(bounds);
            return size;
        }
        
        public Size CrossPlatformMeasure(double widthConstraint, double heightConstraint)
        {
            var size = grid.CrossPlatformMeasure(widthConstraint, heightConstraint);
            return size;
        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            // TODO hartez 2018-05-22 05:04 PM This 40,40 is what LV1 does; can we come up with something less arbitrary?
            var minimumSize = new Size(40, 40);

            var scaled = new Size(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);
            var maxWidth = Math.Min(scaled.Width, widthConstraint);
            var maxHeight = Math.Min(scaled.Height, heightConstraint);

            Size request = new Size(maxWidth, maxHeight);

            return new SizeRequest(request, minimumSize);
        }

    }
}
