using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CustomLayouts
{
    /// <summary>
    /// https://sudonull.com/post/148855-WPF-layout-Measure-and-Arrange
    /// https://stackoverflow.com/a/8270286/740651 - in case when the size that you are planning to give each individual item is not easily calculated based on availableSize and depends on other items desired size, you can do the first round of measuring on all items passing double.PositiveInfinity as Height. After that you will know how big each items wants to be and you can calculate how much space you are actually going to give to each item. Then you need to call Measure with the calculated space once again.
    /// 
    /// </summary>
    public partial class CardView : ContentView
    {
        private const double minWidth = 55;
        private const double minHeight = 85;

        public CardView()
        {
            InitializeComponent();
            BackgroundColor = Colors.BlueViolet;
        }
        /// <summary>
        /// The available size that this element can give to child elements. Infinity can be specified as a value to indicate that the element will size to whatever content is available.
        /// After all, the parent control may call Measure(Size) on our control many times with whatever parameters, and then completely ignore it in arrangement phase
        /// </summary>
        /// <param name="widthConstraint">The width parameter tells us how much space do we have at our disposal minus margin and other paramters /></param>
        /// <param name="heightConstraint">The height parameter tells us how much space do we have at our disposal minus margin and other paramters /></param>
        /// <returns>The resulting desired size should be minimal size required to accommodate all contents. This value must have finite width and height. It typically is, but is not required to be, smaller than availableSize in either dimension.</returns>
        /// <remarks>Don't call <see cref="Measure(double, double, MeasureFlags)"/> directly 
        /// as it's taking care of all the required corrections</remarks>
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            //define minimum size of control
            var minSize = new Size(minWidth, minHeight);
            System.Diagnostics.Debug.WriteLine($"MeasureOverride width={minSize.Width},height={minSize.Height}");
            return minSize;
        }
        /// <summary>
        /// The purpose of arrange phase in layout pass is to position all child controls in relation to the control itself.
        /// </summary>
        /// <param name="bounds">The bounds parameter tells us how much space do we have to arrange child controls. We should treat it as final constraint (hence the name), and do not violate it.</param>
        /// <returns>The actual size used.</returns>
        protected override Size ArrangeOverride(Rect bounds)
        {
            var size = base.ArrangeOverride(bounds);
            Rect rect = new Rect(0, 0, minWidth, minHeight);
            grid.WidthRequest = minWidth;
            grid.HeightRequest = minHeight;
            //grid.Arrange(rect); //results int Layout cycle detected.  Layout could not complete.
            System.Diagnostics.Debug.WriteLine($"ArrangeOverride width={minWidth},height={minWidth}");
            return new Size(minWidth, minHeight);
            //var width = bounds.Width;
            //var height = bounds.Height;

            //if (height <= minHeight)
            //{
            //    width = minWidth;
            //    height = minHeight;
            //}
            //grid.WidthRequest = width;
            //grid.HeightRequest = height;
            //return new Size(width, height);
            //if (height == minHeight)
            //{
            //    width = minWidth;
            //}
            ////align values to our ratio
            //if (!double.IsFinite(height))
            //{
            //    width = height * (minHeight / minWidth);
            //}
            //grid.WidthRequest = width;
            //grid.HeightRequest = height;
            ////propage calculated size to grid
            ////grid.Arrange(new Rect(0, 0, width, height));


            ////grid.Arrange(bounds);
            ////grid.Arrange(new Rect(new Point(bounds.Location.X+5,bounds.Location.Y+5),new Size(180,180)));
            //return new Size(width,height);

        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            System.Diagnostics.Debug.WriteLine($"OnSizeAllocated width={width},height={height}");
        }

    }
}