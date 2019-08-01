using prueba_template_op.Classes.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_template_op
{
    public class MenuItem
    {
        public String Name { get; private set; }
        public String Icon { get; private set; }
        public ItemCount Count { get; private set; }

        public MenuItem(String name, String icon, ItemCount count)
        {
            Name = name;
            Icon = icon;
            Count = count;
        }
    }
}
