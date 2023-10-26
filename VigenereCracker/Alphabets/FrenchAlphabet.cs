namespace VigenereCracker.Alphabets
{
    public class FrenchAlphabet : Alphabet
    {
        private char[] FRENCH_ALPHABET = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private float[] FRENCH_FREQUENCIES = { 
                                                 0.08122f, //a = a + à = 0.07636 + 0.00486
                                                 0.00901f, //b
                                                 0.03345f, //c = c + ç = 0.03260 + 0.00085 = 0.03345
                                                 0.03669f, //d
                                                 0.17115f, //e = e + è + é + ë + ê = 0.14715 + 0.00271 + 0.01904 + 0.00225 + 0 = 0.17115
                                                 0.01066f, //f
                                                 0.00866f, //g
                                                 0.00737f, //h
                                                 0.07580f, //i = i + î + ï = 0.07529 + 0.00045 + 0.00006 
                                                 0.00545f, //j
                                                 0.00049f, //k
                                                 0.05456f, //l
                                                 0.02968f, //m
                                                 0.07095f, //n
                                                 0.05378f, //o
                                                 0.03021f, //p
                                                 0.01362f, //q
                                                 0.06553f, //r
                                                 0.07948f, //s
                                                 0.07244f, //t
                                                 0.06368f, //u = u + ù = 0.06311 + 0.00058 = 0.06368
                                                 0.01628f, //v
                                                 0.00114f, //w
                                                 0.00387f, //x
                                                 0.00308f, //y
                                                 0.00136f, //z
                                             };
        private float FRENCH_IC = 0.0778f;

        public FrenchAlphabet()
        {
            characters = new List<char>();
            characters.AddRange(FRENCH_ALPHABET);

            theoreticalFrequencies = new List<float>();
            theoreticalFrequencies.AddRange(FRENCH_FREQUENCIES);

            theoreticalIC = FRENCH_IC;
        }
    }
}
