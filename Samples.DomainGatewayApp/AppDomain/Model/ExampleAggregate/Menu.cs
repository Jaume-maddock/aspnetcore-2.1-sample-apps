using AppDomain.Model.ExampleAggregate.Entities;
using AppDomain.Model.ExampleAggregate.Enumerations;
using AppDomain.Model.ExampleAggregate.ValueObjects;
using BaseDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppDomain.Model.ExampleAggregate
{
    public class Menu : Entity, IAggregateRoot
    {
        [Required]
        public ICollection<MenuItem> Items { get; private set; }

        [Required]
        public MenuType MenuType { get; private set; }

        [Required]
        public Logo MainInfo { get; private set; }


        public Menu(Logo mainInfo, MenuType menuType)
        {
            MainInfo = mainInfo;
            MenuType = menuType;
        }

        public void AddMenuItem(Link link)
        {
            AddMenuItem(link, default(string));
        }

        public void AddMenuItem(Link link, string icon)
        {
            Items.Add(new MenuItem(link, icon));
        }
    }
}
