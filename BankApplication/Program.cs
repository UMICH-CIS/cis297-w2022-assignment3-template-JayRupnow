using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{

    class Account
    {
        private double ballance = 100000;

        public double bal
        {
            get { return ballance; }
            set { ballance = value; }
        }

        public string name;
        public double account, final_Amt;
        public double withdraw, dep, tobal;

        public void credit()
        {
            //Console.WriteLine("account balance is: " + ballance);

            Console.WriteLine("Please enter your account name: "); //asking for the name of the person using the account
            name = Console.ReadLine();
            Console.WriteLine("Enter your account number: ");//asking user for account number
            account = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the ammount you would like to deposit: ");
            dep = Convert.ToDouble(Console.ReadLine());
            tobal = bal + dep;

            Console.WriteLine("\n*********************\n");
            Console.WriteLine("Name of the depositor: " + name);
            Console.WriteLine("Account Number is: " + account);
            Console.WriteLine("Total Balance is: " + tobal);

        }

        public void debit()
        {
            Console.WriteLine("Please enter the account name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the account number: ");
            account = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the ammount of money you would like to WithDraw: ");
            withdraw = Convert.ToInt32(Console.ReadLine());

            if (withdraw <= bal)
            {
                tobal = bal - withdraw;
                Console.WriteLine("\n*********************\n");
                Console.WriteLine("Account name: " + name);
                Console.WriteLine("Account number: " + account);
                Console.WriteLine("Ammount in account after withdraw: " + tobal);
            }
            else
            {
                Console.WriteLine("\n*********************\n");
                Console.WriteLine("Error: Not enough money in your account.");
            }

        }

        class Saving_Accopunt : Account
        {
            double intrest_rate, rate;

            public void calintrest()
            {

                if (dep == 0)
                {
                    Console.WriteLine("No intrest was added account balance is:" + tobal);
                }
                else
                {
                    intrest_rate = 0.02;

                    //math for intrest rate calc
                    rate = tobal * (intrest_rate / 100);
                    final_Amt = tobal + rate;

                    Console.WriteLine("Total balance with intrest: " + final_Amt);
                }
            }

        }

        class Checkings_Account : Saving_Accopunt
        {
            double fee_per = 15;

            public void fee()
            {
               
                if(withdraw == 0 || withdraw > tobal)
                {
                    Console.WriteLine("No fee was taken.");
                }
                else
                {
                    Console.WriteLine("Balance after Tracsaction charges: " + (tobal - fee_per));

                }                
            }
        }

        class program
        {
            static void Main(string[] args)
            {
                char agn;

                do
                {
                    Checkings_Account i = new Checkings_Account();
                    int num;
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("\n1) For credit ammount\n2) For to withdraw");
                    num = Convert.ToInt32(Console.ReadLine());

                    switch (num)
                    {
                        case 1:
                            i.credit();
                            i.calintrest();
                            break;
                        case 2:
                            i.debit();
                            i.fee();
                            break;
                            default:
                            Console.WriteLine("Invalid Selection!");
                            break;        
                    }
                    Console.WriteLine("\nWould you like to continue? (y/n)\n");
                    agn = Convert.ToChar(Console.ReadLine());


                } while (agn == 'y');
                Console.ReadKey();
            }

        }
    }
}
