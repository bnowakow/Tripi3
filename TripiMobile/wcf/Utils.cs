using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GPSMobile;

namespace Tripi.wcf
{
    static class Utils
    {
        #region EXTENSION_METHODS

        /// <summary>
        /// Converts GpsPosition object to PositionNode object
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static PositionNode GetPositionNode(this GpsPosition position)
        {
            PositionNode node = new PositionNode();

            node.CreationTimeSpecified = position.TimeValid;
            if (position.TimeValid)
                node.CreationTime = position.Time;

            node.LatitudeSpecified = position.LatitudeValid;
            if (position.LatitudeValid)
                node.Latitude = position.Latitude;

            node.LongitudeSpecified = position.LongitudeValid;
            if (position.LongitudeValid)
                node.Longitude = position.Longitude;

            node.SpeedSpecified = position.SpeedValid;
            if (position.SpeedValid)
                node.Speed = position.Speed;
            return node;
        }
        #endregion
    }
}
