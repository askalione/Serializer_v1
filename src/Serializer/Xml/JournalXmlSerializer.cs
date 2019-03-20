using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Xml
{
    class JournalXmlSerializer : XmlSerializer<Journal>
    {
        private const string NodeXName = "journal";
        private const string TitleIdXName = "titleid";
        private const string IssnXName = "issn";
        private const string EissnXName = "eissn";
        
        public JournalXmlSerializer(ISerializationProvider<XElement> serializationProvider) : base(serializationProvider)
        {
        }

        public override XElement Serialize(Journal @object)
        {
            var element = new XElement(NodeXName,
                new XElement(TitleIdXName, @object.TitleId),
                new XElement(IssnXName, @object.Issn ?? ""),
                new XElement(EissnXName, @object.Eissn ?? "")
            );

            XElement issue = SerializationProvider.Serialize(@object.Issue);
            element.Add(issue);

            return element;
        }

        public override Journal Deserialize(XElement format)
        {
            XElement titleIdElement = format.Element(TitleIdXName);
            titleIdElement.TryGetValue(out int titleId);

            XElement issnElement = format.Element(IssnXName);
            issnElement.TryGetValue(out string issn);
            // Example of serialization exception
            if (string.IsNullOrEmpty(issn))
                throw new SerializationException(Messages.InvalidIssn, issn, IssnXName);

            XElement eissnElement = format.Element(EissnXName);
            eissnElement.TryGetValue(out string eissn);

            XElement issueElement = format.Element(IssueXmlSerializer.NodeXName);

            var issue = SerializationProvider.Deserialize<Issue>(issueElement);

            var journal = new Journal(titleId,
                issn,
                eissn,
                issue);

            return journal;
        }
    }
}
