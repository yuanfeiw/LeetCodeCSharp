﻿/*
273	Integer to English Words
medium, math
Integer to English Words
Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 2^31 - 1.

For example,
123 -> "One Hundred Twenty Three"
12345 -> "Twelve Thousand Three Hundred Forty Five"
1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
Hint:

Did you see a pattern in dividing the number into chunk of words? For example, 123 and 123000.
Group the number by thousands (3 digits). You can write a helper function that takes a number less than 1000 and convert just that chunk to words.
There are many edge cases. What are some good test cases? Does your code work with input such as 0? Or 1000010? (middle chunk is zero and should not be printed out)
*/

namespace Demo
{
    public partial class Solution
    {
        private static readonly string[] lessThan20 = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        private static readonly string[] tens = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        private static readonly string[] thousands = {"", "Thousand", "Million", "Billion"};
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            int i = 0;
            string words = "";

            while (num > 0)
            {
                if (num%1000 != 0)
                {
                    words = NumberToWordsLessThan1000(num%1000) + thousands[i] + " " + words;
                }
                num /= 1000;
                i++;
            }

            return words.Trim();
        }

        private string NumberToWordsLessThan1000(int num)
        {
            if (num == 0)
                return "";
            if (num < 20)
                return lessThan20[num] + " ";
            if (num < 100)
                return tens[num / 10] + " " + NumberToWordsLessThan1000(num % 10);
            return lessThan20[num / 100] + " Hundred " + NumberToWordsLessThan1000(num % 100);
        }
    }
}
