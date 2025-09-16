using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.Model.ValueObjects;
public class PEDITopic
{
    private readonly string _name;
    private readonly CellPosition _cellPosition;
    public PEDITopic(string name, CellPosition cellPosition) => (_name, _cellPosition) = (name, cellPosition);
    public string GetName() => _name;
    public CellPosition GetCellPosition() => _cellPosition;
}
