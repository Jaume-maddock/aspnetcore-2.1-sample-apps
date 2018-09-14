using BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Model.ExampleAggregate.Enumerations
{
    public class MenuType : Enumeration
    {
        public static MenuType Header = new MenuType(1, nameof(Header).ToLowerInvariant());
        public static MenuType Navbar = new MenuType(2, nameof(Navbar).ToLowerInvariant());
        public static MenuType Footer = new MenuType(3, nameof(Footer).ToLowerInvariant());

        protected MenuType() {}

        public MenuType(int id, string name) : base(id, name) {}

    }
}
