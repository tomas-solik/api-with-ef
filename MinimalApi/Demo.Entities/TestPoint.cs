using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class TestPoint
    {
        public virtual long Id { get; set; }

        public virtual decimal TargetTorque { get; set; }

        public virtual decimal TargetAngle { get; set; }

        public virtual Tool Tool { get; set; }
    }
}
