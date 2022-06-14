using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class Tool
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ToolModel Model { get; set; }

        public virtual List<TestPoint> TestPoints { get; set; }

        public virtual int NominalValue { get; set; }
    }
}
