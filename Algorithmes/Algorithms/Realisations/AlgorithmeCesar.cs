using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoClient.Algorithmes.Algorithms.Realisations
{
    public class AlgorithmeCesar : IAlgorithm
    {
        public string Chiffrer(string message, string cle)
        {
            int cleInt = int.Parse(cle); // On convertit en entier

            cleInt = (cleInt % 26 + 26) % 26; // On reste dans la fourchette

            char[] caracteres = message.ToCharArray(); // On convertit la chaîne en un tableau de caractères

            for (int i = 0; i < caracteres.Length; i++) // On chiffre chaque caractère dans le tableau
            {
                caracteres[i] = Decalage(caracteres[i], cleInt);
            }
           
            return new string(caracteres); // On convertit le tableau de caractères en une nouvelle chaîne chiffrée
        }

        public string Dechiffre(string message, string cle)
        {
            int cleInt = int.Parse(cle); // On convertit en entier

            cleInt = (cleInt % 26 + 26) % 26; // On reste dans la fourchette

            cleInt = (26 - cleInt) % 26;  // On inverse la clé pour le déchiffrement

            char[] caracteres = message.ToCharArray(); // On convertit la chaîne en un tableau de caractères

            for (int i = 0; i < caracteres.Length; i++) // On déchiffre chaque caractère dans le tableau
            {
                caracteres[i] = Decalage(caracteres[i], cleInt);
            }
            
            return new string(caracteres); // On convertit le tableau de caractères en une nouvelle chaîne déchiffrée
        }

        public char Decalage(char c, int cle)
        {            
            if (!char.IsLetter(c)) // On vérifie si le caractère est une lettre
            {
                return c; // Pas une lettre, au revoir.
            }

            int debut;
            if (char.IsLower(c))
            {
                debut = 'a';
            }
            else
            {
                debut = 'A';
            }

            int decalageResultat = (c - debut + cle) % 26 + debut; // On décale en fonction de la clé

            return (char)decalageResultat; // On renvoie le charactère décalé
        }

    }
}
