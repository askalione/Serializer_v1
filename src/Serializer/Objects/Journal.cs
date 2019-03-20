using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Objects
{
    public class Journal : IRootObject
    {
        public int TitleId { get;}
        public string Issn { get; }
        public string Eissn { get; }
        public Issue Issue { get; }

        public Journal(int titleId,
            string issn,
            string eissn,
            Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            TitleId = titleId;
            Issn = issn?.Trim();
            Eissn = eissn?.Trim();
            Issue = issue;
        }
    }
}
