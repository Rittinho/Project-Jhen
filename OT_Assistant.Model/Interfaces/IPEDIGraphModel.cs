using OT_Assistant.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Assistant.Model.Interfaces;
internal interface IPEDIGraphModel
{
    string GetName();
    PEDITopic[] GetTopics();
}
