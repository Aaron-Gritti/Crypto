using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEISTEL1 : IChallenge
    {
        /// <summary>
        /// Le serveur envoie une série de chaines de caractères de longueur 32 et attend que votre client renvoie leurs images par la PBox.
        /// </summary>
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            while (true) // Tant que le serveur n'a pas fini d'envoyer des nombres
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message
                Console.WriteLine(message);

                if (message == "END") { break; } // Challenge terminé 

                AlgorithmFeistel feistel = new AlgorithmFeistel();

                string reponse = feistel.PBox(message);
                Connexion.EnvoyerMessage(reponse); // On envoi
                Console.WriteLine(reponse);

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break ; } // Challenge raté
                Console.WriteLine(verdict);
            }

        }
    }
}
