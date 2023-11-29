using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primary_constructors
{
    internal class BasicClassPrimaryConstructor(string parameter1, string parameter2)
    {
        public string Parameter1 { get; set; } = parameter1;
        public string Parameter2 { get; set; } = parameter2;
    }
}
