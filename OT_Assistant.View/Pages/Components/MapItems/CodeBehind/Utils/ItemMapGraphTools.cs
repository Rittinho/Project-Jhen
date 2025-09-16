using OT_Assistant.Model.ValueObjects;
using OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.Enity;
using OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.ValueObjects;

namespace OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.Utils;
internal class ItemMapGraphTools
{
    private static GraphCell CreateCell(int number, int column, int row, CellColor cellColor) => new (number, column, row, cellColor);
    public static GraphCell[] GerateCellsList(CellPosition cellPosition, ScorePEDI scorePEDI, AnswerPEDI answer , int iniInThisPoint)
    {
        var cells = new GraphCell[cellPosition.GetRow().Length];

        for (var i = 0; i < cellPosition.GetRow().Length; i++)
        {
            cells[i] = CreateCell(i + (iniInThisPoint + 1),
                cellPosition.GetPosition()[i],
                cellPosition.GetRow()[i],
                new CellColor(answer.ReadAnswers()[i], cellPosition.GetPosition()[i], scorePEDI));
        }
        return cells;
    }
    public static Grid CreateGrid(CellPosition cellPositions)
    {
        var grid = new Grid
        {
            RowDefinitions = [],
            ColumnDefinitions = [],
        };

        for (int c = 0; c < (1000); c++)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        for (var r = 0; r <= ExtractRowsAmount(cellPositions); r++)
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        return grid;
    }
    public static void CreateTopicContainer(Grid parentGrid, CellPosition position, ScorePEDI scorePEDI, AnswerPEDI answerPEDI,int lastCellNumber)
    {
        var childGrid = CreateGrid(position);
        var cells = GerateCellsList(position, scorePEDI, answerPEDI, lastCellNumber);
        SetCellInGrid(childGrid, cells, 30);

        parentGrid.Children.Add(childGrid);
    }
    public static void CreateBarComparer(Grid parentGrid, int rows)
    {
        var topicGrid = new Grid();
        topicGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        topicGrid.ColumnDefinitions.Add(new ColumnDefinition(new GridLength(5.8822, GridUnitType.Star)));
        for (var r = 0; r <= rows; r++)
            topicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        topicGrid.MinimumHeightRequest = 10;


        // cria o grafico
        var grid = new Grid
        {
            RowDefinitions = [],
            ColumnDefinitions = [],
        };

        for (int c = 0; c < (1000); c++)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        var test = new BoxView
        {
            Color = Colors.Red, // Uma cor forte para garantir que seja visível
            WidthRequest = 30,// Defina uma altura fixa
            HeightRequest = 600,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill
        };

        Grid.SetColumn(test, 300);

        // Faça-o abranger todas as linhas dos tópicos
        Grid.SetColumn(grid, 1);
        Grid.SetRowSpan(grid, rows);
        grid.SetValue(Grid.ZIndexProperty, 11);

        topicGrid.Children.Add(grid);
        parentGrid.Children.Add(topicGrid);
    }
    private static void SetCellInGrid(Grid childGrid, GraphCell[] cells, int cellSpan)
    {
        foreach (var curretCell in cells)
        {
            Grid.SetColumn(curretCell.GetCell(), curretCell.GetColumn());
            Grid.SetRow(curretCell.GetCell(), curretCell.GetRow());
            Grid.SetColumnSpan(curretCell.GetCell(), cellSpan);
            childGrid.Children.Add(curretCell.GetCell());
        }
    }
    private static int ExtractRowsAmount(CellPosition cellPositions)
    {
        int rows = 0;
        foreach (var cellPosition in cellPositions.GetRow())
        {
            if (cellPosition >= rows)
                rows = cellPosition;
        }
        return rows;
    }
    public static void ClearGrid(Grid grid)
    {
        grid.Children.Clear();
        grid.RowDefinitions.Clear();
        grid.ColumnDefinitions.Clear();
    }
}
