using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Entities
{

    public class ToolModel
    {
        //[DatabaseGenerat‌ed(DatabaseGeneratedOption.None)]
        public virtual long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        ToolTechnology ToolType { get; set; }

        ToolManufacturer Manufacturer { get; set; }
    }
}
