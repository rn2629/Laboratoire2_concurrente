using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratoire2_concurrente
{
    
    class HelpDesk
    {
        public const int NB_TECHS = 5;
        public const int TEMPS_SERVICE_MOYEN_CLIENT = 10_000;
        public const int PROBA_ARRIVEE_CLIENT = 100;
        public const int TEMPS_TOUR = 500;
        public const int PROBA_FAIT = 500;

        private QueueClients queues;
        private Tech techncs;
        public Random rnd = new Random();
        private string [] techs =
            {
            "Alice",
            "Bob",
            "Charlie",
            "Diane",
            "Eve",
            };

        private int techLibre;
        private int techEnService;
        Tech[] techniciens = new Tech[NB_TECHS];
        Thread[] threads = new Thread[NB_TECHS];

        public HelpDesk()
        {
            techncs = new Tech();
            queues = new QueueClients(); 
        }

        public void Affichage()
        {
            techLibre = 0;
            techEnService = 0;
            int probFait;
            bool faitEnCours =  true; 

            string motClient; // ?????
            Stopwatch heure = new Stopwatch();
            int arriveeClient = rnd.Next(PROBA_ARRIVEE_CLIENT);
            if (arriveeClient == 50)
                queues.AjouterClient();

            while(heure.ElapsedMilliseconds < 100_00)
            {
                if (queues.GetCompteur() + techEnService == 50)
                    motClient = "Bon quest ce que je fais en attendant";// ^^^^^^^^!!@@##!!????
                else
                    motClient = "Clients "; // ??

                Thread.Sleep(TEMPS_TOUR);
                arriveeClient = rnd.Next(PROBA_ARRIVEE_CLIENT);
                if (arriveeClient == 50)
                    queues.AjouterClient();

                foreach(Tech techns in techniciens)
                {
                    if(techncs.IsWork == false)
                        techLibre++;
                  
                }
                foreach(Tech techns in techniciens)
                {
                    if (techncs.IsWork == true)
                        techEnService++;
                }

                Console.Clear();
                Console.WriteLine(queues.GetCompteur() + " Clients Servis ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine(techLibre + " En Service");
                Console.WriteLine(techEnService + " Dommage tous nos techniciens sont en Service");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Il ya exactement " + queues.GetCompteur() + techEnService + " techniciens et " + motClient + " dans la salle");
                Console.WriteLine("-------------------------------");

                if(faitEnCours == true)//?????
                {
                    FaitDivers();
                }

                probFait = rnd.Next(PROBA_FAIT);
                if (probFait == 0)
                    faitEnCours = true;
                else
                    faitEnCours = false;
                 /*   FinFait();*/
            }
        }
        private async Task FaitDivers()
        {
         /*   Task finFait = FinFait();*/
          /*  await finFait;*/
            WebRequest request = WebRequest.Create("http://numbersapi.com/random");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
           // responseFromServer = reader.ReadToEnd();???
            reader.Close();
            dataStream.Close();
            response.Close();
        }

     /*   private async Task FinFait()//????
        {
         //   Console.WriteLine("Hey Toi, c<est finis rentrez chez vous!!! Good Job");
        }*/
    }
}
