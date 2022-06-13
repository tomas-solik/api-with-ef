using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Entities
{
    public class ToolManufacturer
    {
        //[DatabaseGenerat‌ed(DatabaseGeneratedOption.None)]
        public virtual long Id { get; set; }

        public string Name { get; set; }

        List<ToolModel> ToolModels { get; set; }
    }
}
