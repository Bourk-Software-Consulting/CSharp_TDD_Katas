using System;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private TennisGame tennisGame;
        private Mock<ITennisGui> guiMock;

        [SetUp]
        public void setup()
        {
            guiMock = new Mock<ITennisGui>();
            tennisGame = new TennisGame(guiMock.Object);
        }

        //Demo of a Mock Verify.
        [Test]
        public void TestGameStartsLoveLove()
        {
            tennisGame.start();
            VerifyScoreIsLoveLoveAtTheUI(); 
        }

        //Demo of a Mock Verify. Continued
        private void VerifyScoreIsLoveLoveAtTheUI()
        {
            guiMock.Verify(gui => gui.UpdateScore(It.IsAny<string>())); //This is testing London Style (interaction)
            guiMock.Verify(gui => gui.UpdateScore("Love:Love")); //This is testing Chicago Style (value)
        }

        [Test]
        public void TestPlayer2ScoresExpectLoveFifteen()
        {
            tennisGame.start();
            var score = tennisGame.Player2Scores();
            Assert.AreEqual("Love:Fifteen", score);
        }

        [Test]
        public void TestFifteenFifteen()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player2Scores();

            Assert.AreEqual("Fifteen:Fifteen", score);
        }

        [Test]
        public void TestLoveThirty()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();

            Assert.AreEqual("Love:Thirty", score);
        }

        //Demo Outside In. This test was created before the following and was failing for the longest time. 
        [Test]
        public void TestDeuceAndPlayer2ScoresExpectAdvantagePlayer2()
        {
            //Arrange
            string score;
            tennisGame.start();
            score = tennisGame.Player2Scores();//Love:Fifteen
            score = tennisGame.Player1Scores();//Fifteen:Fifteen
            score = tennisGame.Player2Scores();//Fifteen:Thirty
            score = tennisGame.Player1Scores();//Thirty:Thirty
            score = tennisGame.Player2Scores();//Thirty:Forty
            score = tennisGame.Player1Scores();//Deuce


            //ACT
            score = tennisGame.Player2Scores();

            //Assert
            Assert.AreEqual("Player2 Advantage", score);
        }

        [Test]
        public void TestPlayer2Wins()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();

            Assert.AreEqual("Player2 Wins", score);
        }

        [Test]
        public void TestPlayer1Wins()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();

            Assert.AreEqual("Player1 Wins", score);
        }

        [Test]
        public void TestDeuceOnPlayer2Score()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();

            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void TestDeuceOnPlayer1Score()
        {
            string score;
            tennisGame.start();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player1Scores();

            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void TestDeuceAndPlayer1ScoresExpectAdvantagePlayer1()
        {
            //Arrange
            string score;
            tennisGame.start();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player1Scores();
            score = tennisGame.Player2Scores();
            score = tennisGame.Player1Scores();
            //Deuce

            //ACT
            score = tennisGame.Player1Scores();

            //Assert
            Assert.AreEqual("Player1 Advantage", score);
        }
    }

    public class TennisGame
    {
        public int player1Score;
        public int player2Score;
        private string[] SCORES = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
        private ITennisGui _gui;

        public TennisGame(ITennisGui gui)
        {
            _gui = gui;
        }

        public void start()
        {
            var score = ParseScore();
            _gui.UpdateScore(score);
        }

        public string ParseScore()
        {
            return SCORES[player1Score] + ":" + SCORES[player2Score];
        }

        public string Player2Scores()
        {
            player2Score++;
            if (isDeuce(player2Score, player1Score))
                return "Deuce";
            if (isAWinner(player2Score, player1Score))
                return "Player2 Wins";
            if (isAdvantage(player2Score, player1Score))
                return "Player2 Advantage";

            return ParseScore();
        }

        public string Player1Scores()
        {
            player1Score++;
            if (isDeuce(player1Score, player2Score))
                return "Deuce";
            if (isAWinner(player1Score,player2Score))
                return "Player1 Wins";
            if (isAdvantage(player1Score, player2Score))
                return "Player1 Advantage";

            return ParseScore();
        }

        private bool isAdvantage(int playerAScore, int playerBScore)
        {
            if (playerAScore >= 3
                && playerAScore - playerBScore == 1)
                return true;
            return false;
        }

        private bool isDeuce(int playerAScore, int playerBScore)
        {
            if (playerAScore >= 3
                && playerAScore == playerBScore)
                return true;
            return false;
        }

        public bool isAWinner(int playerAscore, int playerBscore)
        {
            if (playerAscore >= 3
                && playerAscore - playerBscore > 2)
                return true;

            return false;
        }
    }

    public interface ITennisGui
    {
        void UpdateScore(string score);
    }
}