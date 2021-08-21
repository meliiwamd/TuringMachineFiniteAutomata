using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class State
    {
        //For Regular Languages And PushDown Automata 
        public int NumberOfState;
        public bool Final;
        public List<Tuple<State, List<char>>> NearBy = new List<Tuple<State, List<char>>>();

        //For Turing Machine
        public List<Tuple<State, char, char, char>> TuringMachine = new List<Tuple<State, char, char, char>>();
        //Shows Where The Head Is (Which Index In Our String)

        public State(int Number) => NumberOfState = Number;
    }
}
