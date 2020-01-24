using System;
using System.Collections.Generic;

namespace _14_Phonebook
{
    class Program
    {
        enum Position { Beginning, End, Specific, Default }
        enum UpdateType { Position, Name, Phone }
        enum StatusType { Selection, NewEntry, Move, Switch, Remove }
        enum ErrorType { Invalid, Empty, TooLarge, OutOfRange, NonConvertible, Canceled }
        enum HelpText { Menu, Position }
        static void Main(string[] args)
        {
            List<int> phone = new List<int>(100);
            List<string> name = new List<string>(100);
            List<int> phoneNew = new List<int>(100);
            List<string> nameNew = new List<string>(100);



            Console.WriteLine("Welcome to McMosquito's Phonebook");
            Console.Write("Would you like to load testing phonebook? (Y/N) ");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine();
                DefaultPhonebook(out phone, out name);
            }
            else Console.WriteLine("\n// LOAD SKIPPED //\n");

            Console.WriteLine("Press <ENTER> for help");
            Console.WriteLine("Press <ESC> to exit the program\n");

            // Functions to be added in future: SEARCH, SORT, LOAD, SAVE

            while (true)
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) break;
                switch (key)
                {
                    case ConsoleKey.Divide:
                    case ConsoleKey.Oem4: // the "ú /" key - CZ keyboard
                    case ConsoleKey.Oem2: // the "/ ?" key - EN keyboard
                        PhonebookAction(Console.ReadLine().Trim().ToLower(),
                                        phone, name, out phoneNew, out nameNew);
                        break;
                    case ConsoleKey.OemPeriod:
                        SystemAction(Console.ReadLine().Trim().ToLower(),
                                     phone, name, out phoneNew, out nameNew);
                        break;
                    case ConsoleKey.Enter:
                        Help(HelpText.Menu);
                        break;
                    default:
                        PrintStatus(ErrorType.Invalid);
                        break;
                }

