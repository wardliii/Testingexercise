using Hangman;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using SQLitePCL;

namespace Test_CheckLetterInWord
{
    public class UnitTest
    {
        [Fact]
        public void Test_CheckLetterInWord_False()
        {
            // This unit test tests whether the CheckLetterInWord() method returns false if the answer given by the player isn't 
            // included in the word

            string gameType = "Easy";
            string word = "toe";
            char answer = 'a';
            bool expected = false;
            GamePage gamePage = new GamePage(gameType);
            Assert.Equal(expected, gamePage.CheckLetterInWord(word, answer));            
        }
        [Fact]
        public void Test_CheckLetterInWord_True()
        {
            // This unit test tests whether the CheckLetterInWord() method returns true if the answer given by the player is 
            // included in the word

            string gameType = "Easy";
            string word = "toe";
            char answer = 'o';
            bool expected = true;
            GamePage gamePage = new GamePage(gameType);
            Assert.Equal(expected, gamePage.CheckLetterInWord(word, answer));
        }
    }
}