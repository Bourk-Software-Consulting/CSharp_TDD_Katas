using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Kata_RockPaperScissors
{
    class RockPaperScissorsTests_DDD
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

        // DEMO TestCaseData - notice the injection of the mock in the constructor and the use of STATIC
        private static Mock<IRockPaperScissorUi> static_mockUI = new Mock<IRockPaperScissorUi>();
        private static RockPaperScissor static_rockpaperscissor = new RockPaperScissor(static_mockUI.Object);
        private static IEnumerable<TestCaseData> RockPaperScissorCases()
        {
            var rock = new Rock(static_rockpaperscissor);
            var paper = new Paper(static_rockpaperscissor);
            var scissor = new Scissor(static_rockpaperscissor);

            yield return new TestCaseData(rock, paper, "Paper Covers Rock");
            yield return new TestCaseData(rock, scissor, "Rock Crushes Scissor");
            yield return new TestCaseData(paper, scissor, "Scissor Cuts Paper");
        }

        [Test, TestCaseSource("RockPaperScissorCases")]
        public void testRockPaperExpectPaperCoversRock(Player one, Player two, string expected)
        {
            rockpaperscissor.play(one,two);
            static_mockUI.Verify(m => m.updateUI(expected));//FAILS - the call never performs.
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

        protected internal override void againstPaper()
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
