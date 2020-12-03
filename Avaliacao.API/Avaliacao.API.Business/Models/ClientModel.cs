using Dapper.Contrib.Extensions;
using Avaliacao.API.Cross.Models;
using System;

namespace Avaliacao.API.Business.Models
{
    [Table("Client")]
    public class ClientModel : BaseModel
    {
        [ExplicitKey]
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }
    }
}
