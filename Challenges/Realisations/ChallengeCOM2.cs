using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeCOM2 : IChallenge
    {
        /// <summary>
        /// Reçoit un nombre aléatoire et renvoie ce nombre incrémenté de 1 au serveur jusqu'a ce que le serveur arrête d'envoyer des nombres
        /// </summary>
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            while (true) // Tant que le serveur n'a pas fini d'envoyer des nombres
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message

                if (message == "END") { break; } // Challenge terminé 

                Console.WriteLine(message);

                int renvoiInt = int.Parse(message) + 1; // Transforme le message en int et l'incrémente de 1
                string renvoi = renvoiInt.ToString(); // On remet en string
                Connexion.EnvoyerMessage(renvoi); // On envoi

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break ; } // Challenge raté
            }

        }
    }
}
