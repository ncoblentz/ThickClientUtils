using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThickClientUtils
{
    public class Rule
    {
        public Rule(string name="", string findRegex="", string replaceString="", bool enabled = true)
        {
            Name = name;
            FindRegex = findRegex;
            ReplaceString = replaceString;
            Enabled = enabled;
        }

        public string Name { get; set; }

        public string FindRegex { get; set; }

        public string ReplaceString { get; set; }

        public bool Enabled { get; set; }

    }
}
