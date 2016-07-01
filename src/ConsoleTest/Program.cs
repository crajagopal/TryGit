using static System.Console;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {            
            Test();
            //WriteLine(FormatTest(877130.37));
            //WriteLine(FormatTest(.333));
        }

       

        /// <summary>
        /// Finds the Rank of a word
        /// </summary>
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

            if (W == "") return rank;
            for (var i = 0; i < W.Length; i++)
            {
                //How many characters which are not used, that come before current character                    
                for (var j = 0; j < 26; j++)
                {
                    if (j == (W[i] - 'a')) break;
                    if (C[j] <= 0) continue;
                    
                    var t = Fact(W.Length - i - 1);
                    for (var k = 0; k < 26; k++)
                    {
                        if (C[k] <= 0) continue;
                        if (k == j) t /= Fact(C[k] - 1);
                        else t /= Fact(C[k]);
                    }
                    rank += t;
                }
                C[W[i] - 'a']--;
            }
            return rank;

        }

        private static long Fact(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return Fact(n - 1)*n;
        }


        private static string FormatTest(double Vnum)
        {

            if (Vnum > 99000000)
            {
                return "Sorry, this will not generate numbers larger that 99 million.";
            }

            var v10Million = (int)Vnum / 10000000;
            var v1Million = (int)(Vnum % 10000000) / 1000000;
            var v100Thousand = (int)(Vnum % 1000000) / 100000;
            var v10Thousand = (int)(Vnum % 100000) / 10000;
            var v1Thousand = (int)(Vnum % 10000) / 1000;
            var vhundreds = (int)(Vnum % 1000) / 100;
            var vtens = (int)(Vnum % 100) / 10;
            var vones = (int)(Vnum % 10) / 1;

            var vcents = (int)(((Vnum % 1) * 100));

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
    }
}
