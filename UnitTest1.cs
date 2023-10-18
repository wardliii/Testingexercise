using System.Reflection;
using Hangman;
using Xunit;

namespace newchellangemarek
{
    public class UnitTest1
    {
        [Fact]
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
        }
    }
}