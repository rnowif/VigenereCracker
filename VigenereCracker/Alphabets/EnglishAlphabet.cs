namespace VigenereCracker.Alphabets
{
    public class EnglishAlphabet : Alphabet
    {
        private char[] ENGLISH_ALPHABET = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private float[] ENGLISH_FREQUENCIES = { 
                                                 0.08167f, //a 
                                                 0.01492f, //b
                                                 0.02782f, //c 
                                                 0.04253f, //d
                                                 0.12702f, //e 
                                                 0.02228f, //f
                                                 0.02015f, //g
                                                 0.06094f, //h
                                                 0.06966f, //i 
                                                 0.00153f, //j
                                                 0.00772f, //k
                                                 0.04025f, //l
                                                 0.02406f, //m
                                                 0.06749f, //n
                                                 0.07507f, //o
                                                 0.01929f, //p
                                                 0.00095f, //q
                                                 0.05987f, //r
                                                 0.06327f, //s
                                                 0.09056f, //t
                                                 0.02758f, //u 
                                                 0.00978f, //v
                                                 0.02360f, //w
                                                 0.00150f, //x
                                                 0.01974f, //y
                                                 0.00074f //z
                                             };
        private float ENGLISH_IC = 0.0667f;

        public EnglishAlphabet()
        {
            characters = new List<char>();
            characters.AddRange(ENGLISH_ALPHABET);

            theoreticalFrequencies = new List<float>();
            theoreticalFrequencies.AddRange(ENGLISH_FREQUENCIES);

            theoreticalIC = ENGLISH_IC;
        }
    }
}
