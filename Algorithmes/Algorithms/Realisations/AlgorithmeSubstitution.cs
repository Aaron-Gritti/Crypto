using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeSubstitution : IAlgorithm
    {
        public string Chiffrer(string message, string cle)
        {
            string messageChiffre = "";

            foreach (char caractere in message) // On Swap chaque caractère
            {
                char caractereChiffre = Swap(caractere, cle);
                messageChiffre += caractereChiffre;
            }

            return messageChiffre;
        }

        public string Dechiffre(string message, string cle)
        {
            string messageDéchiffré = "";

            foreach (char caractereChiffre in message) // On UnSwap chaque caractère
            {
                char caractereDéchiffré = UnSwap(caractereChiffre, cle);
                messageDéchiffré += caractereDéchiffré;
            }

            return messageDéchiffré;
        }

        /// <summary>
        /// Effectue un swap
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public char Swap(char c, string cle)
        {
            if (char.IsLetter(c)) // Si le char est une lettre
            {
                int index = char.ToUpper(c) - 'A'; // On simplifie en effectuant une Fuuusion de l'algo en fonction de la casse
                if (index >= 0 && index < cle.Length)
                {
                    char caractereChiffre = char.IsLower(c) ? char.ToLower(cle[index]) : cle[index]; // On remet la casse comme elle l'était
                    return caractereChiffre;
                }
            }
            return c; // Si non lettre, renvoie non modifié
        }

        /// <summary>
        /// Effcetue un Swap, mais à l'envers
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cle"></param>
        /// <returns></returns>
        public char UnSwap(char c, string cle)
        {
            if (char.IsLetter(c)) // Si le char est une lettre
            {
                int index = cle.IndexOf(char.ToUpper(c)); // On simplifie en effectuant une Fuuusion de l'algo en fonction de la casse
                if (index != -1)
                {
                    char caractereDechiffre = char.IsLower(c) ? char.ToLower((char)('A' + index)) : (char)('A' + index); // On remet la casse comme elle l'était
                    return caractereDechiffre;
                }
            }
            return c;
        }
    }
}
