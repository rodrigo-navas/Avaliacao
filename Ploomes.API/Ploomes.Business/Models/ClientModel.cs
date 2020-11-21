using Dapper.Contrib.Extensions;
using Ploomes.Cross.Models;
using System;

namespace Ploomes.Business.Models
{
    [Table("Client")]
    public class ClientModel : BaseModel
    {
        [ExplicitKey]
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }
    }
}
