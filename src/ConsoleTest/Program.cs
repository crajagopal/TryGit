using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Schema;
using static System.Console;

namespace ConsoleTest
{
    internal class Program
    {        
        private static void Main(string[] args)
        {
            TestSortLexicalLog();  
            WriteLine();
        }

        private static void TestSortLexicalLog()
        {
            var list = new List<string[]>
            {
                new[] {"za1", "Dog", "Golden Retriever", "Rex"},
                new[] {"ab1", "Dog", "Golden Retriever", "Rex"},
                new[] {"af1", "25642", "356376"},
                new[] {"cd1", "Cat", "Tabby", "Boblawblah"},
                new[] {"f1", "Fish", "Clown", "Nemo"},
                new[] {"rf2", "10", "20"},
                new[] {"ad1", "Dog", "Pug", "Daisy"},
                new[] {"rf21", "1", "2"},
                new[] {"zc2", "Cat", "Siemese", "Wednesday"},
                new[] {"f2", "Fish", "Gold", "Alaska"}
            };
            var intList = list.Where(item => int.TryParse(item[1], out _)).ToList();
            var strLogMap = new Dictionary<string, string>();
            var logList = list.Where(item => !int.TryParse(item[1], out _)).ToList();
            logList.ForEach(item => strLogMap.Add(item[0], string.Join(string.Empty, item.Where(elem => item[0] != elem))+item[0]));

            var logListFinal = strLogMap.OrderBy(item => item.Value).Select(elem => string.Join(",", list.First(items => items[0] == elem.Key))).ToList();
            logListFinal.AddRange(intList.Select(elem => string.Join(",", elem)));

            WriteLine("\nFinal output\n------------\n");

            foreach (var item in logListFinal)
            {
                Write($"{item}");
                WriteLine();
            }

            /*foreach (var arr in intList)
            {
                foreach (var str in arr)
                {
                    Write($"{str}, ");
                }
                WriteLine();
            }
            WriteLine("\nLogs\n------------\n");
            foreach (var arr in logList)
            {
                foreach (var str in arr)
                {
                    Write($"{str}, ");
                }
                WriteLine();
            }
            WriteLine("\nMap\n------------\n");
            foreach (var key in strLogMap.Keys)
            {                                
                Write($"{key} --> {strLogMap[key]}");                
                WriteLine();
            }

            WriteLine("\nSorted Map\n------------\n");
            foreach (var item in strLogMap.OrderBy(item=>item.Value))
            {
                Write($"{item.Key} --> {strLogMap[item.Key]}");
                WriteLine();
            }*/                        
        }

        private static void TestSortLexical()
        {
            var list = new List<string[]>
            {
                new[] {"za1", "Dog", "Golden Retriever", "Rex"},
                new[] {"ab1", "Dog", "Golden Retriever", "Rex"},
                new[] {"rf1", "25642", "356376"},
                new[] {"Cat", "Tabby", "Boblawblah"},
                new[] {"Fish", "Clown", "Nemo"},
                new[] {"rf2", "10", "20"},
                new[] {"Dog", "Pug", "Daisy"},
                new[] {"rf21", "1", "2"},
                new[] {"Cat", "Siemese", "Wednesday"},
                new[] {"Fish", "Gold", "Alaska"}
            };

            //var newList = list.OrderBy(r => r[0])
            //    //.ThenBy(r => r[1])
            //    // .ThenBy(r => r[2])
            //    .ToList();

            var newList = list.OrderBy(s => string.Join(string.Empty, s)).ToList();
            foreach (var arr in newList)
            {
                foreach (var str in arr)
                {
                    Console.Write($"{str}, ");
                }
                Console.WriteLine();
            }
        }

        private static void TestProtectedMember(string s)
        {
            A a = new A();
            B b = new B(1234);

            // Error CS1540, because x can only be accessed by
            // classes derived from A.
            //a.Val = 10; 

            // OK, because this class derives from A.
            //b.Val = 10;
            Console.WriteLine(b.GetVal());
        }

        private static string ReversePairs(string s)
        {
            
            var result = "";
            for (var i = s.Length-1; i > 0; i=i-2)
            {
                result += string.Concat(s[i-1],s[i]);
            }
            if (s.Length % 2 != 0)
            {
                result += s[0];
            }
             
            return result;
        }     

