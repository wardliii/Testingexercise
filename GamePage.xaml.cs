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
    public void ResetDisplay(string word)
    {
        Letter1.IsVisible = false;
        Letter2.IsVisible = false;
        Letter3.IsVisible = false;
        Letter4.IsVisible = false;
        Letter5.IsVisible = false;
        Letter6.IsVisible = false;
        Letter7.IsVisible = false;
        Letter8.IsVisible = false;
        Letter9.IsVisible = false;
        Letter10.IsVisible = false;
        Letter11.IsVisible = false;
        Letter12.IsVisible = false;

        Underline1.IsVisible = false;
        Underline2.IsVisible = false;
        Underline3.IsVisible = false;
        Underline4.IsVisible = false;
        Underline5.IsVisible = false;
        Underline6.IsVisible = false;
        Underline7.IsVisible = false;
        Underline8.IsVisible = false;
        Underline9.IsVisible = false;
        Underline10.IsVisible = false;
        Underline11.IsVisible = false;
        Underline12.IsVisible = false;

        for (int letterInWord = 0; letterInWord < word.Length; letterInWord++)
        {

            switch (letterInWord)
            {
                case 0:
                    Underline1.IsVisible = true;
                    break;
                case 1:
                    Underline2.IsVisible = true;
                    break;
                case 2:
                    Underline3.IsVisible = true;
                    break;
                case 3:
                    Underline4.IsVisible = true;
                    break;
                case 4:
                    Underline5.IsVisible = true;
                    break;
                case 5:
                    Underline6.IsVisible = true;
                    break;
                case 6:
                    Underline7.IsVisible = true;
                    break;
                case 7:
                    Underline8.IsVisible = true;
                    break;
                case 8:
                    Underline9.IsVisible = true;
                    break;
                case 9:
                    Underline10.IsVisible = true;
                    break;
                case 10:
                    Underline11.IsVisible = true;
                    break;
                case 11:
                    Underline12.IsVisible = true;
                    break;
                default: break;
            }


        }

    }

    /*!
	 * Uses the GameType to select a word from the list by its length:
	 * Easy : length < 7
	 * Medium : 7 <= length < 10
	 * Hard : length >= 10
	 */
    private string SelectWord(string gameType)
    {
        string[] words;
        string filePath = "C:\\Users\\alexa\\source\\repos\\wardliii\\Testingexercise\\Resources\\Raw\\wordList.txt";


        try
        {
            words = File.ReadAllLines(filePath);
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException("Word list file not found at: " + filePath);
        }

        List<string> filteredWords = new List<string>();


        foreach (string word in words)
        {
            if (gameType.Equals("Easy"))
            {
                if (word.Length < 7)
                {
                    filteredWords.Add(word);
                }
            }
            else if (gameType.Equals("Medium"))
            {
                if (word.Length >= 7 && word.Length < 10)
                {
                    filteredWords.Add(word);
                }
            }
            else if (gameType.Equals("Hard"))
            {
                if (word.Length >= 10)
                {
                    filteredWords.Add(word);
                }
            }

        }

        // Check if there are words in the filtered list
        if (filteredWords.Count == 0)
        {
            throw new InvalidOperationException("No words available for the specified game type: " + gameType);
        }

        // Select a random word from the filtered list
        Random random = new Random();
        int randomIndex = random.Next(0, filteredWords.Count);
        return filteredWords[randomIndex];
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
    public bool CheckLetterInWord(string word, char answer)
    {
        if (word.Contains(answer))
            return true;
        else
            return false;
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