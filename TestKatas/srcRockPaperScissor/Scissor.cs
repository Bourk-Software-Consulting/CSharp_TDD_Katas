namespace TestKatas
{
    internal class Scissor : Player
    {
        private readonly IScissorListener _listener;

        public Scissor(IScissorListener listener)
        {
            _listener = listener;
        }

        public override void against(Player player2)
        {
            player2.againstScissor();
        }

        protected internal override void againstPaper()
        {
            _listener.scissorsCutPaper();
        }


        protected internal override void againstScissor()
        {
            _listener.draw();
        }

    }
}