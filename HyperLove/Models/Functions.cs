using System;

namespace HyperLove.Models
{
    public static class Functions
    {
        public static string AddSpace(ref string word)
        {
            int indx = 0;

            /*
             * Checking if the character is an Upper Case ASCII code (65 - 90)
             * If it is add a space before it unless it's the first character
             */
            foreach (char s in word)
            {
                if (indx > 0 && Convert.ToInt32(s) <= 90)
                    word = word.Insert(indx, " ");

                indx++;
            }

            return word;
        }

        public static string QuotesTitles(int x)
        {
            switch (x)
            {
                case 0:
                    return "Do you want babies?";
                case 1:
                    return "How would you handle...";
                case 3:
                    return "Do you like icecream?";
                case 12:
                    return "Would you like to fuck off?";
            }

            return string.Empty;
        }
    }
}
