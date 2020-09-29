using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavEditor.Models
{
    public class DropdownItem
    {
        public DropdownItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
