using VigenereCracker.Alphabets;

namespace VigenereCracker
{
    class Tools
    {
        /// <summary>
        /// Providing a number N, give all the numbers which N can be divided with, except 1
        /// </summary>
        /// <param name="number">The number N</param>
        /// <returns></returns>
        public static List<int> getFactors(int number)
        {
            List<int> factors = new List<int>();
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }
            factors.Add(number);
            return factors;
        }

        /// <summary>
        /// Try all the possible decryptions of a crypted text using Caesar Cipher and an alphabet
        /// </summary>
        /// <param name="cryptedText">Text to be decrypted</param>
        /// <param name="alphabet">Alphabet to be used</param>
        /// <returns>Returns all the possible decryptions sorted by descending probability of being the right one</returns>
        public static List<CaesarPossibleDecryption> breakCaesar(string cryptedText, Alphabet alphabet)
        {
            List<CaesarPossibleDecryption> possibleDecryptions = new List<CaesarPossibleDecryption>();

            // Trying all the possible shifting
            for (int i = 0; i < alphabet.Length; ++i)
            {
                // Decrypting the text with the current key
                string decryptedText = decryptCaesar(cryptedText, i, alphabet);

                // Calculating the function of correlation
                float correlation = alphabet.FunctionCorrelation(cryptedText, i);

                possibleDecryptions.Add(new CaesarPossibleDecryption(correlation, i, decryptedText));
            }

            // Sorting the list by descending probability of being right. 
            // The probability grows with the value of the function of correlation
            possibleDecryptions.Sort(
                delegate(CaesarPossibleDecryption c1, CaesarPossibleDecryption c2)
                {
                    return c2.Correlation.CompareTo(c1.Correlation);
                }
                );

            return possibleDecryptions;
        }


        /// <summary>
        /// Encrypt a clear text by shifting the letters with a key in an alphabet
        /// </summary>
        /// <param name="clearText">Text to be shifted. It must be normalize first. Otherwise, specials characters could be deleted</param>
        /// <param name="key">Value of the shifting. It must be positive. Otherwise, it will be set to 0 and no shifting will be performed</param>
        /// <param name="alphabet">Alphabet in which the shifting will be performed</param>
        /// <returns>Returns the encrypted text</returns>
        public static string encryptCaesar(string clearText, int key, Alphabet alphabet)
        {
            string cryptoText = "";

            // Control of the key.
            key = key < 0 ? 0 : key % alphabet.Length;

            // Shifting all the letters of the clear text
            foreach (char character in clearText)
            {
                // Getting the index in the alphabet of the current character
                int index = alphabet.GetIndex(character);
                // Adding the sifhted character to the cryptoText
                cryptoText += alphabet.GetChar((index + key) % alphabet.Length);
            }

            return cryptoText;
        }

        /// <summary>
        /// Decrypts a crypted text by unshifting the letters with a key in an alphabet 
        /// </summary>
        /// <param name="cryptoText">Text to be unshifted.</param>
        /// <param name="key">Value of the unshifting. It must be positive. Otherwise, it will be set to 0 and no unshifting will be performed </param>
        /// <param name="alphabet">Alphabet in which the unshifting will be performed</param>
        /// <returns>Returns the clear text</returns>
        public static string decryptCaesar(string cryptoText, int key, Alphabet alphabet)
        {
            string clearText = "";

            // Control of the key
            key = key < 0 ? 0 : key % alphabet.Length;

            // Shifting all the letters of the userInput 
            foreach (char character in cryptoText)
            {
                // Getting the index in the alphabet of the current character
                int index = alphabet.GetIndex(character);

                /* Adding the unsifhted character to the clearText
                 * The modulus works differently with negative values, 
                 * the length of the alphabet is added to make it positive.
                 * It doesn't change the result because of the modulus */
                clearText += alphabet.GetChar((index + alphabet.Length - key) % alphabet.Length);
            }

            return clearText;
        }

