using System;
using Xunit;

namespace Hangman.Test
{
    public class HangmanShould
    {
        [Fact]
        public void BeAliveWhenNew()
        {
            HangmanGame newGame = new HangmanGame();
            Assert.True(newGame.keepAlive);

        }
        [Fact]
        public void HaveTenGuessesAfterInit()
        {
            HangmanGame newGame = new HangmanGame();
            newGame.InitGame();
            Assert.Equal<int>(10,newGame.guessesLeft);
        }

        [Fact]
        public void HaveSameLengthForWordAndSecret()
        {
            HangmanGame newGame = new HangmanGame();
            newGame.InitGame();
            Assert.Equal(newGame.theWord.Length,newGame.secretWord.Length);
        }


    }
}
