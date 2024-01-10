using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeSUB3 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmeCesar algorithme = new AlgorithmeCesar();

            while (true) // Tant que le premier message de la séquence n'est pas END
            {
                string message1 = Connexion.RecevoirMessage(); // On récupère le message (END ou un message)
                if (message1 == "END") { break; } // Challenge terminé 

                string message2 = Connexion.RecevoirMessage(); // On récupère la clé
                string final = algorithme.Dechiffre(message1, message2);
                Connexion.EnvoyerMessage(final); // On renvoie le message déchiffré

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}