using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Objects
{
    public class Issue : IObject
    {
        public string Volume { get; }
        public string Number { get; }
        public string AltNumber { get; }
        public string Part { get; }
        public string Pages { get; }
        public int YearPubl { get; }

        public Issue(string volume,
            string number,
            string altNumber,
            string part,
            string pages,
            int yearPubl
            )
        {
            Volume = volume?.Trim();
            Number = number?.Trim();
            AltNumber = altNumber?.Trim();
            Part = part?.Trim();
            Pages = pages?.Trim();
            YearPubl = yearPubl;
        }
    }
}
