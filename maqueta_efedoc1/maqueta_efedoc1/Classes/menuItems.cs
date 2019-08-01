using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maqueta_efedoc1.Classes
{
    public class menuItems
    {
        public string Name { get; private set; }
        public PackIconKind Icon { get; private set; }

        public menuItems(string name, PackIconKind icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
