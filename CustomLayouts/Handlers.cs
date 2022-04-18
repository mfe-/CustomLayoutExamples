using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayouts;

public static class Handlers
{
    public static IMauiHandlersCollection AddCustomLayoutControlsHandlers(this IMauiHandlersCollection handlersCollection)
    {

        //handlersCollection.AddHandler<Label, LabelHandler>();
        return handlersCollection;
    }
}