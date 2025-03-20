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

            if (command[0] == "/set" && (command[1] == "-name" || command[1] == "-n"))
            {
                String task = "";
                for (int i = 0; i < command.Length; i++)
                {
                    if (i > 1 && i < command.Length - 1)
                    {
                        task += command[i] + " ";
                    }
                    if (i == command.Length - 1)
                    {
                        task += command[i];
                    }
                }
                elements.Add(new Element(task + ","));
                Console.WriteLine("a new Element was correctly added");
            }
            else if (command[0] == "/set" && command[1] == "-finish")
            {
                if (command[2] == "true")
                {
                    Console.Write("choose what element : \n");
                    int selectedElement = 0;
                    foreach (var element in elements)
                    {
                        if (element == elements[0])
                        {
                            Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted() + " <<");
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
                                if (selectedElement < 0)
                                {
                                    selectedElement++;
                                }
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
            else if (command[0] == "/list" && command[1] == "*")
            {
                foreach (var element in elements)
                {
                    Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
                }
            }
            else if (command[0] == "/list" && command[1] == "true")
            {
                foreach (var element in elements)
                {
                    if (element.GetIsCompleted() == "true")
                    {
                        Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
                    }  
                }
            }
            else if (command[0] == "/list" && command[1] == "false")
            {
                foreach (var element in elements)
                {
                    if (element.GetIsCompleted() == "false")
                    {
                        Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
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

                if (command[0] == "/set" && (command[1] == "-name" || command[1] == "-n"))
                {
                    String task = "";
                    for(int i = 0; i < command.Length; i++)
                    {
                        if (i > 1 && i < command.Length - 1)
                        {
                            task += command[i] + " ";
                        }
                        if (i == command.Length - 1)
                        {
                            task += command[i];
                        }
                    }
                    elements.Add(new Element(task + ","));
                    Console.WriteLine("a new Element was correctly added");
                }
                else if (command[0] == "/set" && command[1] == "-finish")
                {
                    if (command[2] == "true")
                    {
                        Console.Write("choose what element : \n");
                        int selectedElement = 0;
                        foreach (var element in elements)
                        {
                            if (element == elements[0])
                            {
                                Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted() + " <<");
                                continue;
                            }
                            Console.WriteLine(element.GetName() + " is Finished : " + element.GetIsCompleted());
                        }
                        var key = Console.ReadKey();
                        while (key.Key != ConsoleKey.Enter)
                        {
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.UpArrow)
                            {
                                selectedElement--;
                                if (selectedElement < 0)
                                {
                                    selectedElement++;
                                }
                                ClearLastLines(elements.Count() + 1);
                                Console.Write("choose what element : \n");
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
                            else if (key.Key == ConsoleKey.DownArrow)
                            {
                                selectedElement++;
                                if (selectedElement > elements.Count - 1)
                                {
                                    selectedElement--;
                                }
                                ClearLastLines(elements.Count() + 1);
                                Console.Write("choose what element : \n");
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
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                elements[selectedElement].SetIsCompleted();
                                Console.WriteLine($"element {elements[selectedElement].GetName()} was correctly set to true");
                            }
                        }  
                    }
                }
                else if (command[0].ToLower() == "/list" && command[1].ToLower() == "*")
                {
                    foreach (var element in elements)
                    {
                        Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
                    }
                }
                else if (command[0].ToLower() == "/list" && command[1].ToLower() == "true")
                {
                    foreach (var element in elements)
                    {
                        if (element.GetIsCompleted() == "True")
                        {
                            Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
                        }
                    }
                }
                else if (command[0].ToLower() == "/list" && command[1].ToLower() == "false")
                {
                    foreach (var element in elements)
                    {
                        if (element.GetIsCompleted() == "False")
                        {
                            Console.WriteLine(element.GetName() + " is finish : " + element.GetIsCompleted());
                        }
                    }
                }
            }
            Console.WriteLine();
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
