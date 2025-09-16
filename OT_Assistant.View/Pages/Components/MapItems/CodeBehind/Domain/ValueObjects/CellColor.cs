using OT_Assistant.Model.ValueObjects;

namespace OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.ValueObjects;
internal class CellColor(bool answer, int position, ScorePEDI scorePEDI)
{
    private readonly Color _color = SetColorByAnswer(answer, position, scorePEDI);
    private static Color SetColorByAnswer(bool answer, int position, ScorePEDI scorePEDI)
    {
        if (answer)
            return Color.FromArgb("98dfaf");

        if (position <= scorePEDI.ReadScore() + scorePEDI.ReadDefaultError()&& position >= scorePEDI.ReadScore() - scorePEDI.ReadDefaultError())
            return Color.FromArgb("f4d06f");

        if (position <= scorePEDI.ReadScore() + scorePEDI.ReadDefaultError() && !answer)
            return Color.FromArgb("#e57373");

        return Color.FromArgb("5a9bd4");
    }
    public Color ReadColor() => _color;
}
