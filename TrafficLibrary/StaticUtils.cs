using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLibrary
{
    public static class StaticUtils
    {
        public static string GetGroup(this System.Text.RegularExpressions.Match match, int i)
        {
            return match.Groups[i].Value;
        }

        public static string GetGroup(this System.Text.RegularExpressions.Regex regex, string matching, int i)
        {
            return regex.Match(matching).GetGroup(i);
        }

        public static string GetFirstGroup(this System.Text.RegularExpressions.Regex regex, string matching)
        {
            return regex.GetGroup(matching, 1);
        }

        public static string GetGroup(this string matching, string regex, int i)
        {
            return System.Text.RegularExpressions.Regex.Match(matching, regex).GetGroup(i);
        }

        public static string GetFirstGroup(this string matching, string regex)
        {
            return matching.GetGroup(regex, 1);
        }

        public static TOut IfNotNull<TIn, TOut>(this TIn v, Func<TIn, TOut> f)
            where TIn : class
            where TOut : class
        {
            if (v == null) return null;
            return f(v);
        }

        public static string F(this string formatString, params object[] args)
        {
            return String.Format(formatString, args);
        }

        public static string F(this string formatString, object arg0)
        {
            return String.Format(formatString, arg0);
        }

        public static string F(this string formatString, object arg0, object arg1)
        {
            return String.Format(formatString, arg0, arg1);
        }

        public static string F(this string formatString, object arg0, object arg1, object arg2)
        {
            return String.Format(formatString, arg0, arg1, arg2);
        }

        public static void TransferPropertiesTo(this object source, object destination, params string[] propertyNames)
        {
            Type sType = source.GetType(), dType = destination.GetType();
            foreach (string name in propertyNames)
            {
                try
                {
                    dType.GetProperty(name).SetValue(destination, sType.GetProperty(name).GetValue(source, null), null);
                }
                catch (System.Reflection.TargetInvocationException)
                {
                }
            }
        }

        public static void TransferPropertiesTo(this object source, object destination)
        {
            IEnumerable<string> sourceProperties = source.GetType().GetProperties().Where(pi => pi.CanRead).Select(pi => pi.Name),
                destinationProperties = destination.GetType().GetProperties().Where(pi => pi.CanWrite).Select(pi => pi.Name);
            string[] propertyNames = sourceProperties.Intersect(destinationProperties).ToArray();
            source.TransferPropertiesTo(destination, propertyNames);
        }

        public static T Deserialize<T>(string filename)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.TextReader tr = new System.IO.StreamReader(filename);
            T temp = (T)xs.Deserialize(tr);
            tr.Close();
            return temp;
        }

        public static void Serialize<T>(this T obj, string filename)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.TextWriter tw = new System.IO.StreamWriter(filename);
            xs.Serialize(tw, obj);
            tw.Close();
        }
    }
}
