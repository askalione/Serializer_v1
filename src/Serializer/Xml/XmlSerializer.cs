using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Xml
{
    abstract class XmlSerializer<TObject> : Serializer<TObject, XElement> where TObject : IObject
    {
        protected XmlSerializer(ISerializationProvider<XElement> serializationProvider) : base(serializationProvider)
        {
        }
    }

    public class XmlSerializer : Serializer<XDocument>
    {
        public override XDocument Serialize<TrootObject>(TrootObject rootObject)
        {
            var rootFormat = Serialize<TrootObject, XElement>(rootObject);
            var document = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
            document.Add(rootFormat);
            return document;
        }

        public override TrootObject Deserialize<TrootObject>(XDocument format)
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            var rootFormat = format.Root;
            return Deserialize<TrootObject, XElement>(rootFormat);
        }
    }
}
