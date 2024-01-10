using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeXOR3 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmeXOR algorithme = new AlgorithmeXOR();

            while (true)
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message

                if (message == "END") { break; } // Challenge terminé 

                string message1 = Connexion.RecevoirMessage(); 

                string messagechiffre = algorithme.Dechiffre(message, message1);
                Connexion.EnvoyerMessage(messagechiffre);

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}