using Microsoft.Maui.Controls.Shapes;
using OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.ValueObjects;

namespace OT_Assistant.View.Pages.Components.MapItems.CodeBehind.Domain.Enity;
internal class GraphCell
{
    private readonly int _cellNumber;
    private readonly int _cellColumn;
    private readonly int _cellRow;
    private readonly CellColor _cellColor;

    private readonly Border _cell;
    public GraphCell(int number,int cellColumn ,int cellRow, CellColor cellColor)
    {
        _cellNumber = number;
        _cellColumn = cellColumn;
        _cellRow = cellRow;
        _cellColor = cellColor;

        _cell = CreateCell();
    }
    private Border CreateCell()
    {
        var newBorder = new Border()
        {
            BackgroundColor = _cellColor.ReadColor(),
            StrokeThickness = 2,
            Stroke = Colors.Transparent, 
            StrokeShape = new RoundRectangle
            {
                CornerRadius = 6
            },
            Content = new Label
            {
                TextColor = Color.FromArgb("202020"),
                FontFamily = "Rubik-Medium.ttf",
                Margin = 3,
                LineBreakMode = LineBreakMode.NoWrap,
                FontAttributes = FontAttributes.Bold,
                Text = _cellNumber.ToString(),
                FontSize = 12,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
        };
        return newBorder;
    }
    public Border GetCell() => _cell;
    public int ReadNumber() => _cellNumber;
    public int GetColumn() => _cellColumn;
    public int GetRow() => _cellRow;
}