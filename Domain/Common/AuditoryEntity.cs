using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditoryEntity
    {
        public virtual int Id { get; set; }        
        public DateTime ModifiedDate { get; set; } 
    }
}