        private static void Main2()
        {
            // TestSortLexical();
            //WriteLine(ReversePairs("ABCDEF"));
            //TestKnapSack();

            //x a = new x();
            //y b = new y();
            ////x c = b;

            //XClass a1 = new XClass("cg");
            //XClass b1 = a1;
            //b1.Name("and");
            //WriteLine(a1.Name());
            //WriteLine(b1.Name());

            //if (a1 == b1)
            //{
            //    WriteLine("equal");
            //}
            //else { WriteLine("not");}

            //if (a1.Equals(b1))
            //{
            //    WriteLine("equal");
            //}
            //else { WriteLine("not"); }


            // Console.WriteLine(CalculateDiceRoll("2d5+3d7-12"));
            //Console.WriteLine(CalculateDiceRoll("2d5"));

            //SeparateIntegers(new[] { 6, -7, 7, 1, -1, 2, 1, -5, -6 });
            //SeparateIntegers(new[] { 6, 7, 7, 1, 1, 2, 1, 5, 6 });
            //SeparateIntegers(new[] { -6, -7, -7, -1, -1, -2, -1, -5, -6 });
            // RankTest1();

            //StringPermute("ADCB");
            //StringPermute("BOOTH");

            //WriteLine(Permute("JACBZPUC"));

            //WordRank("BANANA");
            //WordRankMath("BANANA");

            //WordRank("JACBZPUC");
            //WordRankMath("JACBZPUC");

            //WordRank("BOOTH");
            //WordRankMath("BOOTH");

            //WordRank("BOOKKEEPER");
            //WordRankMath("BOOKKEEPER");

            //Permutate();
            //var i = Enumerable.Range(0, 1);
            //foreach (var j in i) Console.WriteLine(j);
            // TrainComposition();
            //ClassTest();
            //TupleTest();
            //Test();
            //RankTest1();
            //  RankTest2();
            //WriteLine(FormatTest(877130.37));
            //WriteLine(FormatTest(.333));
            //Console.WriteLine(NumberOfWays(5));
            //LongestContinuousSum(new[] { -2, -3, 4, -1, -2, 1, 5, -3 });
            //LongestContinuousSum(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            //LongestContinuousSum(new[] { 6,-7, 7, 1, -1, 2, 1, -5, -6 });
            //LongestContinuousSum(new[] { -3, -1, -5, -6, -9});
            //LongestContinuousSum(new[] { 3, -1, 5, -6, -9 });
            WriteLine();
            /*var mySet = new List<int> {1, 2, 3};
            foreach (List<int> s in PowerSet(mySet))
            {
                foreach (var item in s)
                {
                    Write($"{item}, ");
                }
                WriteLine();
            }*/
        }

        private static void TestUriParser()
        {
           var x = "https://yahoo.com/movies/index.html?refresh=1";
           Uri uri;
           if (Uri.TryCreate(x, UriKind.Absolute, out uri))
           {
               var uriParts = new List<string>();
               if (uri.Scheme.Length > 0)
               uriParts.Add(uri.Scheme);
               if (uri.Host.Length > 0)
                   uriParts.Add(uri.Host);
               if (uri.Query.Length > 0)
                   uriParts.Add(uri.Query.Replace("?", ""));
               var output = string.Join(",", uriParts);
               WriteLine(output);
           }
           else
           {
               Console.WriteLine("Enter valid uri");
           }
        }

        private static void TestRemoveCharsFromString()
        {            
            var line = "hello world, def";
            var lines = line.Split(',');

            if (lines.Length <= 1) return;

            var input = lines[0];
            var rep = lines[1].Trim();
            var line2 = input.Where(c => !rep.ToCharArray().Contains(c)).ToArray();
            WriteLine(line2);
        }

        private static void TestPrintSumWithExceptions()
        {
            var line = "10";
            int input;
            if (int.TryParse(line, out input))
            {
                var sum = 0;
                for (int i = 1; i <= input; i++)
                {
                    if (i % 5 != 0 && i % 7 != 0)
                    {
                        sum += i;
                    }
                }
                WriteLine(sum);
            }
            else
            {
                WriteLine("enter valid integer");
            }            
        }

       

