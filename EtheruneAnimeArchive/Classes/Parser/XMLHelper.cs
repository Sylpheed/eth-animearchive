using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EtheruneAnimeArchive.Classes.Parser
{
    class XMLHelper
    {
        public static int IntValue(XmlNode node)
        {
            if (node != null)
            {
                int num = 0;
                int.TryParse(node.InnerText, out num);

                return num;
            }
            else
            {
                Console.WriteLine("Accessing null XML Node!");
                return 0;
            }
        }

        public static float FloatValue(XmlNode node)
        {
            if (node != null)
            {
                float num = 0;
                float.TryParse(node.InnerText, out num);

                return num;
            }
            else
            {
                Console.WriteLine("Accessing null XML Node!");
                return 0;
            }
        }

        public static string StringValue(XmlNode node)
        {
            if (node != null)
            {
                return node.InnerText;
            }
            else
            {
                Console.WriteLine("Accessing null XML Node!");
                return null;
            }
        }
    }
}
