using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class ToolModel
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual ToolTechnology ToolType { get; set; }

        public virtual ToolManufacturer Manufacturer { get; set; }

        public virtual List<Tool> Tools { get; set; }
    }
}
