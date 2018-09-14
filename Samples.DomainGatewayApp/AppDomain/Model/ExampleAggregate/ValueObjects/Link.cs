using BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Model.ExampleAggregate.ValueObjects
{
    public class Link : ValueObject
    {
        public string Sample { get; }
        public string Another { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Sample;
            yield return Another;
        }
    }
}
