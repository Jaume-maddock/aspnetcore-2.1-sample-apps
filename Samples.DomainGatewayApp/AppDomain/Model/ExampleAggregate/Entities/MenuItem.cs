using AppDomain.Model.ExampleAggregate.ValueObjects;
using BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Model.ExampleAggregate.Entities
{
    public class MenuItem : Entity
    {
        public Link Link { get; private set; }

        public string Icon { get; private set; }

        public MenuItem(Link link, string icon)
        {
            Link = link;
            Icon = icon;
        }

    }
}
