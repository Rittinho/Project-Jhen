using Microsoft.Maui.Controls.Shapes;
using OT_Assistant.Model.ValueObjects;
using OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.Utils;
using OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.ValueObjects;
using OT_Assistant.ViewModel;

namespace OT_Assistant.View.Pages.Components.MapItems.View;

public partial class ItemMapGraphComponent : ContentView
{
    public ItemMapGraphProperty defaultGraph;
    private Grid[]? grids;
    private CellPosition[]? _Positions;
    private ScorePEDI? _scorePEDI;
    private AnswerPEDI[]? _answerPEDI;
    
    public ItemMapGraphComponent()
	{
		InitializeComponent();
        SetDefautGraph();
        BindingContext = new Testing();
        CreateGraph(grids!, defaultGraph!);
        CreateRuler();
        ShowCellsCount(defaultGraph!.GetAnswerPEDI(), defaultGraph.GetScorePEDI(), defaultGraph.GetPositions());

    }

    private void CreateGraph(Grid[] paternGrid, ItemMapGraphProperty itemMapGraphProperty)
    {
        GraphName.Text = itemMapGraphProperty.GetGraphName();
        int lastNUm = 0;
        for (int i = 0; i<itemMapGraphProperty.GetPositions().Length; i++)
        {
            var positions = itemMapGraphProperty.GetPositions()[i];

            ItemMapGraphTools.CreateTopicContainer(
                paternGrid[i],
                positions,
                itemMapGraphProperty.GetScorePEDI(),
                itemMapGraphProperty.GetAnswerPEDI()[i],
                lastNUm);

            lastNUm += positions.GetPosition().Length;
        }
        CreateBarComparer(CompareBar,5,itemMapGraphProperty.GetScorePEDI());
    }

