using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts;

public class CardListLayout : StackLayout
{
    protected override ILayoutManager CreateLayoutManager()
    {
        return new CardListLayoutManager(this);
    }
}
