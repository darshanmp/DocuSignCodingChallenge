using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author : darshan masti prakash
/// Code for DocuSign test
/// </summary>
namespace DocuSign
{
    /// <summary>
    /// Temperature enum to store hot and cold types
    /// </summary>
    enum Temperature { HOT, COLD};  

    /// <summary>
    /// Main class which accepts the user input from Console window
    /// </summary>
    public class PajamasProblem
    {
        BusinessLayer businessLay = null;
        public PajamasProblem()
        {
            businessLay = new BusinessLayer();
        }
        // Accept the user input by passing the input command and reference variable doExit to stop processing of next commands 
        public string AcceptUserInput(string input,ref bool doExit)
        {
            try
            {                
                Temperature temp = Temperature.HOT;
                List<string> cmdLst = input.Split(' ').ToList();
                //Extract the temperature from the input
                if (cmdLst[0].ToUpper().Contains("HOT"))
                    temp = Temperature.HOT;
                else if (cmdLst[0].ToUpper().Contains("COLD"))
                    temp = Temperature.COLD;

                //invalid input
                else
                {
                    Console.WriteLine("fail");
                    doExit = true;
                    return "";
                }
                //Get the command numbers
                cmdLst.Remove(cmdLst[0]); 
                cmdLst = cmdLst.Select(k => k.Replace(',', ' ')).Select(i => i.TrimEnd()).ToList(); //remove the spaces and commas from input
                return businessLay.ValidateBusinessRules(temp, cmdLst.Select(int.Parse).ToList()); //validate the input and calculate the input
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error occured in AcceptUserInput");
                throw ex;
            }
        }
        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                bool doExit = false;
                PajamasProblem pajamas = new PajamasProblem();
                do
                {
                    //String input = "COLD 8, 6, 3, 4, 2, 5, 1, 7";
                    Console.WriteLine("Enter the command");
                    String input = Console.ReadLine();
                    Console.WriteLine(pajamas.AcceptUserInput(input,ref doExit));
                    Console.WriteLine("Do you want to continue with entering commands: Y / N");
                    doExit = Console.ReadLine().ToUpper() == "Y" ? false: true;                    
                } while (!doExit);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
