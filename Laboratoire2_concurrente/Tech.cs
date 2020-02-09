using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratoire2_concurrente
{
    class Tech
    {
        private QueueClients queueClients;
        HelpDesk helpd;
        private string nom = "";
        public Random rnd = new Random();
        private bool isWork = false;


        public bool IsWork { get => isWork; set => isWork = value; }
        public QueueClients QueueClients { get => queueClients; set => queueClients = value; }

        public Tech()
        {
            queueClients = new QueueClients();
        }

        public void Run()
        {
            while (true)
            {
                if ((queueClients.PremierServi() != null))
                {
                    Client client = queueClients.PremierServi();
                    queueClients.SupprimerClient();
                    isWork = true;
                    Thread.Sleep(client.TmpsService);
                    isWork = false;
                }      
            }
        }
    }
}
