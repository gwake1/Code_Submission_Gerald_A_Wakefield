using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Facade;
using System;

namespace Code_Submission_Gerald_A_Wakefield
{
    class Program
    {
        static void Main(string[] args)
        {
            // Loads Unity DI Container and Registers Types
            Bootstrapper.Init();

            // Instantiates Facade with Services to calculate the desired sum of 2 inputs to Max value configured in App.Config
            var facade = new CoFactorFacade();

            // Simple loop that prompts User 2 times to input a value
            bool continueWith = true;
            do
            {
                Console.WriteLine("Please Submit a Numeric Value");
                continueWith = facade.Load(Console.ReadLine());
            } while (continueWith);

            // Log to console sum of input values
            Console.WriteLine(String.Format("The value is : {0}", facade.Calculate()));
            Console.ReadKey();
        }
    }
}
