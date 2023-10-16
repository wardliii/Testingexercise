using Hangman.Models;
using SQLitePCL;
using System.Xml.Linq;
using System.Text;
//using Windows.Data.Text;
//using Windows.Media.AppBroadcasting;
//using Windows.System;

namespace Hangman;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }
	List<char> LettersTried { get; set; }
	char CurrentLetterGuess { get; set; }
	public string Word {  get; set; }

	int remainingAttempts = 7;

	public GamePage(string gameType)
	{
		InitializeComponent();

        GameType = gameType;
		BindingContext = this;

		CreateNewChallenge();
	}

	/* Requires testing */
	private void CreateNewChallenge()
	{
		Word = SelectWord(GameType);
		ResetDisplay(Word);
	}

    /*!
	 * Resets the display to the initial image and
	 * the appropriate number of visible labels
	 */
    private void ResetDisplay(string word)
    {
        
    }

    /*!
	 * Uses the GameType to select a word from the list by its length:
	 * Easy : length < 7
	 * Medium : 7 <= length < 10
	 * Hard : length >= 10
	 */
    private string SelectWord(string gameType)
    {
		return "placeholder";
    }

	/* Requires testing */
    private void OnAttemptSubmitted(object sender, EventArgs e)
	{
        var answer = AnswerEntry.Text[0];
        var isCorrect = false;

		isCorrect = CheckLetterInWord(Word, answer);
		UpdateDisplay(isCorrect, Word, answer, remainingAttempts);

        remainingAttempts--;
		AnswerEntry.Text = "";
		AnswerEntry.Focus();

        if (remainingAttempts == 0)
		{
			GameOver();
		}
    }

    /*!
	 * Uses the GameType to select a word from the list by its length:
	 * Easy : length < 7
	 * Medium : 7 <= length < 10
	 * Hard : length >= 10
	 */
    private bool CheckLetterInWord(string word, char answer)
    {
        throw new NotImplementedException();

    }


    /*!
	 * Changes the image shown on the page and
	 * Updates the visibility of the labels representing the letters in the word
	 */
    public string UpdateDisplay(bool isCorrect, string word, char letter, int remainingAttempts)
    {
		StringBuilder updatedDisplay = new StringBuilder(word.Length);

		if (isCorrect)
		{
			for (int i = 0; i < word.Length; i++)
			{
				if (word[i] == letter)
				{
					string labelName = $"Letter{i + 1}";
					Label label = (Label)FindByName(labelName);
					label.Text = letter.ToString();

					updatedDisplay.Append(letter);
				}
				else
				{
					updatedDisplay.Append("_");
				}
			}
		}
		else
		{
			for (int i = 0; i < word.Length; i++)
			{
				updatedDisplay.Append("_");
			}

			remainingAttempts--;
		}

		return updatedDisplay.ToString();
    }


    /*!
	 * Resets all game variables and displays the final result
	 * Also displays the options to return to the menu, exit or play again
	 */
    private void GameOver()
	{
        throw new NotImplementedException();
    }

    private void OnBackToMenu(object sender, EventArgs e)
	{
        Navigation.PushAsync(new MainPage());
	}
}