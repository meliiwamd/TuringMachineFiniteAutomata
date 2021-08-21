using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //We Have 5 Languages
            //We Need 5 Different Algorithm
            //To Choose Which Language You Want Enter A Number Between 1 - 5

            //Which One
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Which Language Do You Want To Pick To Test A String On It?\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "1) {w | w E {a, b, c}* , Len(w) % 2 == 0}\n" +
                "2) {w | w E {a, b, c}* , Na(w) - Nb(w) % 3 == 1}\n" +
                "3) {wCw^R | w E {a, b}*}\n" +
                "4) {a^n b^(n + m) a ^m | m, n >= 1}\n" +
                "5) {ww | w E {a, b, c}*}\n"
                );
            

            string TryMore = "";

            do 
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Language Number : ");
                int SelectWhichLanguage = int.Parse(Console.ReadLine());

                //Enter Correct Number
                while (SelectWhichLanguage > 5 || SelectWhichLanguage < 1)
                {
                    Console.WriteLine("Entered Number Was Not In Range\nTry Again");
                    SelectWhichLanguage = int.Parse(Console.ReadLine());
                }
              
                //Enter Your String Which You Want To Check If Is Accepted Or Not
              
                switch (SelectWhichLanguage)
                        {
                            case 1:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Well!\nYou Have Choosed Language : {w | w E {a, b, c}* , Len(w) % 2 == 0}");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Now Enter A String That You Want To See Is Accepted By This Language Or Not");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string StringToCheck = Console.ReadLine();
                                    CheckFirstLanguage(StringToCheck);
                                }
                                break;
                            case 2:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Well!\nYou Have Choosed Language : {w | w E {a, b, c}* , Na(w) - Nb(w) % 3 == 1}");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Now Enter A String That You Want To See Is Accepted By This Language Or Not");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string StringToCheck = Console.ReadLine();
                                    CheckSecondLanguage(StringToCheck);
                                }
                                break;
                            case 3:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Well!\nYou Have Choosed Language : {wCw^R | w E {a, b}*}");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Now Enter A String That You Want To See Is Accepted By This Language Or Not");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string StringToCheck = Console.ReadLine();
                                    CheckThirdLanguage(StringToCheck);
                                }
                                break;
                            case 4:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Well!\nYou Have Choosed Language : {a^n b^(n + m) a ^m | m, n >= 1}");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Now Enter A String That You Want To See Is Accepted By This Language Or Not");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string StringToCheck = Console.ReadLine();
                                    CheckForthLanguage(StringToCheck);
                                }
                                break;
                            case 5:
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Well!\nYou Have Choosed Language : {ww | w E {a, b, c}*}");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("Now Enter A String That You Want To See Is Accepted By This Language Or Not");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string StringToCheck = Console.ReadLine();
                                    CheckFifthLanguage(StringToCheck);
                                }
                                break;
                        }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Try More ?\n");
                TryMore = Console.ReadLine();
                    
            } 
            while (TryMore == "yes") ;

            Console.WriteLine("Thank You For Your Attension");

            Console.ReadKey();

        }

        
        public static void CheckFirstLanguage(string stringToCheck)
        {
            
            //Characters
            char[] Characters = new char[3] { 'a', 'b', 'c' };

            //Graph
            State[] States = new State[2];
            for (int i = 0; i < States.Length; i++)
                States[i] = new State(i);
            //Make Graph
            States[0].Final = true;

            States[0].NearBy.Add(Tuple.Create(States[1], new List<char> { 'a', 'b', 'c' }));
            States[1].NearBy.Add(Tuple.Create(States[0], new List<char> { 'a', 'b', 'c' }));


            //Path
            string PathIfAccepted = "";
            
            //Current State
            State CurrentState = new State(0);
            CurrentState = States[0];

            //Path
            PathIfAccepted += "Q0 -> ";

            //Tuple To Check
            Tuple<State, bool> Temp = new Tuple<State, bool>(CurrentState, true);
            bool OutOfAlphabet = false;
            for(int i = 0; i < stringToCheck.Length; i++)
            {
                

                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfAlphabet = true;
                    break;
                }
                else
                    CurrentState = Temp.Item1;
                //Path 
                PathIfAccepted += $"Q{CurrentState.NumberOfState} -> ";
            }

            if (!CurrentState.Final || OutOfAlphabet)
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This String Is Not Accepted Because It Is Not In Final State!");
            }
            else
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nAccepted!");
                Console.WriteLine(PathIfAccepted.Substring(0, PathIfAccepted.Length - 3));
            }

        }

        public static void CheckSecondLanguage(string stringToCheck)
        {
            //Characters
            char[] Characters = new char[3] { 'a', 'b', 'c' };

            //Path
            string PathIfAccepted = "";
            PathIfAccepted += "Q0 -> ";

            //Graph
            State[] States = new State[3];
            for (int i = 0; i < States.Length; i++)
                States[i] = new State(i);
            //Make Graph
            States[1].Final = true;

            States[0].NearBy.Add(Tuple.Create(States[0], new List<char> { 'c' }));
            States[0].NearBy.Add(Tuple.Create(States[1], new List<char> { 'a' }));
            States[0].NearBy.Add(Tuple.Create(States[2], new List<char> { 'b' }));
            States[1].NearBy.Add(Tuple.Create(States[0], new List<char> { 'b' }));
            States[1].NearBy.Add(Tuple.Create(States[1], new List<char> { 'c' }));
            States[1].NearBy.Add(Tuple.Create(States[2], new List<char> { 'a' }));
            States[2].NearBy.Add(Tuple.Create(States[0], new List<char> { 'a' }));
            States[2].NearBy.Add(Tuple.Create(States[1], new List<char> { 'b' }));
            States[2].NearBy.Add(Tuple.Create(States[2], new List<char> { 'c' }));

            //Current State
            State CurrentState = new State(0);
            CurrentState = States[0];

            //Tuple To Check
            Tuple<State, bool> Temp = new Tuple<State, bool>(CurrentState, true);
            bool OutOfAlphabet = false;
            for (int i = 0; i < stringToCheck.Length; i++)
            {


                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfAlphabet = true;
                    break;
                }
                else
                    CurrentState = Temp.Item1;
                //Path 
                PathIfAccepted += $"Q{CurrentState.NumberOfState} -> ";
            }

            if (!CurrentState.Final || OutOfAlphabet)
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This String Is Not Accepted Because It Is Not In Final State!");
            }
            else
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("\nAccepted!");
                Console.WriteLine(PathIfAccepted.Substring(0, PathIfAccepted.Length - 3));
            }



        }

        public static void CheckThirdLanguage(string stringToCheck)
        {
            //This Is PushDown Automata

            stringToCheck += '$';
            //Characters
            char[] Characters = new char[2] { 'a', 'b' };

            //Stach
            Stack<char> MyStack = new Stack<char>();
            //Q0 -> Q1
            MyStack.Push('$');  

            //Graph
            State[] States = new State[4];
            for (int i = 0; i < States.Length; i++)
                States[i] = new State(i);
            //Make Graph
            States[3].Final = true;
            States[0].NearBy.Add(Tuple.Create(States[1], new List<char> { ' ' }));
            States[1].NearBy.Add(Tuple.Create(States[1], new List<char> { 'a', 'b' }));
            States[1].NearBy.Add(Tuple.Create(States[2], new List<char> { 'C', 'c' }));
            States[2].NearBy.Add(Tuple.Create(States[2], new List<char> { 'a', 'b' }));
            States[2].NearBy.Add(Tuple.Create(States[3], new List<char> { '$' }));


            //Path
            string PathIfAccepted = "";
            PathIfAccepted += "Q0";

            //Stack Content
            string StackContent = "";
            StackContent += "\n$ \n";

            //Current State 
            State CurrentState = new State(0);
            CurrentState = States[1];

            //Temp Tuple
            Tuple<State, bool> Temp = new Tuple<State, bool>(CurrentState, true);
            bool OutOfAlphabet = false;
            int Index = 0;

            for(int i = 0; i < stringToCheck.Length; i++)
            {
                PathIfAccepted += $" -> Q{CurrentState.NumberOfState}";
                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfAlphabet = true;
                    break;
                }
                else
                    CurrentState = Temp.Item1;

                

                if (stringToCheck[i] != 'C' && stringToCheck[i] != 'c')
                {
                    MyStack.Push(stringToCheck[i]);
                    for (int j = MyStack.Count - 1; j >= 0; j--)
                        StackContent += $"{MyStack.ElementAt(j)}, ";
                    StackContent = StackContent.TrimEnd(new char[2] { ' ', ',' });
                    StackContent += '\n';
                    Index++;
                }
                else
                    break;

            }

            PathIfAccepted += " -> Q2";

            for(int i = Index + 1; i < stringToCheck.Length; i++)
            {
                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfAlphabet = true;
                    break;
                }
                else
                {
                    CurrentState = Temp.Item1;
                    if (MyStack.Pop() != stringToCheck[i])
                    {
                        OutOfAlphabet = true;
                        break;
                    }
                    
                }
                for (int j = MyStack.Count - 1; j >= 0; j--)
                    StackContent += $"{MyStack.ElementAt(j)}, ";
                StackContent = StackContent.TrimEnd(new char[2] { ' ', ',' });
                StackContent += '\n';
                PathIfAccepted += $" -> Q{CurrentState.NumberOfState}";
            }

            if (!CurrentState.Final || OutOfAlphabet)
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This String Is Not Accepted Because It Is Not In Final State!");
            }
            else
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nAccepted!");
                Console.WriteLine(PathIfAccepted);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\nStack In Each Step : {StackContent}");
            }
        }

        public static void CheckForthLanguage(string stringToCheck)
        {
            //This Is PushDown Automata


            stringToCheck += "$";
            //Characters
            char[] Characters = new char[2] { 'a', 'b' };

            //Stack
            Stack<char> MyStack = new Stack<char>();
            MyStack.Push('$');
            MyStack.Push('$');

            //Graph
            State[] States = new State[7];
            for (int i = 0; i < States.Length; i++)
                States[i] = new State(i);
            //Make Graph
            States[6].Final = true;

            States[0].NearBy.Add(Tuple.Create(States[1], new List<char> { ' ' }));
            States[1].NearBy.Add(Tuple.Create(States[2], new List<char> { 'a' }));
            States[2].NearBy.Add(Tuple.Create(States[2], new List<char> { 'a' }));
            States[2].NearBy.Add(Tuple.Create(States[3], new List<char> { 'b' }));
            States[3].NearBy.Add(Tuple.Create(States[3], new List<char> { 'b' }));
            States[3].NearBy.Add(Tuple.Create(States[4], new List<char> { 'b' }));
            States[4].NearBy.Add(Tuple.Create(States[4], new List<char> { 'b' }));
            States[4].NearBy.Add(Tuple.Create(States[5], new List<char> { 'a' }));
            States[5].NearBy.Add(Tuple.Create(States[5], new List<char> { 'a' }));
            States[5].NearBy.Add(Tuple.Create(States[6], new List<char> { '$' }));

            //Path 
            string PathIfAccepted = "";
            PathIfAccepted += "Q0 -> Q1";

            //Stack Content
            string StackContent = "";
            StackContent += "\n$, $\n";

            //Current State
            State CurrentState = new State(0);
            CurrentState = States[1];

            //Temp Tuple And Boolean And Index
            Tuple<State, bool> Temp = new Tuple<State, bool>(CurrentState, true);
            bool OutOfTransition = false;
            int Index = 0;


            for (int i = 0; i < stringToCheck.Length; i++)
            {
                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfTransition = true;
                    break;
                }
                else
                    CurrentState = Temp.Item1;
                if (stringToCheck[i] != 'b')
                {
                    MyStack.Push('b');
                    for (int j = MyStack.Count - 1; j >= 0; j--)
                        StackContent += $"{MyStack.ElementAt(j)}, ";
                    StackContent = StackContent.TrimEnd(new char[2] { ',', ' ' });
                    StackContent += '\n';
                }
                else
                {
                    Index = i;
                    break;
                }

                PathIfAccepted += $" -> Q{CurrentState.NumberOfState}";
            }

            MyStack.Pop();
            for (int j = MyStack.Count - 1; j >= 0; j--)
                StackContent += $"{MyStack.ElementAt(j)}, ";
            StackContent = StackContent.TrimEnd(new char[2] { ',', ' ' });
            StackContent += '\n';

            for (int i = Index + 1; i < stringToCheck.Length; i++)
            {
                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if(!Temp.Item2)
                {
                    OutOfTransition = true;
                    break;
                }
                else
                {
                    CurrentState = Temp.Item1;
                    char TempChar = MyStack.Pop();

                    
                    for (int j = MyStack.Count - 1; j >= 0; j--)
                        StackContent += $"{MyStack.ElementAt(j)}, ";
                    StackContent = StackContent.TrimEnd(new char[2] { ',', ' ' });
                    StackContent += '\n';

                    if (TempChar != '$' && TempChar != stringToCheck[i])
                    {
                        OutOfTransition = true;
                        break;
                    }
                    else if (TempChar == '$')
                    {
                        //We Don't Need This To Write $\n
                        StackContent = StackContent.Remove(StackContent.Length - 2);
                        
                        Index = i;
                        //Stack Content : $, a
                        MyStack.Push('a');
                        //Change State From Q3 -> Q4
                        CurrentState = States[4];
                        PathIfAccepted += " -> Q3 -> Q4";
                        for (int j = MyStack.Count - 1; j >= 0; j--)
                            StackContent += $"{MyStack.ElementAt(j)}, ";
                        StackContent = StackContent.TrimEnd(new char[2] { ',', ' ' });
                        StackContent += '\n';
                        break;
                    }
                    

                }
              
                PathIfAccepted += $" -> Q{CurrentState.NumberOfState}";
            }

            
            for (int i = Index + 1; i < stringToCheck.Length; i++)
            {
                Temp = TransitionIncludeChar(CurrentState, stringToCheck[i]);
                if (!Temp.Item2)
                {
                    OutOfTransition = true;
                    break;
                }
                else
                {
                    CurrentState = Temp.Item1;
                    if (stringToCheck[i] == 'a')
                    {
                        if (MyStack.Pop() != stringToCheck[i])
                        {
                            OutOfTransition = true;
                            break;
                        }
                    }
                    if(stringToCheck[i] == 'b')
                        MyStack.Push('a');
                    if (stringToCheck[i] == '$')
                        break;
                       
                    for (int j = MyStack.Count - 1; j >= 0; j--)
                        StackContent += $"{MyStack.ElementAt(j)}, ";
                    StackContent = StackContent.TrimEnd(new char[2] { ',', ' ' });
                    StackContent += '\n';

                }

                PathIfAccepted += $" -> Q{CurrentState.NumberOfState}";
            }
            if (!CurrentState.Final || OutOfTransition)
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This String Is Not Accepted Because It Is Not In Final State!");
            }
            else
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nAccepted!");
                Console.WriteLine(PathIfAccepted);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\nStack In Each Step : {StackContent.TrimEnd(new char[1] {'\n'})}");
            }
        }

        public static void CheckFifthLanguage(string stringToCheck)
        {
            //Result
            string Result = "";
            //Turing Machine
            string MainString = '$' + stringToCheck + '$';

            //Characters 
            char[] Characters = new char[3] { 'a', 'b', 'c' };

            //Graph
            State[] States = new State[11];
            for (int i = 0; i < States.Length; i++)
                States[i] = new State(i);

            //Final State
            States[10].Final = true;
            //Make Graph
            //Transitions
            MakeTransitionsForTuringMachine(States);

            //Path For States
            string PathIfAccepted = "Q0 -> ";
            //Tape 
            string Tape = MainString;

            //String For Final Tape To Show In outPut
            string TapeFinal = $"\n{Tape} Head : 1";

            //Current State
            State CurrentState = new State(0);
            CurrentState = States[0];

            //bool Out Of Transition
            bool Fail = false;

            //Head Of The Tape
            int Head = 1;

            //Temp Tuple
            Tuple<State, bool, char, char> Temp = new Tuple<State, bool, char, char>(CurrentState, false, ' ', ' ');

            while(!Fail && !CurrentState.Final)
            {
                Temp = TransitionForTuring(CurrentState, Tape[Head]);
                if(!Temp.Item2)
                {
                    Fail = true;
                    break;
                }
                else
                {
                    string Temproray = "";
                    //Change Tape
                    //Write In It
                    for(int i = 0; i < Tape.Length; i++)
                    {
                        if (i != Head)
                            Temproray += Tape[i];
                        else
                            Temproray += Temp.Item3;
                    }
                    Tape = Temproray;
                    if (Temp.Item4 == 'R')
                        Head++;
                    else
                        Head--;
                    CurrentState = Temp.Item1;
                }
                TapeFinal += $"\n{Tape} Head : {Head}";
                PathIfAccepted += $"Q{CurrentState.NumberOfState} -> ";
                Result += TapeFinal + PathIfAccepted;
            }

            if(!CurrentState.Final || Fail)
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This String Is Not Accepted Because It Does'nt Halt In Final State!");
            }
            else
            {
                //Console Color 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nAccepted!");
                Console.WriteLine(PathIfAccepted.Substring(0, PathIfAccepted.Length - 3));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\nTape In Each Step : {TapeFinal}");
            }
        }

        

        public static Tuple<State, bool> TransitionIncludeChar(State state, char Alphabet)
        {
            for (int i = 0; i < state.NearBy.Count; i++)
                if (state.NearBy[i].Item2.Contains(Alphabet))
                    return Tuple.Create(state.NearBy[i].Item1, true);
            return Tuple.Create(state, false);
        }

        public static void MakeTransitionsForTuringMachine(State[] States)
        {
            States[0].TuringMachine.Add(Tuple.Create(States[1], 'a', 'x', 'R'));
            States[0].TuringMachine.Add(Tuple.Create(States[1], 'b', 'y', 'R'));
            States[0].TuringMachine.Add(Tuple.Create(States[1], 'c', 'z', 'R'));
            States[0].TuringMachine.Add(Tuple.Create(States[4], 'x', 'x', 'L'));
            States[0].TuringMachine.Add(Tuple.Create(States[4], 'y', 'y', 'L'));
            States[0].TuringMachine.Add(Tuple.Create(States[4], 'z', 'z', 'L'));

            States[1].TuringMachine.Add(Tuple.Create(States[1], 'a', 'a', 'R'));
            States[1].TuringMachine.Add(Tuple.Create(States[1], 'b', 'b', 'R'));
            States[1].TuringMachine.Add(Tuple.Create(States[1], 'c', 'c', 'R'));
            States[1].TuringMachine.Add(Tuple.Create(States[2], 'z', 'z', 'L'));
            States[1].TuringMachine.Add(Tuple.Create(States[2], 'y', 'y', 'L'));
            States[1].TuringMachine.Add(Tuple.Create(States[2], 'x', 'x', 'L'));
            States[1].TuringMachine.Add(Tuple.Create(States[2], '$', '$', 'L'));

            States[2].TuringMachine.Add(Tuple.Create(States[3], 'a', 'x', 'L'));
            States[2].TuringMachine.Add(Tuple.Create(States[3], 'b', 'y', 'L'));
            States[2].TuringMachine.Add(Tuple.Create(States[3], 'c', 'z', 'L'));

            States[3].TuringMachine.Add(Tuple.Create(States[3], 'a', 'a', 'L'));
            States[3].TuringMachine.Add(Tuple.Create(States[3], 'b', 'b', 'L'));
            States[3].TuringMachine.Add(Tuple.Create(States[3], 'c', 'c', 'L'));
            States[3].TuringMachine.Add(Tuple.Create(States[0], 'z', 'z', 'R'));
            States[3].TuringMachine.Add(Tuple.Create(States[0], 'y', 'y', 'R'));
            States[3].TuringMachine.Add(Tuple.Create(States[0], 'x', 'x', 'R'));

            States[4].TuringMachine.Add(Tuple.Create(States[4], 'x', 'a', 'L'));
            States[4].TuringMachine.Add(Tuple.Create(States[4], 'y', 'b', 'L'));
            States[4].TuringMachine.Add(Tuple.Create(States[4], 'z', 'c', 'L'));
            States[4].TuringMachine.Add(Tuple.Create(States[5], '$', '$', 'R'));

            States[5].TuringMachine.Add(Tuple.Create(States[10], 'B', 'B', 'L'));
            States[5].TuringMachine.Add(Tuple.Create(States[6], 'a', 'x', 'R'));
            States[5].TuringMachine.Add(Tuple.Create(States[8], 'b', 'y', 'R'));
            States[5].TuringMachine.Add(Tuple.Create(States[9], 'c', 'z', 'R'));

            States[6].TuringMachine.Add(Tuple.Create(States[6], 'a', 'a', 'R'));
            States[6].TuringMachine.Add(Tuple.Create(States[6], 'b', 'b', 'R'));
            States[6].TuringMachine.Add(Tuple.Create(States[6], 'c', 'c', 'R'));
            States[6].TuringMachine.Add(Tuple.Create(States[6], 'B', 'B', 'R'));
            States[6].TuringMachine.Add(Tuple.Create(States[7], 'x', 'B', 'L'));

            States[7].TuringMachine.Add(Tuple.Create(States[5], 'x', 'x', 'R'));
            States[7].TuringMachine.Add(Tuple.Create(States[5], 'y', 'y', 'R'));
            States[7].TuringMachine.Add(Tuple.Create(States[5], 'z', 'z', 'R'));
            States[7].TuringMachine.Add(Tuple.Create(States[7], 'a', 'a', 'L'));
            States[7].TuringMachine.Add(Tuple.Create(States[7], 'b', 'b', 'L'));
            States[7].TuringMachine.Add(Tuple.Create(States[7], 'c', 'c', 'L'));
            States[7].TuringMachine.Add(Tuple.Create(States[7], 'B', 'B', 'L'));

            States[8].TuringMachine.Add(Tuple.Create(States[8], 'a', 'a', 'R'));
            States[8].TuringMachine.Add(Tuple.Create(States[8], 'b', 'b', 'R'));
            States[8].TuringMachine.Add(Tuple.Create(States[8], 'c', 'c', 'R'));
            States[8].TuringMachine.Add(Tuple.Create(States[8], 'B', 'B', 'R'));
            States[8].TuringMachine.Add(Tuple.Create(States[7], 'y', 'B', 'L'));

            States[9].TuringMachine.Add(Tuple.Create(States[9], 'a', 'a', 'R'));
            States[9].TuringMachine.Add(Tuple.Create(States[9], 'b', 'b', 'R'));
            States[9].TuringMachine.Add(Tuple.Create(States[9], 'c', 'c', 'R'));
            States[9].TuringMachine.Add(Tuple.Create(States[9], 'B', 'B', 'R'));
            States[9].TuringMachine.Add(Tuple.Create(States[7], 'z', 'B', 'L'));
        }

        public static Tuple<State, bool, char, char> TransitionForTuring(State state, char Alphabet)
        {
            for (int i = 0; i < state.TuringMachine.Count; i++)
                if (state.TuringMachine[i].Item2 == Alphabet)
                    return Tuple.Create(state.TuringMachine[i].Item1, true, state.TuringMachine[i].Item3, state.TuringMachine[i].Item4);
            return Tuple.Create(state, false, ' ', ' ');
        }
    }
}
