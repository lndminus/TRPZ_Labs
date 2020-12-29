using System;
using System.Security.Cryptography.X509Certificates;

namespace Robot
{
    class Program
    {


        static void Main(string[] args)
        {



        Robot Robot = new Robot();
        Actions Actions = new Actions(Robot);
        ConsoleView ConsoleView = new ConsoleView(Actions);



        }
    
    }
}
