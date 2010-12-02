using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Maps.MapControl;

namespace TripiTrafficMap.Util.Interface
{
    public interface IMapStartPositionAdjuster
    {
        void SetMapCenterPointAndZoomLevel(IList<Location> locations);
    }
}
