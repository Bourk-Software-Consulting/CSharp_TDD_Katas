namespace Katas.RockPaperScissorDomainDrivenDesign
{
    internal class Rock : Player
    {
        private IRockListener _listener;

        public  Rock(IRockListener listener)
        {
            _listener = listener;
        }

        public override void against(Player player2)
        {
            player2.againstRock();
        }

        protected internal override void againstScissor()
        {
            _listener.rockCrushesScissor();
        }

        protected internal override void againstLizzard()
        {
            _listener.rockCrushesLizzard();
        }

        protected internal override void againstRock()
        {
            _listener.draw();
        }
    }
}