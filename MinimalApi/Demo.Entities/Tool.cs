using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Entities
{
    [Table("Tools")]
    public class Tool
    {
        //[DatabaseGenerat‌ed(DatabaseGeneratedOption.None)]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ToolModel Model { get; set; }

        public virtual List<TestPoint> TestPoints { get; set; }

        public virtual int NominalValue { get; set; }
    }
}
