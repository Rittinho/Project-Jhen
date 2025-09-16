using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.View.Pages.Components.Questionnaire.CodeBehind;
class Question
{
    public readonly int _num; 
    public readonly string _name;
    public readonly Border _question = new();
    public Question(int num, string name)
    {
        _num = num;
        _name = name;
        _question = GerateQuestion();
    }
    private Border GerateQuestion()
    {
        var border = new Border()
        {

        };
        return null;
    }
}