    public static void CreateBarComparer(Grid parentGrid, int rows, ScorePEDI scorePEDI)
    {

        var barGrid = new Grid();

        barGrid.ColumnDefinitions.Clear();

        const int maxScore = 1000;

        var firstColumnWidth = new GridLength(scorePEDI.ReadScore(), GridUnitType.Star);

        var barWidth = new GridLength(10, GridUnitType.Absolute);

        var thirdColumnWidth = new GridLength(maxScore - scorePEDI.ReadScore(), GridUnitType.Star);

        // Adicione as três colunas à Grid.
        barGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = firstColumnWidth });
        barGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = barWidth });
        barGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = thirdColumnWidth });

        // Crie a barra (BoxView) e posicione-a na coluna do meio
        var errorBar = new BoxView()
        {
            Opacity = 0.08,
            WidthRequest = scorePEDI.ReadDefaultError() * 2+3,
            BackgroundColor = Colors.Yellow, // Uma cor forte para garantir que seja visível
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Margin = 0,// Garante que a barra preenche a coluna
        };
        var scoreBar = new BoxView
        {
            WidthRequest = 2.5,
            Color = Colors.Red, // Uma cor forte para garantir que seja visível
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Margin = 0 // Garante que a barra preenche a coluna
        };
        Grid.SetColumn(errorBar, 1); // Posiciona a barra na segunda coluna (índice 1)

        // Adicione a barra à sua Grid de sobreposição
        barGrid.Children.Add(errorBar);

        Grid.SetColumn(scoreBar, 1); // Posiciona a barra na segunda coluna (índice 1)

        // Adicione a barra à sua Grid de sobreposição
        barGrid.Children.Add(scoreBar);

        // Posicione esta Grid na coluna do Grid pai (coluna 1)
        Grid.SetColumn(barGrid, 1);

        // Faça com que ela se estenda por todas as linhas de tópicos
        Grid.SetRowSpan(barGrid, rows);

        // Use um ZIndex alto para garantir que ela fique por cima
        barGrid.SetValue(Grid.ZIndexProperty, 2);

        // Adicione a Grid de sobreposição ao Grid pai
        parentGrid.Children.Add(barGrid);
    }
    public void ShowCellsCount(AnswerPEDI[] answers, ScorePEDI scorePEDI, CellPosition[] cellPositions)
    {
        int green = 0;
        int red = 0;
        int yellow = 0;
        int blue = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            var currentAnswer = answers[i].ReadAnswers();
            var currentPositions = cellPositions[i].GetPosition();
            for (int j = 0; j < currentAnswer.Length ; j++)
            {
                if (currentAnswer[j])
                {
                    green++;
                    continue;
                }

                if (currentPositions[j] <= scorePEDI.ReadScore() + scorePEDI.ReadDefaultError() && currentPositions[j] >= scorePEDI.ReadScore() - scorePEDI.ReadDefaultError())
                {
                    yellow++;
                    continue;
                }

                if (currentPositions[j] <= scorePEDI.ReadScore() + scorePEDI.ReadDefaultError() && !currentAnswer[j])
                {
                    red++;
                    continue;
                }

                blue++;
            }
        }

        IsCapableCount.Text = green.ToString();
        NotCapableCount.Text = red.ToString();
        InObservationCount.Text = yellow.ToString();
        WillLearnCount.Text = blue.ToString();
    }
    public void SetDefautGraph()
    {
        grids = [FeedingGrid,PersonalHygieneGrid,BathGrid,DressingGrid,ToiletriesGrid];
        _Positions = new CellPosition[5];
        _Positions[0] = new CellPosition(
                [0, 140, 350, 450, 0, 240, 450, 680, 640, 0, 180, 350, 420, 630],
                [2, 2, 2, 2, 1, 2, 1, 2, 2, 0, 2, 1, 2, 1]);
        _Positions[1] = new CellPosition(
                [200, 290, 470, 730, 590, 190, 250, 540, 770, 200, 470, 450, 640, 680, 200, 350, 440, 330, 530],
                [3, 3, 3, 3, 3, 2, 3, 3, 3, 1, 2, 1, 3, 3, 0, 3, 2, 2, 2]);
        _Positions[2] = new CellPosition(
                [320, 460, 580, 710, 750],
                [1, 1, 1, 1, 1]);
        _Positions[3] = new CellPosition(
                [170, 390, 550, 590, 680, 390, 470, 680, 670, 770, 250, 400, 570, 640, 680, 270, 490, 590, 650, 850],
                [4, 4, 4, 4, 4, 3, 4, 3, 2, 4, 4, 2, 3, 4, 1, 3, 3, 2, 3, 4]);
        _Positions[4] = new CellPosition(
                [470, 540, 590, 570, 760, 480, 480, 490, 530, 610, 430, 680, 490, 490, 540],
                [6, 6, 6, 5, 6, 1, 5, 4, 5, 5, 6, 6, 3, 2, 4]);

        _scorePEDI = new ScorePEDI(700, 50);

        _answerPEDI = new AnswerPEDI[5];
        _answerPEDI[0] = new AnswerPEDI([true, true, true, true, true, true, false, false, false, true, true, true, false, false]);
        _answerPEDI[1] = new AnswerPEDI([true, true, true, false, false, true, true, false, false, true, false, true, false, false, true, true, true, false, false]);
        _answerPEDI[2] = new AnswerPEDI([false, false, false, false, false]);
        _answerPEDI[3] = new AnswerPEDI([true, true, true, true, false, true, true, true, false, false, true, true, false, false, false, true, false, false, false, false]);
        _answerPEDI[4] = new AnswerPEDI([false, false, false, false, false, false, false, false, false, false, false, false, false, false, false]);

        defaultGraph = new ItemMapGraphProperty(
            "Auto cuidado",
            _Positions,
            _scorePEDI,
            _answerPEDI);
    }

    private void CreateRuler()
    {
        RulerGrid.Clear();

        var childGrid = new Grid()
        {
            Margin = new Thickness(25, 0, 15, 0),
        };
        bool flipGridType = false;

        for (int i = 0; i < 21; i++)
        {
            flipGridType = !flipGridType;
            if (flipGridType)
            {
                childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                continue;
            }
            childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }
        int columnGrid = 0;
        bool flipLogic = false;
        for (int i = 0; i < 21; i++)
        {
            flipLogic = !flipLogic;
            if (flipLogic)
            {
                childGrid.Add(CreateLabel(columnGrid + "0", 16), i, 0);
                columnGrid++;
                continue;
            }
            childGrid.Add(CreateDecimalDots(), i, 0);
        }

        RulerGrid.Add(childGrid);
    }
    private Grid CreateDecimalDots()
    {
        var childGrid = new Grid();

        for (int i = 0; i < 9; i++)
            childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        for (int i = 0; i < 9; i++)
            childGrid.Add(CreateDot(), i, 0);

        return childGrid;
    }

    private Label CreateLabel(string num, int size)
    {
        var label = new Label()
        {
            TextColor = Colors.White,
            FontFamily = "Rubik-Medium.ttf",
            Margin = 5,
            LineBreakMode = LineBreakMode.NoWrap,
            FontAttributes = FontAttributes.Bold,
            Text = num,
            FontSize = size,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        return label;
    }
    private Border CreateDot()
    {
        var newBorder = new Border()
        {
            BackgroundColor = Colors.White,
            StrokeThickness = 0,
            HeightRequest = 4,
            WidthRequest = 1,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = 100
            },
        };
        return newBorder;
    }
}