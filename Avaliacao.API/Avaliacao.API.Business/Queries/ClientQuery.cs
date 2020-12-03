using System;

namespace Avaliacao.API.Business.Queries
{
    public class ClientQuery
    {
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }
        public DateTime? Updated { get; set; }
    }
}