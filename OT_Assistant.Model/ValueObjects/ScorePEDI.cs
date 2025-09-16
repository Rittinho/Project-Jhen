namespace OT_Assistant.Model.ValueObjects;
public class ScorePEDI
{
    private readonly int _score;
    private readonly int _defaultError;
    public ScorePEDI(int score, int defaultError) => (_score, _defaultError) = (score, defaultError);
    public int ReadScore() => _score;
    public int ReadDefaultError() => _defaultError;
}
