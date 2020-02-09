using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire2_concurrente
{
    class Client
    {
        private string nom = "";
        Random rnd = new Random();
        private int tmpsService;

        public Client(string Nom)
        {
            Nom = nom;
            this.tmpsService = (int)(-(HelpDesk.TEMPS_SERVICE_MOYEN_CLIENT) * Math.Log(1 - rnd.NextDouble())); ;
        }

        public string Nom
        {
            get;
            set;
        }

        public int TmpsService
        {
            get => tmpsService;
            set => tmpsService = value;
        }
    }
}
