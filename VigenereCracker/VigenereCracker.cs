using System.Globalization;
using System.Text.RegularExpressions;
using VigenereCracker.Alphabets;

namespace VigenereCracker
{
    public partial class VigenereCracker : Form
    {
        // *** TEMP ***
        private string testForNormalizing = "UPPER lower _$^ù*!special:v;~#characters{ diacritics à À â Â ç é É è È ë Ë ê Ê ï Ï î Î ô Ô ù Ù û Û ü Ü ÿ ligatures æ Æ œ Œ Swedish åäöÅÄÖ";
        private string testForFindingPatterns = "RIKVBIYBITHUSEVAZMMLTKASRNHPNPZICSWDSVMBIYFQEZUBZPBRGYNTBURMBECZQKBMBPAWIXSOFNUZECNRAZFPHIYBQEOCTTIOXKUNOHMRGCNDDXZWIRDVDRZYAYYICPUYDHCKXQIECIEWUICJNNACSAZZZGACZHMRGXFTILFNNTSDAFGYWLNICFISEAMRMORPGMJLUSTAAKBFLTIBYXGAVDVXPCTSVVRLJENOWWFINZOWEHOSRMQDGYSDOPVXXGPJNRVILZNAREDUYBTVLIDLMSXKYEYVAKAYBPVTDHMTMGITDZRTIOVWQIECEYBNEDPZWKUNDOZRBAHEGQBXURFGMUECNPAIIYURLRIPTFOYBISEOEDZINAISPBTZMNECRIJUFUCMMUUSANMMVICNRHQJMNHPNCEPUSQDMIVYTSZTRGXSPZUVWNORGQJMYNLILUKCPHDBYLNELPHVKYAYYBYXLERMMPBMHHCQKBMHDKMTDMSSJEVWOPNGCJMYRPYQELCDPOPVPBIEZALKZWTOPRYFARATPBHGLWWMXNHPHXVKBAANAVMNLPHMEMMSZHMTXHTFMQVLILOVVULNIWGVFUCGRZZKAUNADVYXUDDJVKAYUYOWLVBEOZFGTHHSPJNKAYICWITDARZPVU";
        // *** END TEMP ***

        // Will contains the normalized user input.
        private string normalizedText;

        public VigenereCracker()
        {
            InitializeComponent();
            // *** TEMP ***
            tbUserInput.Text = testForFindingPatterns;
            // *** END TEMP ****
            normalizedText = "";
        }

        private void VigenereCracker_Load(object sender, EventArgs e)
        {
            cbbLanguage.SelectedIndex = 0; // English is the default language
        }

        /// <summary>
        /// Normalize a string by taking off ligatures, diacritics, uppercase, etc...
        /// </summary>
        /// <param name="userInput">The string to normalize</param>
        /// <returns>Returns a string with only lowercase, not special characters</returns>
        private string normalize(string userInput)
        {
            string normalizedTextTemp = "";
            for (int i = 0; i < userInput.Length; i++)
            {
                // Result in a string and not in a char, because a ligature could be transformed in 2 characters
                string temp;
                Regex regexCharacter = null;
                switch (cbbLanguage.SelectedIndex)
                {
                    // English
                    case 0: temp = Alphabet.transformDiacritic(userInput[i]).ToString(); // Transform diacritics
                        temp = temp.ToLower(); // Set lowercase letters
                        regexCharacter = new Regex("^[a-z]$"); // The string must contains 1 lowercase letter
                        break;
                    // French
                    // Transform diacritics and ligatures
                    case 1: temp = Alphabet.transformLigature(Alphabet.transformDiacritic(userInput[i])).ToString();
                        temp = temp.ToLower(); // Set lowercase letters
                        // The string must contains either 1 or 2 lowercase letter (2 because of a ligature)
                        regexCharacter = new Regex("^[a-z]{1,2}$");
                        break;
                    // Swedish
                    case 2: temp = Alphabet.transformDiacritic(userInput[i]).ToString(); // Transform diacritics
                        // Set lowercase letters with the Swedish culture : allow Å Ä Ö to be processed
                        temp = temp.ToLower(CultureInfo.GetCultureInfo("sv-SE"));
                        // The string must contains 1 lowercase letter, in the 29 letters Swedish alphabet
                        regexCharacter = new Regex("^[a-zåäö]$");
                        break;
                    // Unhandled language
                    default: temp = "";
                        regexCharacter = new Regex("^$");
                        break;
                }
                if (regexCharacter.IsMatch(temp))
                {
                    normalizedTextTemp += temp;
                }
            }

            return normalizedTextTemp;
        }


