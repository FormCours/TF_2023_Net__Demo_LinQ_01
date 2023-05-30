using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LinQ_3.Models
{
    internal class Teacher : Person
    {
        public string Domain { get; set; }
        public bool IsAppointed { get; set; } = true;
    }
}
