using BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Model.ExampleAggregate.ValueObjects
{
    public class Logo : ValueObject
    {
        public string Image { get; }
        public string Name { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
