
using System.Reflection;
using Hangman;
using Microsoft.Maui;
using Xunit;
using System.IO;
namespace SelectWord
{
    public class SelectWord
    {
        [Fact]
        public void SelectWord_EasyGameType_ReturnsWordWithLessThan7Characters()
        {
            // Arrange
            MethodInfo methodInfo = typeof(GamePage).GetMethod("SelectWord", BindingFlags.NonPublic | BindingFlags.Instance);
            string gameType = "Easy";
            GamePage gamePage = new GamePage(gameType); // Initialisation de votre classe GamePage

            // Utilisez la réflexion pour appeler la méthode privée
            string selectedWord = (string)methodInfo.Invoke(gamePage, new object[] { gameType });


            // Assert
            Assert.True(selectedWord.Length < 7);
        }




        [Fact]
        public void SelectWord_HardGameType_ReturnsWordWithMoreThan10Characters()
        {
            // Arrange
            MethodInfo methodInfo = typeof(GamePage).GetMethod("SelectWord", BindingFlags.NonPublic | BindingFlags.Instance);
            string gameType = "Hard";
            GamePage gamePage = new GamePage(gameType); // Initialisation de votre classe GamePage

            // Utilisez la réflexion pour appeler la méthode privée
            string selectedWord = (string)methodInfo.Invoke(gamePage, new object[] { gameType });


            // Assert
            Assert.True(selectedWord.Length >= 10);
        }

    }

}