        private void normalizeUserInput()
        {           
            // Normalize the user input and put it in the variable "normalizedText"
            normalizedText = normalize(tbUserInput.Text);
        }


        #region Caesar Cipher

        private void btnEncryptCaesar_Click(object sender, EventArgs e)
        {
            // Handler called when the button to encrypt with the Caesar Cipher is pressed

            Alphabet alphabet = getAlphabet();

            normalizeUserInput();

            if (normalizedText.Length <= 0)
                return;

            // To avoid too big keys
            int key = (int)(nuKeyCaesar.Value % alphabet.Length);
            nuKeyCaesar.Value = key;

            tbUserOutput.Text = Tools.encryptCaesar(normalizedText, key, alphabet);
        }

        private void btnDecryptCaesar_Click(object sender, EventArgs e)
        {
            // Handler called when the button to decrypt with the Caesar Cipher is pressed

            Alphabet alphabet = getAlphabet();

            normalizeUserInput();

            if (normalizedText.Length <= 0)
                return;

            // To avoid too big keys
            int key = (int)(nuKeyCaesar.Value % alphabet.Length);
            nuKeyCaesar.Value = key;

            tbUserOutput.Text = Tools.decryptCaesar(normalizedText, key, alphabet);
        }

        private void btnBreakCaesar_Click(object sender, EventArgs e)
        {
            // Handler called when the button to break the Caesar Cipher is pressed

            normalizeUserInput();
            string userInput = normalizedText;

            if (normalizedText.Length <= 0)
                return;

            Alphabet alphabet = getAlphabet();

            // Getting all the possible decryptions
            List<CaesarPossibleDecryption> possibleDecryptions = Tools.breakCaesar(userInput, alphabet);

            string output = "";
            // Printing the frist three in the output
            for (int i = 0; i < Math.Min(3, possibleDecryptions.Count); ++i)
            {
                output += (i + 1).ToString() + ". Key = " + possibleDecryptions[i].Key.ToString() + ", Correlation = " + possibleDecryptions[i].Correlation.ToString() + Environment.NewLine
                    + possibleDecryptions[i].DecryptedText + Environment.NewLine;
            }

            tbUserOutput.Text = output;
        }


        #endregion

        #region Vigenère Cipher

        private void btnEncryptVigenere_Click(object sender, EventArgs e)
        {
            // Handler called when the button to encrypt with the Vigenère Cipher is pressed
            Alphabet alphabet = getAlphabet();

            normalizeUserInput();
            normalizeKeyVigenere();
            string key = tbKeyVigenere.Text;

            if (normalizedText.Length <= 0)
                return;

            // Control of the key
            if (key.Length <= 0)
                return;

            tbUserOutput.Text = Tools.encryptVigenere(normalizedText, key, alphabet);
        }


        private void btnDecryptVigenere_Click(object sender, EventArgs e)
        {
            // Handler called when the button to encrypt with the Vigenère Cipher is pressed
            Alphabet alphabet = getAlphabet();

            normalizeUserInput();
            normalizeKeyVigenere();
            string key = tbKeyVigenere.Text;

            if (normalizedText.Length <= 0)
                return;

            // Control of the key
            if (key.Length <= 0)
                return;

            tbUserOutput.Text = Tools.decryptVigenere(normalizedText, key, alphabet);
        }


