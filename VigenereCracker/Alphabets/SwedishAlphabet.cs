namespace VigenereCracker.Alphabets
{
    public class SwedishAlphabet : Alphabet
    {
        private char[] SWEDISH_ALPHABET = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö' };
        private float[] SWEDISH_FREQUENCIES = { 
                                                 0.093f, //a 
                                                 0.013f, //b
                                                 0.013f, //c 
                                                 0.045f, //d
                                                 0.099f, //e 
                                                 0.020f, //f
                                                 0.033f, //g
                                                 0.021f, //h
                                                 0.051f, //i 
                                                 0.007f, //j
                                                 0.032f, //k
                                                 0.052f, //l
                                                 0.035f, //m
                                                 0.088f, //n
                                                 0.041f, //o
                                                 0.017f, //p
                                                 0.00007f, //q
                                                 0.083f, //r
                                                 0.063f, //s
                                                 0.087f, //t
                                                 0.018f, //u 
                                                 0.024f, //v
                                                 0.0003f, //w
                                                 0.001f, //x
                                                 0.006f, //y
                                                 0.0002f, //z
                                                 0.016f, //å
                                                 0.021f, //ä
                                                 0.015f //ö
                                             };

        private float SWEDISH_IC = 0.0644f;
        
        public SwedishAlphabet()
        {
            characters = new List<char>();
            characters.AddRange(SWEDISH_ALPHABET);

            theoreticalFrequencies = new List<float>();
            theoreticalFrequencies.AddRange(SWEDISH_FREQUENCIES);

            theoreticalIC = SWEDISH_IC;
        }
    }
}
