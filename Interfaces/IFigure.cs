namespace Scripts.Figures
{
    internal interface IFigure
    {
        IPosition position { get; }

        int LegalMovesCount();
        bool isLegalMove(IPosition to);
        void Move(IPosition to);
    }
}