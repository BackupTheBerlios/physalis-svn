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

        public void Start()
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is starting");
        }

        public void Stop()
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is stopping");
        }
    }
}
