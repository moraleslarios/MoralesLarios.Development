using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Development.Configuration;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {

            string numericString = Config.ConfigNodes.PropNumericForceString;
            string p1 = Config.ConfigNodes.PropertyForceString1;
            string p11 = Config.ConfigNodes.Propertytring1;
            decimal p2 = Config.ConfigNodes.PropertyNumeric1;
            string[] as1 = Config.ConfigNodes.PropertyArrayString1;
            decimal[] ad1 = Config.ConfigNodes.PropertyArrayNumeric;
            DateTime p3 = Config.ConfigNodes.PropertyDate;
            DateTime p4 = Config.ConfigNodes.PropertyDateTime;
            DateTime[] adt1 = Config.ConfigNodes.PropertyArrayDate;
            bool p5 = Config.ConfigNodes.PropertyBool;
            bool[] ab1 = Config.ConfigNodes.PropertyArrayBool;
            string psch = Config.ConfigNodes.PropSaveChararcter;
            string data = Config.ConfigNodes.PropStringSaveComilla;


        }
    }
}
