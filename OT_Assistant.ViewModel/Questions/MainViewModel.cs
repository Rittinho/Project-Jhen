using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.ViewModel.Questions
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<QuestionViewModel> Questions { get; } = new();

        [ObservableProperty]
        private QuestionViewModel currentQuestion;

        public MainViewModel()
        {
            // Cria as perguntas proceduralmente, cada uma com sua própria lógica de resposta
            Questions.Add(new QuestionViewModel(
                "Qual a capital da França?",
                ("Paris", true),
                ("Madri", false),
                ("Roma", false)
            ));

            Questions.Add(new QuestionViewModel(
                "Qual o maior planeta do Sistema Solar?",
                ("Vênus", false),
                ("Júpiter", true),
                ("Marte", false)
            ));

            Questions.Add(new QuestionViewModel(
                "Qual o animal mais rápido do mundo?",
                ("Águia-real", false),
                ("Guepardo", true),
                ("Falcão-peregrino", false)
            ));

            // Define a primeira pergunta como a atual
            CurrentQuestion = Questions.FirstOrDefault();
        }

        // Comando para avançar para a próxima pergunta
        [RelayCommand]
        private void NextQuestion()
        {
            var currentIndex = Questions.IndexOf(CurrentQuestion);
            if (currentIndex < Questions.Count - 1)
            {
                CurrentQuestion = Questions[currentIndex + 1];
            }
            else
            {
                // Fim do quiz
                // Lógica para ir para a tela de resultados
            }
        }
    }
}
