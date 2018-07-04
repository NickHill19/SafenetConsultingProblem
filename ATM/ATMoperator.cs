using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    class ATMoperator
    {
        static void Main(string[] args)
        {
            string input = "input";
            char command = 'a';
            ATM atm = new ATM();
            Console.WriteLine("Welcome to the ATM.");           
                Console.WriteLine("Options:");
                Console.WriteLine("1. Withdraw - Press W plus amount in the form 'W $x'");
                Console.WriteLine("2. Display Balance: Press I followed by the bills that you wish to check in the format I $x $y $z");
                Console.WriteLine("3. Restock the machine: Press R");
                Console.WriteLine("4. Quit: Press Q");

            do
            {
                input = Console.ReadLine();

                try
                {
                    command = input[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error: Invalid command");
                    continue;
                }

                if (command.Equals('W') || command.Equals('I') || command.Equals('R') || command.Equals('Q'))
                {
                    switch (command)
                    {
                        case 'W':
                            string temp = input.Substring(input.IndexOf("$") + 1);
                            int amt = 0;
                            try
                            {
                                amt = int.Parse(temp);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error: Invalid command");
                                break;
                            }
                            bool success = atm.Withdraw(amt);
                            if (success)
                            {
                                Console.WriteLine("Success: Dispensed " + "$" + amt);
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: Insufficient Funds");
                                Console.WriteLine();
                            }
                            break;

                        case 'I':
                            int i = 0;
                            List<string> sDenominations = new List<string>();
                            StringBuilder d = new StringBuilder();
                            string s = "";
                            for (i = 0; i < input.Length; i++)
                            {
                                if (char.IsNumber(input[i]))
                                {
                                    d.Append(input[i]);
                                }
                                if (input[i] == ' ')
                                {
                                    s = d.ToString();
                                    sDenominations.Add(s);
                                    d = new StringBuilder();
                                }
                            }
                            s = d.ToString();
                            sDenominations.Add(s);
                            List<int> bills = new List<int>();
                            for (i = 1; i < sDenominations.Count(); i++)
                            {
                                try
                                {
                                    bills.Add(int.Parse(sDenominations[i]));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error: Invalid command");
                                }
                            }
                            atm.Denominations(bills);
                            break;

                        case 'R':
                            atm.Restock();
                            Console.WriteLine("Restocked Machine");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Error: Invalid command");
                    Console.WriteLine();
                }
            }
            while (command != 'Q');
            Console.WriteLine("Thank you for using the ATM. Press any key to exit.");
            Console.ReadKey();
        }
    }
}

