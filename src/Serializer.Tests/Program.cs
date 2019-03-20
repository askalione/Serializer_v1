using Serializer.Objects;
using Serializer.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use Xml serializer
            var xmlSerializer = new XmlSerializer();

            // Serialize
            var journal = new Journal(1, "XXXX", "YYYY", new Issue("vol.1", "1", "2", "3", "4", 2010));            
            var xml = xmlSerializer.Serialize(journal);

            // Desirialize
            var root = new XElement("journal",
                new XElement("titleid", 1337),
                new XElement("issn", "000"),
                new XElement("eissn", "1111"),
                new XElement("issue",
                    new XElement("volume", "vol.2"),
                    new XElement("number", "3"),
                    new XElement("altNumber", "4"),
                    new XElement("part", "5"),
                    new XElement("pages", "6"),
                    new XElement("dateUni", 2019))
            );
            var document = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
            document.Add(root);
            journal = xmlSerializer.Deserialize<Journal>(document);
        }
    }
}
