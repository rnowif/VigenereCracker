namespace VigenereCracker
{
    public class CaesarPossibleDecryption
    {
        private string decryptedText;
        int key;
        float correlation;
        
        public string DecryptedText
        {
            get { return decryptedText; }
        }

        public int Key
        {
            get { return key; }
        }

        public float Correlation
        {
            get { return correlation; }
        }

        public CaesarPossibleDecryption(float correlation, int key, string decryptedText)
        {
            this.decryptedText = decryptedText;
            this.correlation = correlation;
            this.key = key;
        }

    }
}
