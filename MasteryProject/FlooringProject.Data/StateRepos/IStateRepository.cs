using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;

namespace FlooringProject.Data
{
    public interface IStateRepository
    {

        List<State> GetAllStates();

        State GetStatebyNameorAbbr(string state);
    }
}
