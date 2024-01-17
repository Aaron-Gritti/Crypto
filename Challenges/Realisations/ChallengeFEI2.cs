using CryptoClient.Challenges;
using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEI2 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmFeistel feistel = new AlgorithmFeistel();

            while (true)
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message
                if (message == "END") // Condition de fin du challenge
                    break;
                Console.WriteLine(message);

                string image = feistel.SBox(message);
                Console.WriteLine(image);

                // Envoyez l'image résultante au serveur
                Connexion.EnvoyerMessage(image);

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                Console.WriteLine(verdict);
                if (verdict == "Wrong!") { break; } // Challenge raté
                Console.WriteLine(" ");
            }

            Connexion.FermerConnexion();
        }
    }
}