using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Entities
{
    public class TestPoint
    {
        //[DatabaseGenerat‌ed(DatabaseGeneratedOption.None)]
        public virtual long Id { get; set; }

        public virtual decimal TargetTorque { get; set; }

        public virtual decimal TargetAngle { get; set; }

        public virtual Tool Tool { get; set; }
    }
}
