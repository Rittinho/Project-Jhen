using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.ViewModel.Questions
{
    public partial class QuestionViewModel : ObservableObject
    {
        [ObservableProperty]
        private string questionText;

        public ObservableCollection<AnswerViewModel> Answers { get; } = new();

        public QuestionViewModel(string text, params (string answerText, bool isCorrect)[] answers)
        {
            QuestionText = text;

            foreach (var (answerText, isCorrect) in answers)
            {
                Answers.Add(new AnswerViewModel(answerText, isCorrect));
            }
        }
    }
}
