using System;

namespace Ploomes.Business.Queries
{
    public class ClientQuery
    {
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }
        public DateTime? Updated { get; set; }
    }
}