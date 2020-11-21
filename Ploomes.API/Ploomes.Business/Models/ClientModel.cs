using Dapper.Contrib.Extensions;
using Ploomes.API.Cross.Models;
using System;

namespace Ploomes.API.Business.Models
{
    [Table("Client")]
    public class ClientModel : BaseModel
    {
        [ExplicitKey]
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }
    }
}
