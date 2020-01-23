namespace Katas.RockPaperScissorDomainDrivenDesign
{
    internal interface IRockListener : IRockPaperScissorListener
    {
        void rockCrushesScissor();
        void rockCrushesLizzard();
    }
}