        // A utility function that returns maximum of two integers
        static int Max(int a, int b) { return (a > b) ? a : b; }

        private static void TestKnapSack()
        {
            var values = new [] {60, 100, 120};
            var weights = new[] {1, 2, 3 };
            var targetWeight = 5;

            var max = TestKnapSack(targetWeight, weights, values, values.Length);
            WriteLine(max);
        }

        private static int TestKnapSack(int W1, int[] wt, int[] val, int n)
        {
            var k = new int[n + 1][];
            for (var z = 0; z < n + 1; z++)
            {
                k[z] = new int[W1+1];
            }

            for (var i = 0; i <= n; i++)
            {
                for (var w = 0; w <= W1; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        k[i][w] = 0;
                    }
                    else if (wt[i - 1] <= w)
                    {
                        k[i][w] = Max(val[i - 1] + k[i - 1][w - wt[i - 1]], k[i - 1][w]);
                    }
                    else
                        k[i][w] = k[i - 1][w];
                }
            }

            for (var i = 0; i <= n; i++)
            {
                for (var w = 0; w <= W1; w++)
                {
                    Write($"{k[i][w]}\t");
                }
                WriteLine();
            }

            return k[n][W1];
        }

        private static int CalculateDiceRoll(string input)
        {
            if (!ValidateInput(input)) return -1;
            if (string.IsNullOrEmpty(input)) return 0;
            var result = 0;
            var token = "";
            var lastOperator = '0';

            foreach (var c in input)
            {
                switch (c)
                {
                    case '+':
                        lastOperator = c;
                        result += CalculateDiceRollVal(token);
                        token = "";
                        break;
                    case '-':
                        lastOperator = c;
                        result -= CalculateDiceRollVal(token);
                        token = "";
                        break;
                    default:
                        token += c;
                        break;
                }   
            }

            result += (lastOperator == '-' ? -1 : 1 ) * CalculateDiceRollVal(token);

            return result;
        }

        private static bool ValidateInput(string input)
        {
            var isValid = true;
            foreach (var s in input.Split('+', '-'))
            {
                if (string.IsNullOrEmpty(s)) continue;
                if (s.IndexOf("d", StringComparison.Ordinal) != -1)
                {
                    var items = s.Split('d');
                    if (items.Length == 2 && int.TryParse(items[1], out int _)) continue;
                    isValid = false;
                    break;
                }
                else
                {
                    if (int.TryParse(s, out int _)) continue;
                    isValid = false;
                    break;
                }
                
            }
            
            return isValid;
        }

        private static int CalculateDiceRollVal(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var tokens = input.Split('d');
            var sum = 0;
            if (tokens.Length == 1) sum = int.Parse(tokens[0]);
            else
            {
                for (var i = 0; i < int.Parse(tokens[0]); i++)
                {
                    sum += new Random().Next(int.Parse(tokens[1]));
                }
            }
            return sum;
        }

        private static List<List<T>> PowerSet<T>(List<T> originalSet) where T:struct
        {
            List<List<T>> sets = new List<List<T>>();
            if (originalSet.Count == 0)
            {
                sets.Add(new List<T>());
                return sets;
            }
            List<T> list = originalSet;
            T head = list[0];
            List<T> rest = new List<T>(list.GetRange(1, list.Count-1));
            foreach (List<T> set in PowerSet(rest))
            {
                List<T> newSet = new List<T>();
                newSet.Add(head);
                newSet.AddRange(set);
                sets.Add(newSet);
                sets.Add(set);
            }
            return sets;
        }


        private static void WordRankMath(string word)
        {
            long rank = 1;
            var chars = word.ToCharArray();
            var charMap = new SortedList<char, int>();
            foreach (var c in word)
            {
                if (charMap.ContainsKey(c))
                {
                    charMap[c]++;
                }
                else
                {
                    charMap.Add(c, 1);
                }
            }
            foreach (var c in word)
            {
                var localRank = 0;//number of chars from word as found in charMap that are before this letter
                var charLen = 0;
                long den = 1;
                //same as index from sortedword banana => aaabnn
                foreach(var key in charMap.Keys)
                {
                    if (key == c) break;
                    localRank = localRank + charMap[key];
                }

                foreach (var val in charMap.Values)
                {
                    charLen += val;
                    den = den * Fact(val);
                }

                if (charMap[c] > 1) charMap[c]--;
                else charMap.Remove(c);

                var charRank = localRank * Fact(charLen-1) / den;
                rank += charRank;

                WriteLine($"{c} - den = {den}, charlen={charLen}, num={localRank}, charRank={charRank}, rank={rank}");
            }

            foreach (var key in charMap.Keys)
            {
                WriteLine($"{key} - {charMap[key]}");
            }
            WriteLine($"Rank{word} = {rank}");
        }

