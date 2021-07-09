using System;
using System.Collections.Generic;

// Frågor:
// 1. Hur fungerar stacken/heapen?
//    - Stacken är en tillfällig minnes-allokering, där värden i stacken endast är tillgänliga så länge metoden som håller värdena körs,
//      därefter frias det minnet upp. Stacken körs efter en först in först ut metod, där det som ligger över exekveras och sedan frias upp.
//    - Heapen är dynamisk minnes-allokering, där värdena är tillgägnliga så länge applikationen körs. Dessa värden frigörs alltså inte på
//      samma sätt som med stacken, varpå heapen kräver mer minne. Eftersom värdena i stacken även är statiska (programmet vet redan vart 
//      de finns och när de körs) 

// 2. Vad är value types respektive referense types?
//    - De är båda olika typer som lagrar värden - data. Generellt lagras value types i stacken, men kan även förekomma i heapen (då de lagras
//      där de deklareras). De value types som lagras i stacken frigörs i och med det att stacken exekverar koden, och de value types och reference
//      types som lagras på heapen håller sina värden tills de uppdateras eller så länge applikationen körs. 

// 3. Varför genererar metoderna olika svar?
//    - I det första exemplet är det value types som vi hanterar, så i denna kod...
//      
//      x = 3;
//      y = x;
//      y = 4;
//
//      ...är det endast värdet i y som ändras. Detta för att när vi skickar värden mellan olika vaalue types så kopieras värdet från den ena till den
//      andra, men de är fortfarande separata värden. 
//      I det andra exemplet är det referense types som hanteras. När man skickar värden mellan olika referense types så skickar vi istället den första 
//      referense typens adress. De pekar därför på samma låda (i heapen), så när vi nu pillar på de värden som ligger i lådan genom y så kommer vi att
//      se det när vi kommer åt samma låda genom x. De båda pekar på (och manipulerar) samma objekt.




namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Paranthesis"
                    + "\n5. Reverse Text"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        ExamineList();
                        break;
                    case '2':
                        Console.Clear();
                        ExamineQueue();
                        break;
                    case '3':
                        Console.Clear();
                        ExamineStack();
                        break;
                    case '4':
                        Console.Clear();
                        CheckParanthesis();
                        break;
                    case '5':
                        Console.Clear();
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            bool show = true;
            List<string> theList = new List<string>();

            do
            {
                Console.WriteLine("Either add (+) to the list, or remove (-) from the list, or exit (x) the list");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine(theList.Count);
                        Console.WriteLine(theList.Capacity);
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine(theList.Count);
                        Console.WriteLine(theList.Capacity);
                        break;
                    case 'x':
                        Console.Clear();
                        show = false;
                        break;
                    default:
                        Console.WriteLine("Only use + or - to add or remove from the list");
                        break;
                }

            } while (show);

            // Frågor:
            // När ökar listans kapacitet/Med hur mycket?
            //    - När vi uppnår listans nuvarande kapacitet, varpå kapaciteten dubblas och vi får nytt utrymme.
            // Varför ökar inte kapaciteten med elementen som läggs till?
            //    - För att vi lägger till saker i minnet som har blivit allokerat när vi instanserar och börjar lägga
            //      till saker i listan. Det utrymmet förblir detsamma till dess att vi överskrider dess kapacitet. 
            //      Huruvida vi har fyllt 1/4 eller 3/4 av dessa kommer inte att påverka hur mycket minne som redan har.
            //      "lagts undan åt oss".
            // Minskar kapaciteten när elementen tas bort ur listan?
            //    - Nej, då den biten av minnne redan har allokerats åt oss kommer den inte att minska när vi tar bort saker.
            // När är det fördelaktigt med en egendefinierad array?
            //    - När vi vet hur mycket minne vi behöver, för att inte ta upp mer minne än vad som behövs.
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            bool show = true;
            Queue<string> theQueue = new Queue<string>();

            do
            {
                if (theQueue.Count != 0)
                {
                    Console.Clear();
                    Console.WriteLine("Current queue:");
                    foreach (var person in theQueue)
                    {
                        Console.WriteLine(person);
                    }
                }

                Console.WriteLine("Either add (+) to the queue, or remove (-) from the queue, or exit (x) the queue");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        theQueue.Dequeue();
                        break;
                    case 'x':
                        Console.Clear();
                        show = false;
                        break;
                    default:
                        Console.WriteLine("Only use + or - to add or remove from the list");
                        break;
                }

            } while (show);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            bool show = true;
            Stack<string> theStack = new Stack<string>();

            do
            {
                if (theStack.Count != 0)
                {
                    Console.Clear();
                    Console.WriteLine("Current queue:");
                    foreach (var person in theStack)
                    {
                        Console.WriteLine(person);
                    }
                }

                Console.WriteLine("Either add (+) to the queue, or remove (-) from the queue, or exit (x) the queue");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        break;
                    case '-':
                        theStack.Pop();
                        break;
                    case 'x':
                        Console.Clear();
                        show = false;
                        break;
                    default:
                        Console.WriteLine("Only use + or - to add or remove from the list");
                        break;
                }

            } while (show);

            // Varför är det inte så smart att använda en stack i fall som med ICA köer ?
            //    - I fall där vi vill att något som har stått och väntat längst ska köras
            //      är det inte fördelaktigt att implementera en stack, som kör sist in först
            //      ut. I sådana fall blir det första som lagts till i stacken stående länge.
        }

        private static void CheckParanthesis()
        {

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            bool show = true;
            bool isBalanced = true;

            do
            {
                Console.Write("\nAdd the text you want to check: ");

                string input = Console.ReadLine();
                Stack<char> brackets = new Stack<char>();

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                    {
                        brackets.Push(input[i]);
                    }
                    else if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                    {
                        switch (input[i])
                        {
                            case ')':
                                if (brackets.Pop() != '(')
                                {
                                    isBalanced = false;
                                }
                                break;
                            case '}':
                                if (brackets.Pop() != '{')
                                {
                                    isBalanced = false;
                                }
                                break;
                            case ']':
                                if (brackets.Pop() != '[')
                                {
                                    isBalanced = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (isBalanced)
                {
                    Console.WriteLine("Balanced brackets");
                }
                else
                {
                    Console.WriteLine("Unbalanced brackets");
                }

            } while (show);
        }

        static void ReverseText()
        {
            bool show = true;

            do
            {
                Console.Write("\nAdd the text you want to reverse: ");

                Stack<char> stack = new Stack<char>(Console.ReadLine().ToCharArray());

                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop());
                }

            } while (show);

        }

    }
}

