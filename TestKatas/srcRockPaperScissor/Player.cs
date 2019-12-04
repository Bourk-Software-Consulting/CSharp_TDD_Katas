namespace TestKatas
{
    internal abstract class Player
    {
        public abstract void against(Player player2);

        protected internal virtual void againstRock(){}
        protected internal virtual void againstPaper() { }
        protected internal virtual void againstScissor(){}
        protected internal virtual void againstLizzard(){}
    }
}