using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Prototype of the method to be implemented to receive bundle events.
    /// </summary>
    /// <param name="sender">The event sender</param>
    /// <param name="e">The event argurment <see cref="BundleEventArgs"/></param>
    public delegate void BundleEventHandler(object sender, BundleEventArgs e);

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class BundleEventArgs
    {
        private BundleTransition transition;
        private IBundle bundle;

        public BundleTransition Transition
        {
            get
            {
                return transition;
            }
        }

        public IBundle Bundle
        {
            get
            {
                return bundle;
            }
        }

        public BundleEventArgs(BundleTransition transition, IBundle bundle)
        {
            this.bundle = bundle;
            this.transition = transition;
        }
    }
}
