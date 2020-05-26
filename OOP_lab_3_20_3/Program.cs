using System;
using System.IO;

namespace OOP_lab_3_20_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fromFile = new StreamReader("input.txt");
            StreamWriter toFile = File.CreateText("output.txt");

            string sentence = fromFile.ReadToEnd();

            string[] words = sentence.Split(new char[] { (char)(92), '\r', ' ', ':', ';', '.', ',', '?', '!', '(', ')', '{', '}', '[', ']', '@', '#', '№', '$', '^', '%', '&', '*', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;

            foreach (string word in words)
            {
                int k = 0;

                for (int i = 0; i < word.Length; ++i)
                {
                    if (((word[i] >= (char)65) && (word[i] <= (char)90)) || ((word[i] >= (char)97) && (word[i] <= (char)122)))
                    {
                        ++k;
                    }
                }

                if (word.Length != k)
                {
                    words[index] = words[index].Remove(0);
                }

                ++index;
            }

            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    toFile.Write("{0} ", word);
                }
            }

            toFile.Close();
            fromFile.Close();
        }
    }
}
