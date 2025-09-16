using OT_Assistant.Model.Interfaces;
using OT_Assistant.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.Model.Models;
internal class PEDIFunctionalSkills : IPEDIGraphModel
{
    private readonly string _name = "FunctionalSkills";
    private readonly List<PEDITopic> _topics;
    public PEDIFunctionalSkills() => AddGraphFunctionalSkills();
    public string GetName() => _name;
    public PEDITopic[] GetTopics() => [.._topics];
    private void AddGraphFunctionalSkills()
    {
        _topics.Add(new PEDITopic("Feeding",
            new CellPosition(
            [0, 140, 350, 450, 0, 240, 450, 680, 640, 0, 180, 350, 420, 630],
            [2, 2, 2, 2, 1, 2, 1, 2, 2, 0, 2, 1, 2, 1])));
        _topics.Add(new PEDITopic("RersonalHygiene",
           new CellPosition(
           [200, 290, 470, 730, 590, 190, 250, 540, 770, 200, 470, 450, 640, 680, 200, 350, 440, 330, 530],
           [3, 3, 3, 3, 3, 2, 3, 3, 3, 1, 2, 1, 3, 3, 0, 3, 2, 2, 2])));
        _topics.Add(new PEDITopic("Bath",
           new CellPosition(
           [320, 460, 580, 710, 750],
           [1, 1, 1, 1, 1])));
        _topics.Add(new PEDITopic("Bath",
           new CellPosition(
           [320, 460, 580, 710, 750],
           [1, 1, 1, 1, 1])));
        _topics.Add(new PEDITopic("Dressing",
           new CellPosition(
           [170, 390, 550, 590, 680, 390, 470, 680, 670, 770, 250, 400, 570, 640, 680, 270, 490, 590, 650, 850],
           [4, 4, 4, 4, 4, 3, 4, 3, 2, 4, 4, 2, 3, 4, 1, 3, 3, 2, 3, 4])));
        _topics.Add(new PEDITopic("Toiletries",
           new CellPosition(
           [470, 540, 590, 570, 760, 480, 480, 490, 530, 610, 430, 680, 490, 490, 540],
           [6, 6, 6, 5, 6, 1, 5, 4, 5, 5, 6, 6, 3, 2, 4])));
    }
}
