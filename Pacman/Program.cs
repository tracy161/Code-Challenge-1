using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Display();

            PacmanDriver driver = new PacmanDriver(new Pacman());

            while (true)
            {
                string command = PromtForCommand();
                if (command.ToUpper() == "QUIT") 
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(driver.Command(command));
            }
        }

        private static void Display()
        {
            Console.WriteLine("Pacman Simulator");
            Console.WriteLine("----------------");
            Console.WriteLine("This is a simulation of Pacman moving on a grid table");
            Console.WriteLine("");
        }

        private static string PromtForCommand()
        {
            Console.WriteLine("Please Enter your Input: ");
            return Console.ReadLine();
        }
    }
}
