using System;
using System.Collections.Generic;
using System.Text;

namespace WordUnscrambler
{
    class Constant
    {
        public const string OptionsOnHowToEnterScrambledWords = "Please enter an option (M - Manual) or (F - File): ";
        public const string OptionsOnContinuingProgram = "Do you want to continue (Y/N)? ";

        public const string EnterScrambledWordsViaFile = "Enter full path including file name: ";
        public const string EnterScrambledWordsManually = "Enter words manually, separated by commas if multiple: ";

        public const string OptionsNotRecognized = "Option not recognized :(";
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded because there was an error :(";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches found";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordFileName = "wordlist.txt";
    }
}
