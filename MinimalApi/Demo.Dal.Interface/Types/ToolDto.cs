using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal.Interface.Types
{
    public class ToolDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ToolModel { get; set; }

        public string ToolManufacturer { get; set; }

        public int NominalValue { get; set; }

    }
}