        /// <summary>
        /// Merge a list of alphabets ("columns") in one single text.
        /// </summary>
        /// <example>
        /// ("hl", "ep") will give "help
        /// because if we place them in columns,
        /// HE
        /// LP
        /// and read it from the up-left to the bottom-right, we see "help"
        /// </example>
        /// <param name="splittedAlphabets">List of all the alphabets</param>
        /// <returns>Returns the merged text</returns>
        public static string mergeAlphabets(List<string> splittedAlphabets)
        {
            string result = "";
            int maxLength = 0; // Will contain the length of the longer alphabet

            // Calculating the maxLength
            foreach (string splittedAlphabet in splittedAlphabets)
            {
                maxLength = Math.Max(maxLength, splittedAlphabet.Length);
            }

            // Traversing splitted alphabets
            for (int i = 0; i < maxLength; ++i)
            {
                foreach (string splittedAlphabet in splittedAlphabets)
                {
                    // If there is still a character to read in the alphabet ("column"), adding it to the result
                    if (splittedAlphabet.Length > i)
                    {
                        result += splittedAlphabet[i];
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Splits a text into lengthOfKey alphabets ("columns").
        /// </summary>
        /// <example>
        /// The word "help" with a key of 2 will be splitted
        /// in ("hl", "ep") because if we put in 2 columns, that gives us:
        /// HE
        /// LP
        /// </example>
        /// <param name="text">Text to be splitted</param>
        /// <param name="lengthOfKey">Length of the key</param>
        /// <returns>Returns the list of the alphabets ("columns")</returns>
        public static List<string> splitAlphabets(string text, int lengthOfKey)
        {
            string[] alphabets = new string[lengthOfKey];

            // Extracting alphabets
            for (int i = 0; i < text.Length; ++i)
            {
                alphabets[i % lengthOfKey] += text[i];
            }

            List<string> results = new List<string>();
            results.AddRange(alphabets);
            return results;
        }

        /// <summary>
        /// Calculate the average of indices of coincidence for the crypted text
        /// given the length of the key.
        /// </summary>
        /// <param name="cryptedText">Crypted Text to be used</param>
        /// <param name="lenghtOfKey">Length of the key to be tested</param>
        /// <returns>Returns the average of indices of coincidence for the crypted text</returns>
        public static float calculateIndexCoincidence(string cryptedText, int lenghtOfKey, Alphabet alphabet)
        {
            /* Algorithm:
             * We have to extract all the alphabets of the text and
             * then calculate the average of all the ICs.
             */

            if (lenghtOfKey <= 0)
                return 0.0f;

            float accumulator = 0.0f; // contains the sum of each IC

            string[] alphabets = new string[lenghtOfKey];

            // Extracting alphabets. 
            // The characters number 1, 1 + length, 1 + 2 * length, etc go into the first alphabet and so on
            for (int i = 0; i < cryptedText.Length; ++i)
            {
                alphabets[i % lenghtOfKey] += cryptedText[i];
            }

            // Aggregating the indices
            for (int i = 0; i < lenghtOfKey; ++i)
            {
                accumulator += alphabet.IndexCoincidence(alphabets[i]);
            }

            // Calculating the average
            return accumulator / lenghtOfKey;
        }


        /// <summary>
        /// Encrypts a clear text using the Vigenère Cipher and a key in an alphabet
        /// </summary>
        /// <param name="clearText">Text to be encrypted</param>
        /// <param name="key">
        /// Key to be used. It must contains only lowercase and no special characters. 
        /// Otherwise, no encryption will be performed by the incriminated character
        /// </param>
        /// <param name="alphabet">Alphabet to be used</param>
        /// <returns>Returns the encrypted text</returns>
        public static string encryptVigenere(string clearText, string key, Alphabet alphabet)
        {
            string cryptoText = "";
            for (int i = 0; i < clearText.Length; ++i)
            {
                /* Getting the character of the key that will be used to encrypt the current character of the text
                 * and transforming it to have an integer */
                int keyInt = alphabet.GetIndex(key[i % key.Length]);
                // Applying the Caesar Cipher to the character to encrypt with the key 
                cryptoText += encryptCaesar(clearText[i].ToString(), keyInt, alphabet);
            }

            return cryptoText;
        }

        /// <summary>
        /// Decrypts a encrypted text using the Vigenère Cipher and a key in an alphabet
        /// </summary>
        /// <param name="cryptoText">Encrypted text</param>
        /// <param name="key">
        /// Key to be used. It must contains only lowercase and no special characters. 
        /// Otherwise, no decryption will be performed by the incriminated character
        /// </param>
        /// <param name="alphabet">Alphabet to be used</param>
        /// <returns>Returns the decrypted text</returns>
        public static string decryptVigenere(string cryptoText, string key, Alphabet alphabet)
        {
            string clearText = "";
            for (int i = 0; i < cryptoText.Length; ++i)
            {
                /* Getting the character of the key that will be used to decrypt the current character of the text
                 * and transforming it to have an integer */
                int keyInt = alphabet.GetIndex(key[i % key.Length]);
                // Applying the Caesar Cipher to the character to decrypt it with the key 
                clearText += Tools.decryptCaesar(cryptoText[i].ToString(), keyInt, alphabet);
            }

            return clearText;
        }

    }
}
