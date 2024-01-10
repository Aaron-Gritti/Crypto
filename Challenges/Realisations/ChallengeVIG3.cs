﻿using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeVIG3 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmeVigenere algorithme = new AlgorithmeVigenere();

            while (true)
            {
                string message = Connexion.RecevoirMessage(); // On récupère le message

                if (message == "END") { break; } // Challenge terminé 

                string message1 = Connexion.RecevoirMessage();

                string messagechiffre = algorithme.Chiffrer(message, message1);
                Connexion.EnvoyerMessage(messagechiffre.ToString());

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}
