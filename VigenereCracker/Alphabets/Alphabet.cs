using System.Text.RegularExpressions;

namespace VigenereCracker.Alphabets
{
    public abstract class Alphabet
    {
        protected List<char> characters;
        protected List<float> theoreticalFrequencies;
        protected float theoreticalIC;

        public float TheoreticalIC
        {
            get { return theoreticalIC; }
        }

        public int Length
        {
            get { return characters.Count; }
        }

        public List<char> getAlphabet()
        {
            return characters;
        }

        public List<float> getTheoreticalFrequencies()
        {
            return theoreticalFrequencies;
        }

        public static char transformDiacritic(char c)
        {
            switch (c)
            {
                case 'à':
                case 'À':
                case 'â':
                case 'Â': c = 'a';
                    break;
                case 'ç': c = 'c';
                    break;
                case 'é':
                case 'É':
                case 'è':
                case 'È':
                case 'ë':
                case 'Ë':
                case 'ê':
                case 'Ê': c = 'e';
                    break;
                case 'ï':
                case 'Ï':
                case 'î':
                case 'Î': c = 'i';
                    break;
                case 'ô':
                case 'Ô': c = 'o';
                    break;
                case 'ù':
                case 'Ù':
                case 'ü':
                case 'Ü':
                case 'û':
                case 'Û': c = 'u';
                    break;
                case 'ÿ': c = 'y';
                    break;
                default:
                    break;
            }
            return c;
        }

        public static string transformLigature(char c)
        {
            string noLigature;
            switch (c)
            {
                case 'æ':
                case 'Æ': noLigature = "ae";
                    break;
                case 'œ':
                case 'Œ': noLigature = "oe";
                    break;
                default: noLigature = c.ToString();
                    break;
            }
            return noLigature;
        }

        public int GetIndex(char character)
        {
            return characters.IndexOf(character);
        }

        public char GetChar(int index)
        {
            if (index >= Length || index < 0)
                return ' ';

            return characters[index];
        }

        /// <summary>
        /// Calculate the function of correlation of the crypted text if it was decrypted with the key
        /// </summary>
        /// <param name="cryptedText">Text to test</param>
        /// <param name="key">Key to test. Must be positive. Otherwise, it will be set to 0</param>
        /// <returns>Returns the value of the function of correlation as a floating point number</returns>
        public float FunctionCorrelation(string cryptedText, int key)
        {
            /* Algorithm :
             * The function of correlation is the sum, for each character in the alphabet, of 
             * the calculated frequency of the character times the theoretical frequency of the character minus the key 
             */ 
             
            float result = 0;
            key = key % Length;

            foreach (char character in characters)
            {
                int index = GetIndex(character);
                int count = Regex.Matches(cryptedText, character.ToString()).Count; // Returns the number of occurence of the character in the text
                float calculatedFrequency = (float)count / cryptedText.Length;
                // To avoid accessing a negative index of the array, we add the length of the alphabet and then perform a modulus
                result += calculatedFrequency * theoreticalFrequencies[(index - key + Length) % Length];
            }

            return result;
        }

        public float IndexCoincidence(string cryptedText)
        {
            /* Algorithm :
             * The formula for the IC of an alphabet is 1 over N(N-1) times the sum for each character of 
             * n(c)(n(c)-1) where n(c) is the number of c in the text and N the length of the text
             */

            float index = 0.0f;
            foreach (char character in characters)
            {
                int count = Regex.Matches(cryptedText, character.ToString()).Count;
                index += (count * (count - 1));
            }

            return index / (cryptedText.Length * (cryptedText.Length - 1));
        }
    }
}
