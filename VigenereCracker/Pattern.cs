namespace VigenereCracker
{
    class Pattern : IComparable<Pattern>
    {
        private string value;
        private List<int> indexes;
        private List<int> factors;

        public Pattern(string s, int firstIndex)
        {
            value = s;
            indexes = new List<int>();
            indexes.Add(firstIndex);
        }

        public void addOccurrence(int index)
        {
            indexes.Add(index);
        }

        public string getValue()
        {
            return value;
        }

        public int getNbOccurrences()
        {
            return indexes.Count;
        }

        /// <summary>
        /// Calculate the gap lengths between all occurrences of the pattern,
        /// then calculate all factors for each gap length
        /// </summary>
        public void calculateFactors()
        {
            factors = new List<int>();
            // The comparison ends at the penultimate element because comparison is made between 2 elements
            for (int i = 0; i < indexes.Count - 1; i++)
            {
                for (int j = i + 1; j < indexes.Count; j++)
                {
                    // Measure the gap length, that is the distance between the 2 indexes of the occurrences of the pattern
                    int gapLength = indexes[j] - indexes[i];
                    // Find all factors for this number
                    factors.AddRange(Tools.getFactors(gapLength));
                }
            }
        }

        public List<int> getFactors()
        {
            return factors;
        }

        // Implement IComparable<Pattern> CompareTo method - provide default sort order.
        int IComparable<Pattern>.CompareTo(Pattern p)
        {
            // If patterns have the same length, descending order on number of occurrences found
            int moreMatching = -this.indexes.Count.CompareTo(p.indexes.Count);
            if (moreMatching != 0)
            {
                return moreMatching;
            }
            // Descending order on length of the pattern value 
            int longerPatternFirst = -this.value.Length.CompareTo(p.value.Length);
            if (longerPatternFirst != 0)
            {
                return longerPatternFirst;
            }
            // If patterns have the same number of occurrences, alphabetical ascending order
            return this.value.CompareTo(p.value);
        }
    }
}
