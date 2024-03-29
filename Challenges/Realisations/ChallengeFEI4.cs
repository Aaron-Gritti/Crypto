﻿using CryptoClient.Algorithmes.Algorithms.Realisations;
using CryptoClient.Reseau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Challenges.Realisations
{
    public class ChallengeFEI4 : IChallenge
    {
        public void Executer()
        {
            Connexion.EnvoyerMessage("OK"); // okay 👌

            AlgorithmFeistel algorithme = new AlgorithmFeistel();

            while (true)
            {
                string cle = Connexion.RecevoirMessage(); // On récupère la clé
                Console.WriteLine("Cle reçue : " + cle);
                if (cle == "END") { break; } // Challenge terminé 

                string tour = Connexion.RecevoirMessage();// On récupère le numéro de tour
                Console.WriteLine("Tour reçu : "+tour);

                string image = algorithme.ClePartielle(cle, int.Parse(tour));
                Console.WriteLine("Cle partielle: "+image);  
                Connexion.EnvoyerMessage(image.ToString());

                string verdict = Connexion.RecevoirMessage(); // On regarde les résultats
                Console.WriteLine("Verdict: " + verdict +"\n");
                if (verdict == "Wrong!") { break; } // Challenge raté
            }
        }
    }
}
