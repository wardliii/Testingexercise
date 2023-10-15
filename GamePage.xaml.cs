using Hangman.Models;
using Windows.Data.Text;
using Windows.Media.AppBroadcasting;

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
    public void OnAttemptSubmitted(object sender, EventArgs e)
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
    public bool CheckLetterInWord(string word, char answer)
    {
		if (string.IsNullOrEmpty(word))
		{
			return false;
		}else if (!char.IsLetter(answer))
		{
			return false;
		}
		return true;
    }


    /*!
	 * Changes the image shown on the page and
	 * Updates the visibility of the labels representing the letters in the word
	 */
    private void UpdateDisplay(bool isCorrect, string word, char letter, int remainingAttempts)
    {
        throw new NotImplementedException();
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