using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeVigenere : IAlgorithm
    {
        /// <summary>
        /// Chiffre un message grâce à la clé donnée
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Chiffrer(string message, string cle)
        {
            string chiffre = "";

            for (int i = 0, j = 0; i < message.Length; i++) // Pour la longueur du message
            {
                char caractere = message[i];

                if (char.IsLetter(caractere)) // Si c'est une lettre
                {
                    chiffre += Shift(caractere, cle[j]);
                    j = (j + 1) % cle.Length;
                }
                else // Si c'est pas une lettre
                {
                    chiffre += caractere; // Pas une lettre, on ajoute le caractère non modifié au nouveau message.
                }
            }

            return chiffre;
        }

        /// <summary>
        /// Déchiffre un message à partir d'une clé
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public string Dechiffre(string message, string cle)
        {
            string dechiffre = "";

            for (int i = 0, j = 0; i < message.Length; i++) // Pour la longueur du message
            {
                char caractereChiffre = message[i];

                if (char.IsLetter(caractereChiffre)) // Si c'est une lettre
                {
                    dechiffre += UnShift(caractereChiffre, cle[j]);
                    j = (j + 1) % cle.Length;
                }
                else // Si c'est pas une lettre
                {
                    dechiffre += caractereChiffre; // Pas une lettre, on ajoute le caractère non modifié au nouveau message.
                }
            }

            return dechiffre;
        }

        /// <summary>
        /// Effectue un Shift
        /// </summary>
        /// <param name="c"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public char Shift(char c, char k) 
        {
            if (char.IsLetter(c)) // Si c'est une lettre
            {
                int decalage = char.IsUpper(k) ? k - 'A' : k - 'a'; // On définit un début en fonction de la casse
                return (char)((c + decalage - (char.IsUpper(c) ? 'A' : 'a') + 26) % 26 + (char.IsUpper(c) ? 'A' : 'a')); // On shift
            }
            else // Si c'est pas une lettre 
            {
                return c; // Pas une lettre, au revoir.
            }
        }

        /// <summary>
        /// Effectue un UnShift
        /// </summary>
        /// <param name="c"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public char UnShift(char c, char k)
        {
            if (char.IsLetter(c)) // Si c'est une lettre
            {
                int decalage = char.IsUpper(k) ? k - 'A' : k - 'a'; // On définit un début en fonction de la casse
                return (char)((c - decalage - (char.IsUpper(c) ? 'A' : 'a') + 26) % 26 + (char.IsUpper(c) ? 'A' : 'a')); // On UnShift
            }
            else // Si c'est pas une lettre 
            {
                return c; // Pas une lettre, au revoir.
            }
        }

    }
}
