using CryptoClient.Challenges;
using CryptoClient.Reseau;
using System;
using System.Net.Sockets;

namespace CryptoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Connexion.OuvrirConnexion();

            string setup = Connexion.RecevoirMessage();
            Console.WriteLine(setup);

            IChallenge chall = FabriqueChallenge.Creer(setup);
            chall.Executer();

            Connexion.FermerConnexion(); // On ferme la connexion
        }
    }
}
