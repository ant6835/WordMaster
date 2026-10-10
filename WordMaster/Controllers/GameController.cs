using Microsoft.AspNetCore.Mvc;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class GameController : Controller
    {
        GameContext context { get; set; }

        Random random { get; set; }

        public GameController(GameContext ctx)
        {
            context = ctx;
            random = new();
        }

        [HttpGet]
        public IActionResult Start()
        {
            List<Word> words = context.Words.ToList();

            if (words is null)
            {
                return RedirectToAction("Index", "Home");
            }

            int count = words.Count;
            string word = words[random.Next(count)].Value;

            if (word is null)
            {
                return RedirectToAction("Index", "Home");
            }

            int length = word.Length;
            GameState state = new GameState
            {
                Word = word,
                WordLength = length,
                TotalGuesses = 6, // hardcoded for now, difficulty can be added later

                CurrentGuesses = 6
            };

            TempData.Clear();

            return View("Game", state);
        }

        [HttpPost]
        public IActionResult GameOver(bool retry)
        {
            TempData.Clear();
            if (retry)
                return RedirectToAction("Start");
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Guess(GameState state)
        {
            if (state == null || state.Word == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrWhiteSpace(state.Guess))
            {
                ModelState.AddModelError("Guess", "Must enter a value for your guess.");
                return View("Game", state);
            }

            state.Guess = state.Guess.Trim().ToLowerInvariant();

            if (state.Guess.Length != state.WordLength)
            {
                ModelState.AddModelError("Guess", $"Guess must be exactly {state.WordLength} letters long.");
                return View("Game", state);
            }

            // check if game is won
            if (state.Word == state.Guess)
            {
                state.WonGame = true;
                state.CurrentGuesses--;
                return View("Game", state);
            }

            // set previous guess
            int currentGuess = state.TotalGuesses - state.CurrentGuesses;

            for (int i = 0; i <= currentGuess; i++)
            {
                TempData[$"Guess{i}"] = state.Guess;
            }

            state.CurrentGuesses--;

            return View("Game", state);
        }
    }
}
