using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Prototype of the method to be implemented to receive service events.
    /// </summary>
    /// <param name="sender">The event sender</param>
    /// <param name="e">The event argurment <see cref="ServiceEventArgs"/></param>
    public delegate void ServiceEventHandler(object sender, ServiceEventArgs e);

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class ServiceEventArgs
    {
        private ServiceTransition transition;
        private IServiceReference reference;

        public ServiceTransition Transition
        {
            get
            {
                return transition;
            }
        }

        public IServiceReference Reference
        {
            get
            {
                return reference;
            }
        }

        public ServiceEventArgs(ServiceTransition transition, IServiceReference reference)
        {
            this.reference = reference;
            this.transition = transition;
        }
    }
}
