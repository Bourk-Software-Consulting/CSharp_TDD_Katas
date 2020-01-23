namespace Katas.RockPaperScissorDomainDrivenDesign
{
    internal interface IScissorListener: IRockPaperScissorListener
    {
        void scissorsCutPaper();
        void scissorDecapitatesLizard();
    }
}