using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tripi.WeatherService;

namespace Tripi
{
    class WebServiceManager
    {
        public static String GetWeather(String city, String country)
        {
            using (GlobalWeather weather = new GlobalWeather())
            {
                return weather.GetWeather(city, country);
            }

        }
    }
}
