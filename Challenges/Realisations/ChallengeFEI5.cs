using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEI5 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmFeistel algorithme = new AlgorithmFeistel();

            while (true)
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message
                Console.WriteLine(message);
                if (message == "END") { break; } // Challenge terminé 

                string messagechiffre = algorithme.EBox(message);
                Console.WriteLine(messagechiffre);  
                Connexion.EnvoyerMessage(messagechiffre.ToString());

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                Console.WriteLine(verdict +"\n");
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}
