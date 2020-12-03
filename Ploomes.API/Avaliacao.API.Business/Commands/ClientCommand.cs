using Avaliacao.API.Business.Exceptions;
using System;

namespace Avaliacao.API.Business.Commands
{
    public class ClientCommand
    {
        public Guid IdClient { get; set; }
        public string NameClient { get; set; }

        public void Validate()
        {
            if (IdClient == Guid.Empty)
                throw new ValidateException("Property IdClient invalid!");

            if (string.IsNullOrEmpty(NameClient) || NameClient.Length > 150)
                throw new ValidateException("Property NameClient invalid!");
        }
    }
}
