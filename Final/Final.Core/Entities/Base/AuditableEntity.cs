using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities.Base
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public string? DeletedBY { get; set; }

    }
}
