using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Xml
{
    class IssueXmlSerializer : XmlSerializer<Issue>
    {
        public const string NodeXName = "issue";
        public const string VolumeXName = "volume";
        public const string NumberXName = "number";
        public const string AltNumberXName = "altNumber";
        public const string PartXName = "part";
        public const string PagesXName = "pages";
        public const string DateUniXName = "dateUni";

        public IssueXmlSerializer(ISerializationProvider<XElement> serializationProvider) : base(serializationProvider)
        {
        }

        public override XElement Serialize(Issue @object)
        {
            XElement element = new XElement(NodeXName,
                new XElement(VolumeXName, @object.Volume ?? ""),
                new XElement(NumberXName, @object.Number ?? ""),
                new XElement(AltNumberXName, @object.AltNumber ?? ""),
                new XElement(PartXName, @object.Part ?? ""),
                new XElement(PagesXName, @object.Pages ?? ""),
                new XElement(DateUniXName, @object.YearPubl)
            );

            return element;
        }

        public override Issue Deserialize(XElement format)
        {
            XElement volumeElement = format.Element(VolumeXName);
            volumeElement.TryGetValue(out string volume);

            XElement numberElement = format.Element(NumberXName);
            numberElement.TryGetValue(out string number);

            XElement altNumberElement = format.Element(AltNumberXName);
            altNumberElement.TryGetValue(out string altNumber);

            XElement partElement = format.Element(PartXName);
            partElement.TryGetValue(out string part);

            XElement pagesElement = format.Element(PagesXName);
            pagesElement.TryGetValue(out string pages);

            XElement dateUniElement = format.Element(DateUniXName);
            dateUniElement.TryGetValue(out int yearPubl);

            var issue = new Issue(volume,
                number,
                altNumber,
                part,
                pages,
                yearPubl);

            return issue;
        }
    }
}
