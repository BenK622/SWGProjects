using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using System.IO;

namespace FlooringProject.Data
{
    public class FileStateRepository : IStateRepository
    {
        private const string FILENAME = @"DataFiles\StateData.txt";

        public List<State> GetAllStates()
        {
            List<State> states = new List<State>();

            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";

                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    State state = new State()
                    {
                        StateAbbr = inputParts[0],
                        StateName = inputParts[1],
                        TaxRate = decimal.Parse(inputParts[2])

                    };

                   states.Add(state);
                }

            }

            return states;
        
           }

        public State GetStatebyNameorAbbr(string stateString)
        {
            State state = new State();

            var stateList = GetAllStates();

             state = stateList.FirstOrDefault(a => (a.StateAbbr == stateString) || (a.StateName == stateString));

            return state;
        }
    }
}
