using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OT_Assistant.ViewModel.Questions
{
    public partial class AnswerViewModel : ObservableObject
    {
        // Propriedades para a View
        [ObservableProperty]
        private string answerText;

        [ObservableProperty]
        private string buttonColor = "LightGray";

        [ObservableProperty]
        private bool isButtonEnabled = true;

        // Propriedade interna para a lógica
        private bool _isCorrect;

        public AnswerViewModel(string text, bool isCorrect)
        {
            AnswerText = text;
            _isCorrect = isCorrect;
        }

        // O comando acionado pelo botão na View
        [RelayCommand]
        private void OnClick()
        {
            if (_isCorrect)
            {
                ButtonColor = "Green";
            }
            else
            {
                ButtonColor = "Red";
            }

            IsButtonEnabled = false;
        }
    }
}