                if (phone != phoneNew || name != nameNew)
                {
                    phone = phoneNew;
                    name = nameNew;
                }
            }
            // Console.Write("Would you like to save the phonebook? (Y/N) ");
        }

        static void Help(in HelpText help)
        {
            switch (help)
            {
                case HelpText.Menu:
                    Console.WriteLine("\nAll available commands:\n\n" +
                                      " /NEW - add a new entry\n" +
                                      " /MOVE - move an entry to diferent position\n" +
                                      " /SWITCH - switch two entries\n" +
                                      " /REMOVE - remove an entry\n" +
                                      " /UPDATE - update the selected name or phone number\n"/* +
                                      " /SEARCH - search for an entry using the name or the phone number\n" +
                                      " /SORT - sorts alphabetically all entries in the phonebook\n"*/ +
                                      " .PRINT - print out the phonebook\n" +
                                      " .CLEAR - clear out all the data from the phonebook\n"/* +
                                      " .LOAD - load the phonebook from a file\n" +
                                      " .SAVE - save the phonebook to a file\n"*/ +
                                      " .TEST - overwrite the current phonebook by the testing one\n");
                    break;
                case HelpText.Position:
                    Console.WriteLine("\n B - beginning of the list\n" +
                                      " E - end of the list (default)\n" +
                                      " S - specific position in the list");
                    break;
                default:
                    break;
            }
                
        }

        static void SystemAction(string action, List<int> phoneIn, List<string> nameIn,
                                 out List<int> phoneOut, out List<string> nameOut)
        {
            phoneOut = phoneIn;
            nameOut = nameIn;
            switch (action)
            {
                case "print":
                    PrintOut(phoneIn, nameIn);
                    break;
                case "clear":
                    phoneOut = new List<int>(100);
                    nameOut = new List<string>(100);
                    Console.WriteLine("// PHONEBOOK CLEARED //");
                    break;
                case "test":
                    DefaultPhonebook(out phoneOut, out nameOut);
                    break;
                default:
                    PrintStatus(ErrorType.Invalid);
                    break;
            }
        }

        static void PhonebookAction(string action, List<int> phoneIn, List<string> nameIn,
                                    out List<int> phoneOut, out List<string> nameOut)
        {
            switch (action)
            {
                case "new":
                    AddEntry(phoneIn, nameIn, out phoneOut, out nameOut, out int pos);
                    break;
                case "move":
                    MoveEntry(phoneIn, nameIn, out phoneOut, out nameOut, out int posOld, out int posNew);
                    break;
                case "switch":
                    SwitchEntry(phoneIn, nameIn, out phoneOut, out nameOut, out posOld, out posNew);
                    PrintStatus(posOld, posNew, phoneOut[posOld], nameOut[posOld], StatusType.Switch);
                    break;
                case "remove":
                    RemoveEntry(phoneIn, nameIn, out phoneOut, out nameOut, out pos);
                    break;
                case "update":
                    phoneOut = phoneIn;
                    nameOut = nameIn;
                    break;/*
                case "search":
                    phoneOut = phoneIn;
                    nameOut = nameIn;
                    break;
                case "sort":
                    phoneOut = phoneIn;
                    nameOut = nameIn;
                    break;*/
                default:
                    phoneOut = phoneIn;
                    nameOut = nameIn;
                    PrintStatus(ErrorType.Invalid);
                    break;
            }
        }

        static void DefaultPhonebook(out List<int> phones, out List<string> names)
        {
            phones = new List<int>(100) { 777500861, 732661984, 605009995, 606803863, 777574537 };
            names = new List<string>(100) { "Me", "Mom", "Dad", "Grandpa", "Boss" };

            Console.WriteLine("\n// TESTING PHONEBOOK LOADED //\n");
        }
        static void PrintOut(List<int> phone, List<string> name)
        {
            if (phone.Count != 0 || name.Count != 0)
            {
                for (int i = 0; i < phone.Count; i++)
                {
                    Console.WriteLine($"{i + 1:00}: {phone[i]:000 000 000} | {name[i]}");
                }
            }
            else PrintStatus(ErrorType.Empty);
            Console.WriteLine();
        }

        static void PrintStatus(int position, int phone, string name, in StatusType type)
        {
            switch (type)
            {
                case StatusType.Selection:
                    Console.WriteLine($"// {position + 1:00}: {phone:000 000 000} | {name.ToUpper()} SELECTED //");
                    break;
                case StatusType.NewEntry:
                    Console.WriteLine($"// \"{phone:000 000 000} | {name.ToUpper()}\" HAS BEEN ADDED " +
                                      $"TO POSITION {position + 1:00} //");
                    break;
                case StatusType.Remove:
                    Console.WriteLine($"// \"{phone:000 000 000} | {name.ToUpper()}\" HAS BEEN REMOVED //");
                    break;
                default:
                    break;
            }
        }
        static void PrintStatus(int positionOld, int positionNew, int phone, string name, in StatusType type)
        {
            switch (type)
            {
                case StatusType.Move:
                    Console.WriteLine($"// \"{phone:000 000 000} | {name.ToUpper()}\" " +
                                      $"HAS BEEN MOVED FROM POSITION {positionOld + 1:00} " +
                                      $"TO POSITION {positionNew + 1:00} //");
                    break;
                case StatusType.Switch:
                    Console.WriteLine($"// \"{positionOld + 1:00}: {phone:000 000 000} | {name.ToUpper()}\" " +
                                      $"HAS BEEN SWITCHED WITH POSITION {positionNew + 1:00} //");
                    break;
                default:
                    break;
            }
        }
        static void PrintStatus(in ErrorType type)
        {
            switch (type)
            {
                case ErrorType.Invalid:
                    Console.WriteLine("\n// INVALID ACTION //");
                    break;
                case ErrorType.Empty:
                    Console.WriteLine("// NO ENTRIES //");
                    break;
                case ErrorType.TooLarge:
                    Console.WriteLine("// INPUT IS TOO LONG //");
                    break;
                case ErrorType.NonConvertible:
                    Console.WriteLine("// CANNOT BE CONVERTED TO A NUMBER //");
                    break;
                case ErrorType.OutOfRange:
                    Console.WriteLine("// INPUT IS OUT OF SPECIFIED RANGE //");
                    break;
                case ErrorType.Canceled:
                    Console.WriteLine("// ACTION CANCELED //");
                    break;
                default:
                    break;
            }
        }

        static string GetName(string promptText)
        {
            Console.Write($"Please specify the name that should be {promptText}: ");
            string name = Console.ReadLine();
            return name;
        }

        static int GetPhone(string promptText)
        {
            bool err = false;
            int phone = 0;
            Console.Write($"Please specify the phone number that should be {promptText} (max 9-digits): ");
            string input = Console.ReadLine().Replace(" ", "").Replace("-", "");
            if (input.Length > 9)
            {
                PrintStatus(ErrorType.TooLarge);
                err = true;
            }
            else
            {
                try
                {
                    phone = Convert.ToInt32(input);
                }
                catch (Exception)
                {
                    PrintStatus(ErrorType.NonConvertible);
                    err = true;
                }
            }
            if (err == true) phone = GetPhone(promptText);
            return phone;

/* #MISI
            string input = "";
            int number = 0;
            do
            {
                Console.Write("Please specify the phone number that should be " + reason + " (max 9-digits): ");
                input = Console.ReadLine();
            } while (!checkPhoneNumber(input, out number));
            return number;
        }

            static bool checkPhoneNumber(string input, out int number)
        {
            input.Replace(" ", "").Replace("-", "");
            number = 0;

            if (input.Length >= 10)
            {
                Console.WriteLine("Input is too long");
                return false;
            }
            //check other errors

            return Int32.TryParse(input, out number);*/
        }

        static int GetPosition(int maxPosition, string promptText)
        {
            bool err = false;
            int position = 0;
            Console.Write($"\n{promptText} (01-{maxPosition:00}): ");
            string input = Console.ReadLine().Trim();
            
            try
            {
                position = Convert.ToInt32(input)-1;
            }
            catch (Exception)
            {
                PrintStatus(ErrorType.NonConvertible);
                err = true;
            }

            if (position < 0 || position > maxPosition)
            {
                PrintStatus(ErrorType.OutOfRange);
                err = true;
            }
            if (err == true) position = GetPosition(maxPosition, promptText);
            return position;
        }
        static void SpecifyPosition(out Position position)
        {
            Console.Write("Please specify the insert point for the entry (press <ENTER> for help): ");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    Help(HelpText.Position);
                    SpecifyPosition(out position);
                    break;
                case ConsoleKey.B:
                    position = Position.Beginning;
                    break;
                case ConsoleKey.S:
                    position = Position.Specific;
                    break;
                case ConsoleKey.E:
                    position = Position.End;
                    break;
                default:
                    position = Position.Default;
                    break;
            }
            Console.WriteLine();
        }
        static void AddEntry(List<int> phoneIn, List<string> nameIn,
                             out List<int> phoneOut, out List<string> nameOut, out int listPosition)
        {
            phoneOut = phoneIn;
            nameOut = nameIn;
            //listPosition = 0;
            string name = GetName("added");
            int phone = GetPhone("added");
            SpecifyPosition(out Position position);
            switch (position)
            {
                case Position.Beginning:
                    listPosition = 0;
                    phoneOut.Insert(listPosition, phone);
                    nameOut.Insert(listPosition, name);
                    break;
                case Position.Specific:
                    listPosition = GetPosition(phoneIn.Count, "Please specify the position");
                    phoneOut.Insert(listPosition, phone);
                    nameOut.Insert(listPosition, name);
                    break;
                case Position.End:
                case Position.Default:
                default:
                    phoneOut.Add(phone);
                    nameOut.Add(name);
                    listPosition = phoneOut.Count-1;
                    break;
            }
            PrintStatus(listPosition, phoneOut[listPosition], nameOut[listPosition], StatusType.NewEntry);
        }

        static void RemoveEntry(List<int> phoneIn, List<string> nameIn,
                             out List<int> phoneOut, out List<string> nameOut, out int listPosition)
        {
            phoneOut = phoneIn;
            nameOut = nameIn;
            listPosition = GetPosition(phoneIn.Count, "Please specify the number of entry that should be removed");
            PrintStatus(listPosition, phoneIn[listPosition], nameIn[listPosition], StatusType.Remove);
            phoneOut.RemoveAt(listPosition);
            nameOut.RemoveAt(listPosition);
        }

        static void MoveEntry(List<int> phoneIn, List<string> nameIn,
                             out List<int> phoneOut, out List<string> nameOut,
                             out int positionOld, out int positionNew)
        {
            positionOld = GetPosition(phoneIn.Count, "Please select the entry that should be moved");
            //positionNew = 0;
            PrintStatus(positionOld, phoneIn[positionOld], nameIn[positionOld], StatusType.Selection);
            SpecifyPosition(out Position position);
            switch (position)
            {
                case Position.Beginning:
                    positionNew = 0;
                    break;
                case Position.Specific:
                    positionNew = GetPosition(phoneIn.Count, "Please specify where to move the entry");
                    break;
                case Position.End:
                    positionNew = phoneIn.Count - 1;
                    break;
                case Position.Default:
                default:
                    positionNew = positionOld;
                    PrintStatus(ErrorType.Canceled);
                    break;
            }

            phoneOut = phoneIn;
            nameOut = nameIn;

            if (positionOld == positionNew) PrintStatus(ErrorType.Canceled);
            else if (position != Position.Default)
            {
                phoneOut.RemoveAt(positionOld);
                phoneOut.Insert(positionNew, phoneIn[positionOld]);
                nameOut.RemoveAt(positionOld);
                nameOut.Insert(positionNew, nameIn[positionOld]);

                PrintStatus(positionOld, positionNew, phoneOut[positionNew],
                            nameOut[positionNew], StatusType.Move);
            }
        }
        static void SwitchEntry(List<int> phoneIn, List<string> nameIn,
                             out List<int> phoneOut, out List<string> nameOut,
                             out int position1, out int position2)
        {
            position1 = GetPosition(phoneIn.Count, "Please specify first entry that should be switched");
            position2 = GetPosition(phoneIn.Count, "Please specify second entry that should be switched");
            PrintStatus(position1, phoneIn[position1], nameIn[position1], StatusType.Selection);
            PrintStatus(position2, phoneIn[position2], nameIn[position2], StatusType.Selection);

            phoneOut = phoneIn;
            nameOut = nameIn;

            if (position1 == position2) PrintStatus(ErrorType.Canceled);
            else
            {
                if (position1 > position2)
                {
                    phoneOut.RemoveAt(position2);
                    phoneOut.RemoveAt(position1);
                    phoneOut.Insert(position1, phoneIn[position2]);
                    phoneOut.Insert(position2, phoneIn[position1]);
                    nameOut.RemoveAt(position2);
                    nameOut.RemoveAt(position1);
                    nameOut.Insert(position1, nameIn[position2]);
                    nameOut.Insert(position2, nameIn[position1]);
                }
                else
                {
                    phoneOut.RemoveAt(position1);
                    phoneOut.RemoveAt(position2);
                    phoneOut.Insert(position2, phoneIn[position1]);
                    phoneOut.Insert(position1, phoneIn[position2]);
                    nameOut.RemoveAt(position1);
                    nameOut.RemoveAt(position2);
                    nameOut.Insert(position2, nameIn[position1]);
                    nameOut.Insert(position1, nameIn[position2]);
                }
                PrintStatus(position1, position2, phoneOut[position2],
                            nameOut[position2], StatusType.Switch);
            }
        }
    }
}
