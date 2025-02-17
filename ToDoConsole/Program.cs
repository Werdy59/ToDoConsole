using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Element> elements = new List<Element> { };

            Console.WriteLine("enter a command to start (the max number of element is 10 for now) : ");
            string input = Console.ReadLine().ToLower().Trim();

            var command = input.Split(' ');

            if (command[0] == "/set" && command[1] == "-name")
            {
                elements.Add(new Element(command[2]));
                Console.WriteLine("a new Element was correctly added");
            }
            else if (command[0] == "/set" && command[1] == "-finish")
            {
                if (command[2] == "true")
                {
                    Console.Write("choose what element : ");
                    int selectedElement = 0;
                    foreach (var element in elements)
                    {
                        if (element == elements[0])
                        {
                            Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted() + "<<");
                        }
                        Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted());
                    }
                    var key = Console.ReadKey();
                    while (!key.Equals(ConsoleKey.Enter))
                    {
                        if (key.Equals(ConsoleKey.UpArrow))
                        {
                            if (selectedElement != 0)
                            {
                                selectedElement--;
                                ClearLastLines(elements.Count() + 1);
                                Console.Write("choose what element : ");
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    if (i == selectedElement)
                                    {
                                        Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted() + " <<");
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted());
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < elements.Count; i++)
                                {
                                    Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted());
                                }
                            }
                        }
                    }
                }
            }

            while (input != "/quit")
            {
                input = Console.ReadLine().ToLower().Trim();
                command = input.Split(' ');

                if (command[0] == "/quit")
                {
                    break;
                }

                if (command[0] == "/set" && command[1] == "-name")
                {
                    elements.Add(new Element(command[2]));
                    Console.WriteLine("a new Element was correctly added");
                }
                else if (command[0] == "/set" && command[1] == "-finish")
                {
                    if (command[2] == "true")
                    {
                        Console.Write("choose what element : ");
                        int selectedElement = 0;
                        foreach (var element in elements)
                        {
                            if (element == elements[0])
                            {
                                Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted() + "<<");
                            }
                            Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted());
                        }
                        var key = Console.ReadKey();
                        while (!key.Equals(ConsoleKey.Enter))
                        {
                            if (key.Equals(ConsoleKey.UpArrow))
                            {
                                if (selectedElement != 0)
                                {
                                    selectedElement--;
                                    ClearLastLines(elements.Count() + 1);
                                    Console.Write("choose what element : ");
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        if (i == selectedElement)
                                        {
                                            Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted() + " <<");
                                        }
                                        else
                                        {
                                            Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted());
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        Console.WriteLine(elements[i].GetName() + "is Finished : " + elements[i].GetIsCompleted());
                                    }
                                }
                            }
                            else if (key.Equals(ConsoleKey.DownArrow))
                            {
                                if (selectedElement != 0)
                                {
                                    selectedElement++;
                                    ClearLastLines(elements.Count() + 1);
                                    Console.Write("choose what element : ");
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        if (i == selectedElement)
                                        {
                                            Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted() + " <<");
                                        }
                                        else
                                        {
                                            Console.WriteLine(elements[i].GetName() + " is Finished : " + elements[i].GetIsCompleted());
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < elements.Count; i++)
                                    {
                                        Console.WriteLine(elements[i].GetName() + "is Finished : " + elements[i].GetIsCompleted());
                                    }
                                }
                            }
                            else if (key.Equals(ConsoleKey.Enter))
                            {
                                Console.WriteLine("entree presser");
                            }
                        }
                    }
                }
            }
        }
        static void ClearLastLines(int numberOfLines)
        {
            int currentLine = Console.CursorTop;
            int startLine = currentLine - numberOfLines;

            for (int i = 0; i < numberOfLines; i++)
            {
                Console.SetCursorPosition(0, startLine + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, startLine);
        }
    }
}
