#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using Physalis.Specs.Framework;
using Physalis.Utils;

#endregion

namespace Bundle
{
    public class TheActivator : IBundleActivator
    {
        public TheActivator()
        {

        }

        public void Start(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is starting");
            TracesProvider.TracesOutput.OutputTrace("Id=" + context.Bundle.Id);
            TracesProvider.TracesOutput.OutputTrace("State=" + context.Bundle.State);
        }

        public void Stop(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is stopping");
            TracesProvider.TracesOutput.OutputTrace("Id=" + context.Bundle.Id);
            TracesProvider.TracesOutput.OutputTrace("State=" + context.Bundle.State);
        }
    }
}
