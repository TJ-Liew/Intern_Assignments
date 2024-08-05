﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace testProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] strArray = { "yellowcat", "apple,bat,cat,goodbye,hello,yellow,why,taco"};
            Console.WriteLine(WordSplit(strArray));
        }

        static String WordSplit(string[] strArray) {
            String word = strArray[0];

            //make another array to store the CSV words from the dictionary
            String[] dictionary = strArray[1].Split(',');

            // LINQ approach
            var validSplit = Enumerable.Range(1, word.Length - 1)
                .Select(i => new { firstWord = word.Substring(0,i), secondWord = word.Substring(i) })
                .FirstOrDefault(splitWords => dictionary.Contains(splitWords.firstWord) && dictionary.Contains(splitWords.secondWord));

            if (validSplit != null)
            {
                return validSplit.firstWord + "," + validSplit.secondWord;
            }
            else {
                return "String could not be split into two different words";
            }

            // Straight-forward approach
            /*
            //find possible split points in the given string
            for (int i = 1; i < word.Length; i++) {
                //separate words into two parts
                String firstWord = word.Substring(0, i);
                String secondWord = word.Substring(i);
                
                //check if both words are in the dictionary array
                if (dictionary.Contains(firstWord) && dictionary.Contains(secondWord))
                {
                    return firstWord + "," + secondWord;
                }
            }
            //if string can't be split into two words from dictionary
            return "String could not be split into two different words";*/
        }
    }
}
