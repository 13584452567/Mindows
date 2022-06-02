using Mindows.Basic.Calling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mindows.Basic.Data
{
    interface ICommandStationObject : INotifyOutput
    {
        CommandStation CmdStation { get; set; }
    }
}
