using System;

namespace Ploomes.Cross.Models
{
    public abstract class BaseModel
    {
        public DateTime? Updated { get; set; }

        public BaseModel()
        {
            Updated = DateTime.Now;
        }
    }
}
