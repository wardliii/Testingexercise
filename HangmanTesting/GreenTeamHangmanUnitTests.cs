using Hangman;

namespace HangmanTesting
{
    public class GreenTeamHangmanUnitTests
    {
        // Allan Forsyth - ResetDisplay() testing

        // Test of reset display - should count zero letters with .IsVisible = true
        [Theory]
        [InlineData("Easy")]
        [InlineData("Medium")]
        [InlineData("Hard")]
        public void ResetDisplay_ShouldSetAllLettersToInvisible(string gametype)
        {
            // Arrange
            GamePage pageUnderTest = new(gametype);
            List<Label> listOfLettersOnPage = new();
            int countOfVisibleLetters = 0;

            for (int twelveLettersIterator = 1; twelveLettersIterator <= 12; twelveLettersIterator++)
            {
                string nameOfLabel = "Letter";
                nameOfLabel += twelveLettersIterator.ToString();
                listOfLettersOnPage.Add(pageUnderTest.Content.FindByName<Label>(nameOfLabel));
            }

            // Act
            foreach (Label labelInList in listOfLettersOnPage)
            {
                if (labelInList.IsVisible == true)
                {
                    countOfVisibleLetters++;
                }
            }

            // Assert
            Assert.Equal(0, countOfVisibleLetters);
            
        }


        [Theory]
        [InlineData("test", 4)]
        [InlineData("t3st", 4)]
        [InlineData("TEST", 4)]
        [InlineData("T3ST", 4)]
        [InlineData("a", 1)]
        [InlineData("A", 1)]
        [InlineData("ABCdef", 6)]
        [InlineData("razzmatazzes", 12)]
        [InlineData("RAZZMATAZZES", 12)]
        public void ResetDisplay_ShouldShowCorrectNumberOfVisibleUnderlineLabels(string testWord, int numberOfUnderlinesExpected) 
        {
            // Arrange
            GamePage pageUnderTest = new("Hard");
            List<Label> listOfUnderlinesOnPage = new();
            int countOfVisibleUnderlines = 0;

            for (int twelveUnderlinesIterator = 1; twelveUnderlinesIterator <= 12; twelveUnderlinesIterator++)
            {
                string nameOfLabel = "Underline";
                nameOfLabel += twelveUnderlinesIterator.ToString();
                listOfUnderlinesOnPage.Add(pageUnderTest.Content.FindByName<Label>(nameOfLabel));
            }

            // Act
            pageUnderTest.ResetDisplay(testWord);

            foreach (Label labelInList in listOfUnderlinesOnPage)
            {
                if (labelInList.IsVisible == true)
                {
                    countOfVisibleUnderlines++;
                }
            }

            // Assert
            Assert.Equal(numberOfUnderlinesExpected, countOfVisibleUnderlines);
        }






        // TEAM DEVELOPMENT NOTE - This test doesn't work. It flags an error "GamePage does not contain a definintion for 'easy'"
        /*[Fact]
        public void GamePage()
        {
            // Arranges
            int gameType = 1; // Set the type of game
            GamePage gamePage = new GamePage(gameType);

            // accessing the private CreateNewChallenge method
            MethodInfo createNewChallengeMethod = typeof(GamePage).GetMethod("CreateNewChallenge", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            createNewChallengeMethod.Invoke(gamePage, null);

            // Assert
            // Checks that a Word has been selected based on GameType (customize this based on your implementation)
            Assert.NotNull(gamePage.easy);

            // Check that Display has been reset (e.g., its count is zero)
            Assert.Equal(0, gamePage.Display.Count);
        }*/

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