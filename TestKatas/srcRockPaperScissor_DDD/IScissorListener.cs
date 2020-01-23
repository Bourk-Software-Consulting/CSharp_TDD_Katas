namespace Kata_RockPaperScissors
{
    internal interface IScissorListener: IRockPaperScissorListener
    {
        void scissorsCutPaper();
        void scissorDecapitatesLizard();
    }
}