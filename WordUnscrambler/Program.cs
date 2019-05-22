using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;

namespace WordUnscrambler
{
    public class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(String[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constant.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option)
                    {
                        case Constant.Manual:
                        case "m":
                            Console.Write(Constant.EnterScrambledWordsManually);
                            ScrambleWordManual();
                            break;
                        case Constant.File:
                        case "f":
                            Console.Write(Constant.EnterScrambledWordsViaFile);
                            ScrambleWordFile();
                            break;
                        default:
                            Console.WriteLine(Constant.OptionsNotRecognized);
                            continueWordUnscramble = false;
                            break;
                    }

                    var continueDecision = string.Empty;

                    do
                    {
                        Console.WriteLine(Constant.OptionsOnContinuingProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while (!continueDecision.Equals(Constant.Yes, StringComparison.OrdinalIgnoreCase) &&
                            (!continueDecision.Equals(Constant.No, StringComparison.OrdinalIgnoreCase)));

                    continueWordUnscramble = continueDecision.Equals(Constant.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble == true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constant.ErrorProgramWillBeTerminated);
            }
            
        }

        public static void ScrambleWordFile()
        {
            try
            {
                var fName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = fileReader.Read(fName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(Constant.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        public static void ScrambleWordManual()
        {
            var manInp = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manInp.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(Constant.wordFileName);
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var word in matchedWords)
                {
                    Console.WriteLine(Constant.MatchFound, word.ScrambledWord, word.Word);
                }
            }
            else
            {
                Console.WriteLine(Constant.MatchNotFound);
            }
        }
    }
}
