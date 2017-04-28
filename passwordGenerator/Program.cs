using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    class Program
    {
        //method to create a password.
        static char[] Generateassword()
        {
            //a string that holds all possible chars.
            string passwordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$%&";

            //empty finalPassword  char array.
            char[] finalPassword = { };

            Console.WriteLine("Please, enter the length of password between 8 to 15");
            
            //parse user's input-- if valid then reqiureLen will be set and return true else false.
            bool flag = int.TryParse(Console.ReadLine(), out int requireLen);

            //test if flag is true or false.
            if (flag)
            {
                //test for reqiureLen between 8 and 15.
                if (requireLen >= 8 && requireLen <= 15)
                {
                    //initialise the finalPassword array with specific length.
                    finalPassword = new char[requireLen];

                    //create an random object.
                    Random ranObj = new Random();

                    //loop to get random num and assign a random char from passwordChars.
                    for (int i = 0; i < requireLen; i++)
                    {
                        //gettin a random number between 0 to passwordChar's length.
                        int randomNum = ranObj.Next(0,passwordChars.Length);
                        //try to set specific element of passwordChars to finalPassword array.
                        try
                        {
                            finalPassword[i] = passwordChars.ElementAt(randomNum);
                        }
                        //catch if any exception there like indexOutOfRange.
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                //else case if length is not between 8 to 15.
                else
                {
                    Console.WriteLine("Please enter a number between 8 and 15 only.");
                }
            }
            //else case if user enter other than numbers.
            else
            {
                Console.WriteLine("Please, enter number only.");
            }
            //return finalPassword array.
            return finalPassword;
        }
        static void Main(string[] args)
        {
            //method call and assign returned array to pass array.
            char[] pass = Generateassword();
            
            //output the pass array to console window.
            Console.WriteLine(pass);
        }
    }
}
