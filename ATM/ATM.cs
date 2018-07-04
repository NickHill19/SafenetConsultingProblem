using System;
using System.Collections.Generic;

namespace ATM
{
    class ATM
    {
        private int hu;
        private int ff;
        private int tw;
        private int te;
        private int fv;
        private int on;

        public ATM()
        {
            hu = 10;
            ff = 10;
            tw = 10;
            te = 10;
            fv = 10;
            on = 10;
        }
        


        public void Restock()
        {
            hu = 10;
            ff = 10;
            tw = 10;
            te = 10;
            fv = 10;
            on = 10;
        }
        public Boolean Withdraw(int amt)
        {
            int balance = (hu * 100) + (ff * 50) + (tw * 20) + (te * 10) + (fv * 5) + (on * 1);
            if (balance >= amt)
                
            {
                int disphu = amt / 100;
                int dispff = (amt % 100) / 50;
                int disptw = ((amt % 100) % 50) / 20;
                int dispte = (((amt % 100) % 50) % 20) / 10;
                int dispfv = ((((amt % 100) % 50) % 20) % 10) / 5;
                int dispon = ((((amt % 100) % 50) % 20) % 10) % 5;
                hu -= disphu;
                ff -= dispff;
                tw -= disptw;
                te -= dispte;
                fv -= dispfv;
                on -= dispon; 

                return true;
            }
            return false;
        }

        public void Denominations(List<int> bills)
        {

            int i = 0;
            for (i = 0; i < bills.Count; i++)
            {
                if (bills[i] == 1)
                {
                    Console.WriteLine("$1 - " + on);
                }

                if (bills[i] == 5)
                {
                    Console.WriteLine("$5 - " + fv);
                }

                if (bills[i] == 10)
                {
                    Console.WriteLine("$10 - " + te);
                }

                if (bills[i] == 20)
                {
                    Console.WriteLine("$20: " + tw);
                }

                if (bills[i] == 50)
                {
                    Console.WriteLine("$50: " + ff);
                }

                if (bills[i] == 100)
                {
                    Console.WriteLine("$100: " + hu);                   
                }
            }
        }
    }
}
