using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuSign
{
    /// <summary>
    /// Business layer to validate the command entered and perform business validations
    /// </summary>
    class BusinessLayer
    {
        Dictionary<int, bool> processedDict = new Dictionary<int, bool>(); //dictinary to hold the processed items
        public String ValidateBusinessRules(Temperature temp, List<int> commands)
        {
            String res = null;
            bool doExit = false;
            //•	Pajamas must be taken off before anything else can be put on
            if (commands[0] != 8)
                return "fail";
            foreach (var i in commands)
            {
                if (!isValidBusinessRule(temp, i))
                    return res + ", fail";
                res += HandleCommands(temp, i,ref doExit);
                if (doExit == true) return res;
                processedDict[i] = true;
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool isValidBusinessRule(Temperature temp, int cmd)
        {
            //•	Socks must be put on before shoes and •	Pants must be put on before shoes
            if ((cmd == 3 || cmd == 6) && processedDict.ContainsKey(1))
                return false;
            //The shirt must be put on before the headwear or jacket
            if (cmd == 4 && (processedDict.ContainsKey(2) || processedDict.ContainsKey(5)))
                return false;
            //•	You cannot leave the house until all items of clothing are on (except socks and a jacket when it’s hot)
            if (cmd == 7 && ((temp == Temperature.HOT && processedDict.Count() != 5) || (temp == Temperature.COLD && processedDict.Count() != 7)))
                return false;
            //•	Only 1 piece of each type of clothing may be put on
            if (processedDict.ContainsKey(cmd))
                return false;
            return true;
        }

        /// <summary>
        /// Handle the different commands to calculate the output
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="cmd"></param>
        /// <param name="doExit"></param>
        /// <returns></returns>
        public String HandleCommands(Temperature temp, int cmd, ref bool doExit)
        {
            switch (cmd)
            {
                case 1:
                    return temp == Temperature.HOT ? ", sandals" : ", boots";
                case 2:
                    return temp == Temperature.HOT ? ", sun visor" : ", hat";
                case 3:
                    return temp == Temperature.HOT ? ", fail" : ", socks";
                case 4:
                    return temp == Temperature.HOT ? ", t-shirt" : ", shirt";
                case 5:
                    if (temp == Temperature.HOT)
                    {
                        doExit = true;
                        return ", fail";
                    }
                    else
                        return ", jacket";                   
                case 6:
                    return temp == Temperature.HOT ? ", shorts" : ", pants";
                case 7:
                    return temp == Temperature.HOT ? ", leaving house" : ", leaving house";
                case 8:
                    return temp == Temperature.HOT ? "Removing PJs" : "Removing PJs";
                default:
                    doExit = true;
                    return ", fail";
            }
        }
    }
}
