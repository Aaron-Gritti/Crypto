using CryptoClient.Algorithmes.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            byte[] bytes = Enumerable.Range(0, hex.Length / 2).Select(i => Convert.ToByte(hex.Substring(2 * i, 2), 16)).ToArray();

            string bin = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                string byteBinary = Convert.ToString(bytes[i], 2).PadLeft(8, '0');
                bin += byteBinary;
            }

            return bin;
        }

        public string PBox(string input)
        {
            int[] pboxPermutation = { 9, 17, 23, 31, 13, 28, 2, 18, 24, 16, 30, 6, 26, 20, 10, 1, 8, 14, 25, 3, 4, 29, 11, 19, 32, 12, 22, 7, 5, 27, 15, 21 };

            char[] output = new char[32];

            for (int i = 0; i < 32; i++)
            {
                output[i] = input[pboxPermutation[i] - 1];
            }

            return new string(output);
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
            // Convertit les chaînes binaires en tableaux de bits
            bool[] aBits = new bool[32];
            bool[] bBits = new bool[32];

            for (int i = 0; i < 32; i++)
            {
                aBits[i] = (a[31 - i] == '1');
                bBits[i] = (b[31 - i] == '1');
            }

            // Effectue l'addition modulo 2 de a et b
            bool[] resBits = new bool[32];
            for (int i = 0; i < 32; i++)
            {
                resBits[i] = aBits[i] ^ bBits[i];
            }

            // Convertit le résultat en chaîne binaire
            string res = "";
            for (int i = 31; i >= 0; i--)
            {
                res += (resBits[i] ? '1' : '0');
            }

            return res;
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

