using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeSUB1 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmeCesar algorithme = new AlgorithmeCesar();

            while (true) // Tant que le serveur n'a pas fini d'envoyer des char
            {
                string message1 = Connexion.RecevoirMessage(); // On récupère le message (END ou char)
                if (message1 == "END") { break; } // Challenge terminé 
                char leChar = Convert.ToChar(message1);

                string message2 = Connexion.RecevoirMessage(); // On récupère l'entier
                int leInt = int.Parse(message2);

                char newChar = algorithme.Decalage(leChar, leInt); // On décale
                string final = newChar.ToString();
                Connexion.EnvoyerMessage(final); // On renvoie le charactère décalé

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}
