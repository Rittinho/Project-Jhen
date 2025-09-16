namespace OT_Assistant.Model.ValueObjects;
public class ItemMapGraphProperty (string name, CellPosition[] position, ScorePEDI scorePEDI, AnswerPEDI[] answerPEDIs)
{
    private readonly string _name = name;
    private readonly CellPosition[] _position = position;
    private readonly ScorePEDI _scorePEDI = scorePEDI;
    private readonly AnswerPEDI[] _answerPEDI = answerPEDIs;
    public string GetGraphName() => _name;
    public CellPosition[] GetPositions() => _position;
    public ScorePEDI GetScorePEDI() => _scorePEDI;
    public AnswerPEDI[] GetAnswerPEDI() => _answerPEDI;
}