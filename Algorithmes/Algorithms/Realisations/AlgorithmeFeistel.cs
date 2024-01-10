using CryptoClient.Algorithmes.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmFeistel : IAlgorithm
    {
        private readonly string[] sbox;

        public AlgorithmFeistel()
        {
            //sbox = ChargerSbox("Sbox.txt");
        }

        public string Chiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        public string Dechiffre(string message, string cle)
        {
            throw new NotImplementedException();
        }

        private string[] ChargerSbox(string fichierSbox)
        {
            throw new NotImplementedException();
        }

        private string HexToBin32(string hex)
        {
            throw new NotImplementedException();
        }

        private string PBox(string input)
        {
            throw new NotImplementedException();
        }

        private string SBox(string input)
        {
            throw new NotImplementedException();
        }

        public string EBox(string input)
        {
            string eBoxed = input;
            for (int i = 0; i< input.Length; i+=3)
            {         
                eBoxed.Insert(i, (input[i].ToString()));
            }
            return eBoxed;
        }

        private string Add32(string a, string b)
        {
            throw new NotImplementedException();
        }

        private string F(string m1, string ki)
        {
            throw new NotImplementedException();
        }

        private string ClePartielle(string cle, int tour)
        {
            throw new NotImplementedException();
        }

        private string TourDechiffrement(string message, string k1, string k2)
        {
            throw new NotImplementedException();
        }
    }
}

