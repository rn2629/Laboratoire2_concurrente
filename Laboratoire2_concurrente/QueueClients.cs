using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire2_concurrente
{
    class QueueClients
    {
        private readonly object verrou = new object();
        public const int MOY_TEMPS_CLIENT = 10;
         
        public List<Client> clients;

            public QueueClients()
        {
            clients = new List<Client>();      
        }

        public void AjouterClient()
        {
            lock(verrou)
            clients.Add(new Client("client"));
        }

        public Client PremierServi()
        {
            lock (verrou)
                if (clients.Count > 0)
                    return clients.First();
                else
                    return null;
        
        }

        public void SupprimerClient()
        {
            lock(verrou)
            clients.Remove(PremierServi());
        }

        public int GetCompteur()
        {
            return clients.Count();
        }


    }
}
