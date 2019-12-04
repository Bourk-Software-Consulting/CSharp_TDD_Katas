using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace TestKatas
{
    class testRockPaperScissors_DDD
    {
        private  Mock<IRockPaperScissorUi> mockUI ;
        private RockPaperScissor rockpaperscissor;

        [SetUp]
        public void setup()
        {
            mockUI = new Mock<IRockPaperScissorUi>();
            rockpaperscissor = new RockPaperScissor(mockUI.Object);
        }
        

        [Test]
        public void testRockScissorExpectRockCrushesScissors()
        {
            Mock<IRockPaperScissorUi> mockUI = new Mock<IRockPaperScissorUi>();
            RockPaperScissor rockpaperscissor = new RockPaperScissor(mockUI.Object);
            Player rock = new Rock(rockpaperscissor);
            Player scissor = new Scissor(rockpaperscissor);

            rockpaperscissor.play(rock,scissor);

            mockUI.Verify(m =>m.updateUI("Rock Crushes Scissor"));
        }


        private static IEnumerable<TestCaseData> RockPaperScissorCases()
        {
            var mockUI = new Mock<IRockPaperScissorUi>();

            var rockpaperscissor = new RockPaperScissor(mockUI.Object);

            var rock = new Rock(rockpaperscissor);
            var paper = new Paper(rockpaperscissor);
            var scissor = new Scissor(rockpaperscissor);

            yield return new TestCaseData(rock, paper, "Paper Covers Rock");
            yield return new TestCaseData(rock, scissor, "Rock Crushes Scissor");
            yield return new TestCaseData(paper, scissor, "Scissor Cuts Paper");
        }

        [Test, TestCaseSource("AddCases")]
        public void testRockPaperExpectPaperCoversRock()
        {
            Mock<IRockPaperScissorUi> mockUI = new Mock<IRockPaperScissorUi>();
            RockPaperScissor rockpaperscissor = new RockPaperScissor(ui: mockUI.Object);
            Player rock = new Rock(listener: rockpaperscissor);
            Player paper = new Paper(listener: rockpaperscissor);

            rockpaperscissor.play(player1: paper, player2: rock);
            rockpaperscissor.play(player1: rock, player2: paper);

            mockUI.Verify(expression: m => m.updateUI("Paper Covers Rock"),times: Times.AtLeast(callCount: 2));
        }

        [Test]
        public void testPaperScissorExpectScissorsCutPaper()
        {
            Mock<IRockPaperScissorUi> mockUI = new Mock<IRockPaperScissorUi>();
            RockPaperScissor rockpaperscissor = new RockPaperScissor(mockUI.Object);
            Player paper = new Paper(rockpaperscissor);
            Player scissor = new Scissor(rockpaperscissor);

            rockpaperscissor.play(paper, scissor);

            mockUI.Verify(m => m.updateUI("Scissors Cut Paper"));
        }
    }

    internal class Paper : Player
    {
        private readonly IPaperListener _listener;

        public Paper(IPaperListener listener)
        {
            _listener = listener;
        }

        protected internal void againstPaper()
        {
            _listener.draw();
        }

        protected internal override void againstRock()
        {
            _listener.PaperCoversRock();
        }

        public override void against(Player player2)
        {
            player2.againstPaper();
        }
    }

    internal interface IPaperListener : IRockPaperScissorListener
    {
        void PaperCoversRock();
        void PaperDisproveSpock();
    }
}
