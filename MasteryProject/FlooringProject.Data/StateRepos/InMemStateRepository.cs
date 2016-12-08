using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;

namespace FlooringProject.Data
{
    public class InMemStateRepository : IStateRepository
    {
        private static List<State> _states;

        public InMemStateRepository()
        {
            _states = new List<State>()
            {
                new State()
                {
                    StateAbbr = "OH",
                    StateName = "OHIO",
                    TaxRate = 8.00m

                },
                new State()
                {
                    StateAbbr = "NY",
                    StateName = "NEW YORK",
                    TaxRate = 9.00m
                },
                new State()
                {
                    StateAbbr = "NC",
                    StateName = "NORTH CAROLINA",
                    TaxRate = 5.00m

                }

            };
        }

        public List<State> GetAllStates()
        {
            return _states;
        }

        public State GetStatebyNameorAbbr(string state)
        {
            return _states.FirstOrDefault(a => (a.StateAbbr == state) || (a.StateName == state));
        }
    }
}
