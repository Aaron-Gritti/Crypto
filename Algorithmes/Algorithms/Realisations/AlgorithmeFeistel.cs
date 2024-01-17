using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmFeistel : IAlgorithm
    {
        private string[] sbox;

        public string Chiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        public string Dechiffre(string message, string cle)
        {
            throw new NotImplementedException();
        }

        public AlgorithmFeistel()
        {
            sbox = new string[256];

            using (StreamReader fichier = File.OpenText("Resources\\sbox.txt"))
            {
                string ligne;
                int i = 0;
                while ((ligne = fichier.ReadLine()) != null)
                {
                    string[] ligneS = ligne.Split(",");

                    foreach (string partie in ligneS)
                    {
                        if (partie != "")
                        {
                            sbox[i] = HexToBin32(partie);
                            i++;
                        }
                    }
                }
            }
        }

        private string HexToBin32(string hex)
        {
            string bin = Convert.ToString(Convert.ToInt64(hex, 16), 2);

            return bin.PadLeft(32, '0');
        }

        public string PBox(string message)
        {
            string renvoi = "";
            renvoi += message[16 - 1];
            renvoi += message[7 - 1];
            renvoi += message[20 - 1];
            renvoi += message[21 - 1];
            renvoi += message[29 - 1];
            renvoi += message[12 - 1];
            renvoi += message[28 - 1];
            renvoi += message[17 - 1];
            renvoi += message[1 - 1];
            renvoi += message[15 - 1];
            renvoi += message[23 - 1];
            renvoi += message[26 - 1];
            renvoi += message[5 - 1];
            renvoi += message[18 - 1];
            renvoi += message[31 - 1];
            renvoi += message[10 - 1];
            renvoi += message[2 - 1];
            renvoi += message[8 - 1];
            renvoi += message[24 - 1];
            renvoi += message[14 - 1];
            renvoi += message[32 - 1];
            renvoi += message[27 - 1];
            renvoi += message[3 - 1];
            renvoi += message[9 - 1];
            renvoi += message[19 - 1];
            renvoi += message[13 - 1];
            renvoi += message[30 - 1];
            renvoi += message[6 - 1];
            renvoi += message[22 - 1];
            renvoi += message[11 - 1];
            renvoi += message[4 - 1];
            renvoi += message[25 - 1];

            return renvoi;
        }

        public string SBox(string message)
        {
            int entier = Convert.ToInt32(message, 2);
            return this.sbox[entier];
        }

        public string EBox(string message)
        {
            string renvoi = "";

            int pos = 0;
            for (int i = 0; i < message.Length; i++)
            {
                renvoi += message[pos];
                if (pos % 3 == 0)
                {
                    renvoi += message[pos];
                }
                pos++;
            }
            return renvoi;
        }

        private string Add32(string nb1, string nb2)
        {
            long number1 = Convert.ToInt64(nb1, 2);
            long number2 = Convert.ToInt64(nb2, 2);

            long renvoi = (number1 + number2) % (long)Math.Pow(2, 32);

            string bin = Convert.ToString(renvoi, 2);

            return bin.PadLeft(32, '0');
        }

        public string F(string message, string cle)
        {
            AlgorithmTransposition algoTranspiDuBibi = new AlgorithmTransposition();

            string transpi = algoTranspiDuBibi.Chiffrer(message, cle);

            string sBox = transpi.Substring(0, 8);
            string eBox = transpi.Substring(8, 24);

            string outSBox = SBox(sBox);
            string outEBox = EBox(eBox);

            string add32 = Add32(outEBox, outSBox);

            return PBox(add32);
        }

        public string ClePartielle(string cle, int numTour)
        {
            AlgorithmeVigenere vig = new AlgorithmeVigenere();
            AlgorithmeCesar ces = new AlgorithmeCesar();
      
            string cle1 = ces.Chiffrer(cle, numTour.ToString());
       
            string cle2 = vig.Chiffrer(cle, cle1);

            return cle2;
        }

        private string TourDechiffrement(string message, string cle, int numTour)
        {
            string leftHalf = message.Substring(0, message.Length / 2);
            string rightHalf = message.Substring(message.Length / 2);

            string newRightHalf = Add32(leftHalf, F(rightHalf, ClePartielle(cle, numTour)));
            string newLeftHalf = rightHalf;

            return newLeftHalf + newRightHalf;
        }

    }
}