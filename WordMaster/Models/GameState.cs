namespace WordMaster.Models
{
    public class GameState
    {
        public string? Word { get; set; }
        public int WordLength { get; set; }
        public int TotalGuesses { get; set; }

        public string? Guess { get; set; }
        public int CurrentGuesses { get; set; }
        public string[]? PreviousGuesses { get; set; }

        public bool WonGame { get; set; } = false;

        public bool IndexIsCorrect(int idx)
        {
            return Guess[idx] == Word[idx];
        }

        public bool WordHasIndex(int idx)
        {
            char check = Guess[idx];
            for (int i = 0; i < WordLength; i++)
            {
                if (i == idx) continue;
                if (Word[i] == check) return true;
            }
            return false;
        }
    }
}
