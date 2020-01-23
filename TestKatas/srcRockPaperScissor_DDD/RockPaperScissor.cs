namespace Kata_RockPaperScissors
{
    internal class RockPaperScissor : IRockListener, IScissorListener, IPaperListener
    {
        private readonly IRockPaperScissorUi _ui;

        public RockPaperScissor(IRockPaperScissorUi ui)
        {
            _ui = ui;
        }

        public void play(Player player1, Player player2)
        {
            player1.against(player2);
            player2.against(player1);
        }

        public void rockCrushesScissor()
        {
            _ui.updateUI("Rock Crushes Scissor");
        }

        public void rockCrushesLizzard()
        {
            _ui.updateUI("Rock Crushes Lizzard");

        }

        public void draw()
        {
            
        }

        public void scissorsCutPaper()
        {
            _ui.updateUI("Scissors Cut Paper");
        }

        public void scissorDecapitatesLizard()
        {
        }

        public void PaperCoversRock()
        {
            _ui.updateUI("Paper Covers Rock");
        }

        public void PaperDisproveSpock()
        {
        }
    }
}