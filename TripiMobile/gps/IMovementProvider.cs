using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DeadCity.Mobile.MovementProviders
{
    public interface IMovementProvider
    {
        void AffectPosition(ref PointyD pos);
    }
}