        private void btnFindVigenereKeyLength_Click(object sender, EventArgs e)
        {
            // Handler called when the button to find the length of the key of the Vigenère Cipher is pressed

            // List of patterns found in the text
            List<Pattern> listPattern = new List<Pattern>();
            // List of patterns already checked, avoid multiples searchs of same pattern
            HashSet<string> alreadyTried = new HashSet<string>();
            Alphabet alphabet = getAlphabet();

            normalizeUserInput();
            string userInput = normalizedText;
            string details = "";

            if (normalizedText.Length <= 0)
                return;

            #region First and Second methods : Finding patterns

            #region Looking for patterns
            /* Looking for patterns of 3 characters minimum, reading left to right.
             * The search can stop at index length-5 because at index length-4, once the pattern of 3 characters is substracted,
             * there is only 2 characters remaining on the right, so matching pattern will always fail */
            for (int i = 0; i < userInput.Length - 5; i++)
            {
                int patternLength = 3; // Minimum size of pattern

                do
                {
                    string testPattern = userInput.Substring(i, patternLength);
                    if (!alreadyTried.Add(testPattern))
                    {
                        // No test if the pattern has already been checked, go directly to the longer pattern search
                        continue;
                    }

                    Pattern p = new Pattern(testPattern, i);
                    // Start the search at the end of the first occurrence of the pattern
                    int matchIndex = userInput.IndexOf(testPattern, i + patternLength);
                    if (matchIndex == -1)
                    {
                        // No test if the 3-characters pattern match nothing, no longer pattern search (obviously useless)
                        break;
                    }

                    while (matchIndex != -1)
                    {
                        p.addOccurrence(matchIndex);
                        if (matchIndex + patternLength >= userInput.Length)
                        {
                            break;
                        }
                        // Start the search at the end of the new found occurrence of the pattern
                        matchIndex = userInput.IndexOf(testPattern, matchIndex + patternLength);
                    }

                    listPattern.Add(p);

                } while ((i + patternLength++) < userInput.Length); // Condition for longer pattern search
            }

            #endregion

            // Calculate factors for each gap length of each pattern, and store them in a list
            List<int> unionFactors = new List<int>();
            foreach (Pattern p in listPattern)
            {
                p.calculateFactors();
                unionFactors.AddRange(p.getFactors());
            }

            // Count how many times a factor is repeated
            // In the dictionary, the key is the factor, the value is the sum of its occurrences 
            Dictionary<int, int> nbRepeatedFactors = new Dictionary<int, int>();
            foreach (int i in unionFactors)
            {
                if (!nbRepeatedFactors.ContainsKey(i))
                {
                    // Add the factor to the dictionary. Because it is the first occurrence, the value is 1
                    nbRepeatedFactors[i] = 1;
                }
                else
                {
                    // The factor already exists in the dictionary, its occurrences is incremented
                    nbRepeatedFactors[i]++;
                }
            }

            // Descending order on the value (the number of occurrences) of each factor
            List<KeyValuePair<int, int>> nbRepeatedFactorsList = nbRepeatedFactors.ToList();
            nbRepeatedFactorsList.Sort((firstPair, nextPair) =>
            {
                return -firstPair.Value.CompareTo(nextPair.Value);
            });

            #region Writting down the details
            details += "*** Most relevant keys lengths (method of factors) ***";
            details += Environment.NewLine;
            details += Environment.NewLine;
            // Display the 5 first probable keys lengths, 
            // according to the number of occurrences of the corresponding factor
            for (int i = 0; i < 5 && i < nbRepeatedFactorsList.Count; i++)
            {
                KeyValuePair<int, int> kvp = nbRepeatedFactorsList[i];
                details += "*** Value = " + kvp.Key + ", Number of factor occurrences  = " + kvp.Value;
                details += Environment.NewLine;
            }

            // Help if the previous computation does not allow the user to choose a key length
            // Instead of calculating all the gap lengths and all the factors, the user should guess the key length
            // by looking at the longest patterns and their common factors
            listPattern.Sort(); // Sort for showing the most relevant patterns first
            details += Environment.NewLine;
            details += "*** Most relevant patterns (use them if the previous methods leave doubt) ***";
            details += Environment.NewLine;
            details += Environment.NewLine;
            // Display the 10th first more relevant patterns
            for (int i = 0; i < 10 && i < listPattern.Count; i++)
            {
                Pattern p = listPattern[i];
                List<int> factors = p.getFactors();
                factors.Sort();
                details += "*** Value = " + p.getValue() + ", Occurrences = " + p.getNbOccurrences() + ", Factors = " + factors[0];
                for (int j = 1; j < factors.Count; j++)
                {
                    details += ", " + factors[j];
                }
                details += Environment.NewLine;
            }
            #endregion

            #endregion

            #region Third method : Indices of coincidence

            /* First of all, we calculate the IC of the text. If it is close the theoretical IC of the language
             * The lenght of the key is probably 1 */

            string subDetails = "";

            float ic = alphabet.IndexCoincidence(userInput);
            // Close ~ 90% of the theoretical IC
            if (ic >= (0.9 * alphabet.TheoreticalIC))
            {
                subDetails += "*** It seems that the length of the key is 1. The algorithm used might be the Caesar Cipher";
                subDetails += Environment.NewLine + Environment.NewLine;
            }


            /* Now we have to try the most probable lengths of the key and calculate the Index of coincidence
             * for each one. The most probable is the closest to the theoretical IC of the 
             * selected language */

            // key = length, value = difference between the language theoretical IC and the one founded
            List<KeyValuePair<int, float>> possibleLengths = new List<KeyValuePair<int, float>>();

            // For the five most probable key length found above
            for (int i = 0; i < 5 && i < nbRepeatedFactorsList.Count; i++)
            {
                KeyValuePair<int, int> kvp = nbRepeatedFactorsList[i];
                int length = kvp.Key;
                // Calculating the absolute difference between the calculated IC and the theoretical one
                float difference = Math.Abs(Tools.calculateIndexCoincidence(userInput, length, alphabet) - alphabet.TheoreticalIC);
                possibleLengths.Add(new KeyValuePair<int, float>(length, difference));
            }

            // Sorting the list by ascending difference
            possibleLengths.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            });

