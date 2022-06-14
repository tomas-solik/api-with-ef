using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class ToolManufacturer
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual List<ToolModel> ToolModels { get; set; }
    }
}