        public static void WordRank(string input)
        {

            var word = new Rank(input); //Rank object constructed and given command line input
            long rank = 1;//Because there is no rank 0

            foreach (char index in input)
            {
                //iterates through each letter
                var t = word.FactPerLetter(index);
                rank = rank + t;
                WriteLine($"rank({index}) - {t}, rank-{rank}");
            }

            WriteLine($"Rank {input} => {rank}");//return to command line

        }

        private static SortedSet<string> StringPermute(string s)
        {
            var itemsList = s.ToCharArray().ToList();
            itemsList.Sort();
            var items = itemsList.ToArray();
            int len = items.Length;

            var retVal = new SortedSet<string> {""};

            if (string.IsNullOrEmpty(s))
                return retVal;

            for (var i = 0; i < len; i++)
            {
                var c = items[i];

                var loop = retVal;
                retVal = new SortedSet<string>();
                WriteLine($"{i}");
                
                foreach (var st in loop)
                {                                                       
                    for (var j = 0; j <= st.Length; j++)
                        retVal.Add(st.Substring(0, j) + c + st.Substring(j));
                }
                //PrintList(retVal);
                WriteLine($"---------");
            }
            var ret = retVal.ToList();
            var index = ret.FindIndex(x => string.Equals(x, s, StringComparison.CurrentCultureIgnoreCase));
            //PrintList(ret);
            WriteLine(index+1);
            return retVal;
        }

        private static void Permutate()
        {
            List<int> seq = new List<int>() {1, 2, 3, 4};
            Permutate(seq.ToArray(),0, seq.Count-1);
        }

