namespace OT_Assistant.Model.ValueObjects;
public class AnswerPEDI(bool[] answers)
{
    private readonly bool[] _answers = answers;
    public bool[] ReadAnswers() => _answers;
}
