using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeXOR : IAlgorithm
    {
        /// <summary>
        /// Chiffre un message grâce à la clé donnée
        /// </summary>
        /// <param name="message">le message à chiffrer</param>
        /// <param name="cle">la clé utilisée pour le chiffrement</param>
        /// <returns>le message chiffré</returns>
        public string Chiffrer(string message, string cle)
        {
            char[] resultatXor = new char[message.Length]; // On initialise le resultat

            for (int i = 0; i < message.Length; i++)
            {
                resultatXor[i] = Xor(message[i], cle[i]); // On chiffre le message avec Xor
            }

            return new string(resultatXor);
        }

        /// <summary>
        /// Déchiffre un message à partir d'une clé
        /// </summary>
        /// <param name="message">le message à déchiffrer</param>
        /// <param name="cle">la clé utilisée pour le déchiffrement</param>
        /// <returns>le message déchiffré</returns>
        public string Dechiffre(string message, string cle)
        {
            return Chiffrer(message, cle); // Pour déchiffrer Xor, il faut simplement le 'rechiffrer'
        }

        /// <summary>
        /// Effectue le calcul de Xor
        /// </summary>
        /// <param name="c1">valeur 1</param>
        /// <param name="c2">valeur 2</param>
        /// <returns>le resultat de xor des deux valeurs</returns>
        public char Xor(char c1, char c2) 
        {
            if ((c1 == '0' && c2 == '0') || (c1 == '1' && c2 == '1')) // Le résultat de Xor est 0
            {
                return '0';
            }
            else // Le résultat de Xor est 1 
            {
                return '1';
            }
        }

    }
}
