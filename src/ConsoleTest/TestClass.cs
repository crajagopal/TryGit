using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class Rank
    {
        string word;
        StringBuilder sortedWord;
        int rank = 1;
        Dictionary<char, int> auxMap = new Dictionary<char, int>();

        /**
         * Constructor
         * Input word (eg. "BOOKKEEPER") is placed into a Tree Map to give a count of each letter.
         * 				"B"=1 "E"=3 "K"=2 "O"=2 "P"=1 "R"=1
         * 				Input word is also sorted alphabetically. Sorted word stored in StringBuilder sortedWord object.
         * @param word Word to be ranked
         * 				
         */
        public Rank(string word)
        {
            this.word = word;
            foreach (var c in word)
            {//populating map
                if (!auxMap.ContainsKey(c))
                {
                    auxMap[c] = 1;//adding keys for each letter
                }
                else
                {
                    auxMap[c] += 1; //adding value+1 for each key that already exists
                }
            }
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            sortedWord = new StringBuilder();
            sortedWord.Append(chars);
        }



        /**
         * Letter rank allows 
         * Returns first occurrence in sorted input word.
         * @param input Character to find in sorted word.
         * @return index Index of alphabetical position in input word. 
         */
        public int LetterRank(char input)
        {
            return (sortedWord.ToString().IndexOf(input));//returning first instance of character in sorted word
        }


        /**
         * factPerLetter processes the rank for the letter. This is the main driver of the program.
         * Letter is input, removed from sorted word
         * @param input character from word
         * @return BigInteger rank for input letter
         */
        public long FactPerLetter(char input)
        {
            int num = 0, hold;
            long den = 1;
                        
            IEnumerator<int> counter = auxMap.Values.GetEnumerator();//iterator created to process letters in remaining in map

            int localRank = LetterRank(input);//gets the multiplier for the letter [0...n]
            
            sortedWord.Remove(localRank, 1);//Removes processed letter from sortedWord bhoot->hoot
            while (counter.MoveNext())
            {
                hold = counter.Current;
                num = num + hold;//total number of letters, n
                den = den * Fact(hold);//sum(n_B)!*sum(n_O)!.....
            }
            if (auxMap[input] > 1)
            {//checks key for letter
                auxMap[input]--;//if has more than 1 left, subtract from value
            }
            else
            {
                auxMap.Remove(input);//if one or less, delete the key for the input letter
            }

            var val = Fact(num) * localRank / (den*num) ;
            //n!/(sum(n_0)!*sum(n_1)!...*sum(n_x)!)*(alpha_rank_input/n)
            return val;
        }


        /**
         * factorialBigInt will return n! as BigInterger object
         * @param n number to be factorialized
         * @return n! as BigInterger object
         */
        private static long Fact(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return Fact(n - 1) * n;
        }

    }

    public class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }
        public Path Cd(string newPath)
        {
            String[] newP = newPath.Split('/');
            String[] oldP = CurrentPath.Split('/');
            int lnCount = 0;
            foreach (String str in newP)
            {
                if (str.Equals(".."))
                {
                    lnCount++;
                }
            }

            int len = oldP.Length;
            String strOut = "";
            for (int i = 0; i < len - lnCount; i++)
            {
                strOut = strOut + oldP[i] + "/";
            }

            len = newP.Length;
            for (int i = 0; i < len; i++)
            {
                if (!newP[i].Equals(".."))
                {
                    strOut = strOut + newP[i] + "/";
                }
            }
            CurrentPath = strOut.Substring(0, strOut.Length - 1);
            Console.WriteLine(CurrentPath);
            if (CurrentPath.IndexOf("/") < 0)
                throw new Exception("Directory not found");
            return this;
        }
    }

    public class TextInput
    {
        public StringBuilder Input = new StringBuilder();

        public virtual void Add(char c)
        {
            Input.Append(c);
        }

        public string GetValue()
        {
            return Input.ToString();
        }
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            int v;
            if (int.TryParse(c.ToString(), out v))
            {
                Input.Append(c);
            }
        }
    }

    public class TrainComposition
    {
        private readonly LinkedList<int> wagons = new LinkedList<int>();
    
        public void AttachWagonFromLeft(int wagonId)
        {
            wagons.AddFirst(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            wagons.AddLast(wagonId);
        }

        public int DetachWagonFromLeft()
        {
            var i = wagons.First;
            wagons.RemoveFirst();
            return i.Value;
        }

        public int DetachWagonFromRight()
        {
            var i = wagons.Last;
            wagons.RemoveLast();
            return i.Value;
        }
    }

    public static class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            var indexMap = new Dictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > sum) continue;
                var diff = sum - list[i];
                if (indexMap.ContainsKey(diff))
                {
                    return new Tuple<int, int>(i, indexMap[diff]);
                }
                if (!indexMap.ContainsKey(list[i]))
                {
                    indexMap[list[i]] = i;
                }  
            }
            return null;
        }       
    }

    public class TestClass
    {
        static TestClass()
        {
            string s = "";
            StringBuilder s1 = new StringBuilder();
           
        }       

        public TestClass()
        {
            string s = "";
        }

        public TestClass(string s1)
        {
            string s = s1;
        }


        public static int[] GetDenominations(int n, int[] bills, out int minCount)
        {
            minCount = 0;
            if (bills == null || bills.Length <= 0) return new int[]{};
            var count = bills.Length;
            var denominations = new int[count];
            Array.Sort(bills);
            var minDenomination = bills[0];
            Array.Reverse(bills);
            
            var val = n;
            for (var i = 0; i < count; i++)
            {
                if (val >= bills[i] && bills[i]>0)
                {
                    var billCount = val / bills[i];
                    var rem = val % bills[i];
                    var lessThanLeast = rem != 0 && rem < minDenomination;
                    denominations[i] = lessThanLeast ? billCount - 1 : billCount;
                    val = val - denominations[i] * bills[i];
                }
            }

            minCount = denominations.Sum();

            return denominations;
        }
    }
}

