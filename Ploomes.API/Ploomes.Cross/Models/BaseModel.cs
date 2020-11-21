using System;

namespace Ploomes.API.Cross.Models
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