        private static void SwapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void Permutate(int[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                for (i = 0; i <= m; i++)
                    Console.Write("{0}", list[i]);
                Console.Write(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    SwapTwoNumber(ref list[k], ref list[i]);
                    Permutate(list, k + 1, m);
                    SwapTwoNumber(ref list[k], ref list[i]);
                }
        }

        static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var t in list)
            {
                WriteLine($" {t}, ");
            }
        }

        static void Print<T>(IReadOnlyList<T> s) where T: struct 
        {
            foreach (T t in s)
            {
                Write($", {t}");
            }
            WriteLine();
        }

       
        private static void SeparateIntegers(int[] array)
        {
            var len = array.Length;
            int start = 0, end = len - 1;
            
            while (start < end)
            {
               // WriteLine($"i={start}, end={end} array[i]={array[start]}, array[end]={array[end]}");
                if (array[start] > 0 && array[end] < 0)
                {
                    var temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                    end--;
                    start++;
                }
                else if (array[start] < 0)
                {
                    start++;
                }
                else if (array[end] > 0)
                {
                    end--;
                }
                // WriteLine($"i={start}, end={end} array[i]={array[start]}, array[end]={array[end]}");
            }
            Write(" Array = [");
            for (var i = 0; i < len; i++)
            {
                Write($" {array[i]}, ");
            }

            WriteLine(" ]\n");
        }

        private static int LongestContinuousSum(IReadOnlyList<int> array)
        {
            var maxSumSoFar = -2147483648;
            var curSum = 0;
            int start = 0, end = 0, newStart = 0;            
            for (var i = 0; i < array.Count; i++)
            {
                curSum += array[i];
                if (curSum > maxSumSoFar)
                {
                    maxSumSoFar = curSum;
                    start = newStart;
                    end = i;
                }
                if (curSum < 0)
                {
                    curSum = 0;
                    newStart = i + 1;
                }
                WriteLine($"i={i}, curSum={curSum}, maxSumSoFar={maxSumSoFar}, start={start}, newStart={newStart}, end={end}");
            }           
            WriteLine($"maxSumSoFar={maxSumSoFar} a={start}, b={end} \n");

            Write("Max Array = [");
            for (var i = start; i < end + 1; i++)
            {
                Write($" {array[i]}, ");
            }

            WriteLine(" ]\n");
           
            return maxSumSoFar;
        }

        public static int NumberOfWays(int n)
        {
            var a = 0;
            var b = 1;

            for (int i = 0; i <= n; i++)
            {
                var temp = a;
                a = b;
                b += temp;
                Console.WriteLine($"i={i} a={a}, b={b}");
            }
            return a;
        }

        public static void TrainComposition()
        {
            var tree = new TrainComposition();
            tree.AttachWagonFromLeft(7);
            tree.AttachWagonFromLeft(13);
            tree.AttachWagonFromRight(15);
            Console.WriteLine(tree.DetachWagonFromRight()); // 7 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 13
        }

        public static void TupleTest()
        {
            Tuple<int, int> indices = TwoSum.FindTwoSum(new List<int>() { 1, 3, 5, 7, 9 }, 16);
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
            indices = TwoSum.FindTwoSum(new List<int>() { 1, 3, 5, 7, 9 }, 11);
            Console.WriteLine(indices?.Item1 + " " + indices?.Item2);
        }

        private static void ClassTest()
        {
            int v;
            bool converted = int.TryParse('a'.ToString(), out v);
            WriteLine($"test: {v} -> {converted}");

            var s1 = "Deleveled";
            char[] c = s1.ToCharArray();
            c=c.Reverse().ToArray();
            if (String.Equals(s1, new string(c), StringComparison.CurrentCultureIgnoreCase)) WriteLine("palindorme");

            var array = new int[] {1, 3, 5, 7};
            var elem = 4;
            var i = array.Count(x => x < elem);
            WriteLine($"no of items less than {elem} = {i}");

            // var test = new TestClass();
            var test1 = new TestClass("test");
            var min = 0;
            Display(10, TestClass.GetDenominations(0, null, out min), min);
            Display(10, TestClass.GetDenominations(10, new int[] {}, out min), min);
            Display(100, TestClass.GetDenominations(100, new[] {0}, out min), min);
            Display(0, TestClass.GetDenominations(0, new[] { 100, 50, 10 }, out min), min);
            Display(10, TestClass.GetDenominations(10, new[] { 100, 50, 20 }, out min), min);
            Display(50, TestClass.GetDenominations(50, new[] { 100, 50, 20 }, out min), min);
            Display(60, TestClass.GetDenominations(60, new[] { 100, 50, 20 }, out min), min);
            Display(70, TestClass.GetDenominations(70, new[] { 100, 50, 20 }, out min), min);
            Display(260, TestClass.GetDenominations(260, new[] { 100, 50, 20 }, out min), min);
            Display(350, TestClass.GetDenominations(350, new[] { 100, 50, 20 }, out min), min);
            Display(170, TestClass.GetDenominations(170, new[] { 100, 50, 20 }, out min), min);
            Display(160, TestClass.GetDenominations(160, new[] { 100, 50, 20 }, out min), min);
            Display(210, TestClass.GetDenominations(210, new[] { 100, 50, 10 }, out min), min);

        }       

    private static void Display(int n, int[] denominations, int m)
        {
            WriteLine($"{n}-->{JsonSerializer.Serialize(denominations)}==>{m}");
            WriteLine();
        }

        private static async void RankTest()
        {
            await Task.Run(()=>RankTest1());
            
        }

        private static async void RankTestAsync()
        {
            /*
                ABAB = 2
                AAAB = 1
                BAAA = 4
                QUESTION = 24572
                BOOKKEEPER = 10743
             */
            var testArray = new[] { "ABAB", "ADCB", "BAAA", "QUESTION", "BOOKKEEPER", "NONINTUITIVENESS" };

            foreach (var test in testArray)
            {
                var rank = await Task.Run(() => Permute(test));
                WriteLine($"Alphabetical rank of {test} is : {rank}");
            }

           // Read();
        }

        private static string FormatTest(double Vnum)
        {

            if (Vnum > 99000000)
            {
                return "Sorry, this will not generate numbers larger that 99 million.";
            }

            var v10Million = (int) Vnum / 10000000;
            var v1Million = (int) (Vnum % 10000000) / 1000000;
            var v100Thousand = (int) (Vnum % 1000000) / 100000;
            var v10Thousand = (int) (Vnum % 100000) / 10000;
            var v1Thousand = (int) (Vnum % 10000) / 1000;
            var vhundreds = (int) (Vnum % 1000) / 100;
            var vtens = (int) (Vnum % 100) / 10;
            var vones = (int) (Vnum % 10) / 1;

            var vcents = (int) (((Vnum % 1) * 100));

            var vformat = "";

            if (Vnum >= 1)
            {
                vformat = (((v10Million > 0) ? v10Million.ToString() : "") + ((v1Million > 0) ? v1Million + "," : "") +
                           ((v100Thousand > 0) ? v100Thousand.ToString() : "") +
                           ((v10Thousand > 0) ? v10Thousand.ToString() : "") +
                           ((v1Thousand > 0) ? v1Thousand + "," : "") +
                           ((vhundreds > 0) ? vhundreds.ToString() : "") + ((vtens > 0) ? vtens.ToString() : "") +
                           ((vones >= 0) ? vones.ToString() : "0") + "." + vcents);
            }
            else
            {
                vformat = ("0." + vcents);
            }

            return vformat;
        }


        private static void Test()
        {
            string ans;
            do
            {
                WriteLine("Enter a word: ");
                var word = ReadLine();
                //  word = "onod";
                var rank = Permute(word);
                WriteLine($"The rank of {word} is : {rank}");
                Write("Do you want to continue (Y/N)? ");
                ans = ReadLine();
                WriteLine();
            } while (ans?.ToUpper() == "Y");
        }

        private static void RankTest1()
        {
            /*
                ABAB = 2
                AAAB = 1
                BAAA = 4
                QUESTION = 24572
                BOOKKEEPER = 10743
             */
            //var testArray = new[] {"ABAB", "ADCB", "BAAA", "QUESTION", "BOOKKEEPER", "NONINTUITIVENESS"};
            var testArray = new[] { "BOOKKEEPER" };
            foreach (var test in testArray)
            {
                var rank = Permute(test);
                WriteLine($"Alphabetical rank of {test} is : {rank}");
            }

           // Read();
        }
       
        private static long Permute(string word)
        {
            var W = word.ToLower();
            var C = new int[26];
            for (var i = 0; i < 26; i++)
            {
                C[i] = 0;
            }
            long rank = 1;
            foreach (var t in W)
            {
                C[t - 'a']++;
            }

            //Print(C);

            if (W == "") return rank;
            for (var i = 0; i < W.Length; i++)
            {
                //How many characters which are not used, that come before current character                    
                for (var j = 0; j < 26; j++)
                {
                    //WriteLine(W[i]);
                    if (j == (W[i] - 'a')) break;
                    if (C[j] <= 0) continue;

                    var t = Fact(W.Length - i - 1);
                    for (var k = 0; k < 26; k++)
                    {                        
                        if (C[k] <= 0) continue;
                        if (k == j) t /= Fact(C[k] - 1);
                        else t /= Fact(C[k]);
                        //WriteLine($"w[i]={W[i]}, i={i} j={j}, k={k}, t={t}, rank={rank} \n");
                    }
                    rank += t;
                }
                C[W[i] - 'a']--;
                //Print(C);
            }
            return rank;

        }

        private static long Fact(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return Fact(n - 1) * n;
        }
       
        public class JsonSerializer
        {
            public static string Serialize(object obj)
            {
                var javaScriptSerializer = new JavaScriptSerializer();
                return javaScriptSerializer.Serialize(obj);
            }
        }


        class A
        {
            protected int Val = 123;

            public A()
            {
                Val = 1;
            }

            public A(int val)
            {
                Val = val;
            }

            public int GetVal()
            {
                return Val;
            }
        }

        class B : A
        {
            public B(int x)
            {
                Val = x;
            }
        }

        public interface IFace { }
        public class X : IFace { }
        public class Y : IFace { }

        public class XClass
        {
            private string _name;

            public XClass(string name1)
            {
                _name = name1;
            }

            public string Name()
            {
                return _name;
            }

            public void Name(string name)
            {
                _name = name;
            }
        }
    }
}