            #region Writting down the details

            subDetails += "*** Most relevant keys lengths (method of Indices of Coincidence) ***";
            subDetails += Environment.NewLine;
            subDetails += Environment.NewLine;

            for (int i = 0; i < Math.Min(5, possibleLengths.Count); i++)
            {
                KeyValuePair<int, float> kvp = possibleLengths[i];
                int length = kvp.Key;
                float difference = kvp.Value;
                subDetails += "*** Value = " + length + ", Difference with the theory = " + difference;
                subDetails += Environment.NewLine;
            }

            details = subDetails + Environment.NewLine + details;

            #endregion

            #endregion

            tbUserOutput.Text = details;
        }


        private void btnFindKeyValueAuto_Click(object sender, EventArgs e)
        {
            // Handler called when the button to find automatically the value of the key (and so, the clear text) of the Vigenère Cipher is pressed

            int lengthOfKey = (int)nuKeyLenghtVigenere.Value;
            Alphabet alphabet = getAlphabet();
            normalizeUserInput();

            if (normalizedText.Length <= 0)
                return;

            List<string> cryptedAlphabets = Tools.splitAlphabets(normalizedText, lengthOfKey); // Contains all the alphabets of the crypted text (the "columns")
            List<string> clearAlphabets = new List<string>(); // Will contain the same alphabets ("columns") as above, but decrypted
            string key = ""; // Will contain the key of the encryption

            // Foreach alphabet ("column") of the crypted text
            foreach (string cryptedAlphabet in cryptedAlphabets)
            {
                // Calculating all the possible decryption using the Caesar breaker
                List<CaesarPossibleDecryption> possibleTexts = Tools.breakCaesar(cryptedAlphabet, alphabet);

                // Taking the first one (the most probable)
                clearAlphabets.Add(possibleTexts[0].DecryptedText);

                // Adding the key of this alphabet to the global key. 
                // We have to transform the integer key to a character
                key += alphabet.GetChar(possibleTexts[0].Key);
            }

            tbKeyVigenere.Text = key;
            // The output is the merge of all the clear alphabets ("columns")
            tbUserOutput.Text = Tools.mergeAlphabets(clearAlphabets);
        }

        private void btnFindKeyValueChart_Click(object sender, EventArgs e)
        {
            // Handler called when the button to find the value of the key (and so, the clear text) of the Vigenère Cipher, using the graph, is pressed

            int lengthOfKey = (int)nuKeyLenghtVigenere.Value;
            Alphabet alphabet = getAlphabet();
            normalizeUserInput();
            normalizeKeyVigenere();

            if (normalizedText.Length <= 0)
                return;

            List<string> cryptedAlphabets = Tools.splitAlphabets(normalizedText, lengthOfKey);
            string key = "";

            // If the key is already given, take it
            if (tbKeyVigenere.Text.Length > 0)
            {
                key = tbKeyVigenere.Text;
            }
            else
            {
                // Else, calculate the most probable
                foreach (string cryptedAlphabet in cryptedAlphabets)
                {
                    List<CaesarPossibleDecryption> possibleTexts = Tools.breakCaesar(cryptedAlphabet, alphabet);
                    key += alphabet.GetChar(possibleTexts[0].Key);
                }
            }

            // Instanciating the chart and displaying it
            // VigenereChart chart = new VigenereChart(alphabet, key, cryptedAlphabets);
            // if (chart.ShowDialog() == DialogResult.OK)
            // {
            //     tbKeyVigenere.Text = chart.resultKey;
            //     btnDecryptVigenere_Click(this, EventArgs.Empty);
            // }
        }


        private void normalizeKeyVigenere()
        {
            // Normalize the vigenère key and put it in the textbox
            tbKeyVigenere.Text = normalize(tbKeyVigenere.Text);
        }

        #endregion

        private Alphabet getAlphabet()
        {
            switch (cbbLanguage.SelectedIndex)
            {
                case 0: return new EnglishAlphabet();
                case 1: return new FrenchAlphabet();
                case 2: return new SwedishAlphabet();
                default: return new EnglishAlphabet();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all the inputs
            tbUserInput.Clear();
            tbUserOutput.Clear();
            tbKeyVigenere.Clear();
            nuKeyCaesar.Value = nuKeyCaesar.Minimum;
            nuKeyLenghtVigenere.Value = nuKeyLenghtVigenere.Minimum;
            cbbLanguage.SelectedIndex = 0;  
            tbUserInput.Focus();
        }

        private void btnOutputToInput_Click(object sender, EventArgs e)
        {
            // Transfer the output into the input
            tbUserInput.Text = tbUserOutput.Text;
            tbUserOutput.Clear();
        }

        private void nuKeyLenghtVigenere_ValueChanged(object sender, EventArgs e)
        {
            // If there is something in the tbKeyVigenere
            // Check of the integrity between the length of the key and the value.
            if (tbKeyVigenere.TextLength <= 0)
                return;

            Alphabet alphabet = getAlphabet();
            string key = tbKeyVigenere.Text;
            int lengthOfKey = (int)nuKeyLenghtVigenere.Value;

            if (key.Length < lengthOfKey)
            {
                // If the written length of the key is higher than the length of the written key, pad it with letters
                tbKeyVigenere.Text = key.PadRight(lengthOfKey, alphabet.GetChar(0));
            }
            else
            {
                // If the written length of the key is lower than the length of the written key, crop it from the right
                tbKeyVigenere.Text = key.Substring(0, lengthOfKey);
            }
        }

        private void tbKeyVigenere_TextChanged(object sender, EventArgs e)
        {
            nuKeyLenghtVigenere.Value = Math.Max(1, tbKeyVigenere.TextLength);
        }

        private void tbUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Implentation of the Ctrl+A to select all the text in the textbox

            if (e.KeyChar == 1) // Ctrl + a is equal to 1
            {
                ((TextBox)sender).SelectAll(); // Selecting all the text
                e.Handled = true; // Indicating that the event has been handled and there is no more thing to do
            }
        }
    }
}
