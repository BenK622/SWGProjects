using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IPlayer
    {
        string playerName { get; set; }
        string playerType{ get; }

        Choice GetChoice();

    }
}
