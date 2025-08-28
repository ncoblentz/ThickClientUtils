using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThickClientUtils
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Rule> rules = new List<Rule>();
            rules.Add(new Rule("test1","test2","test3"));
            rules.Add(new Rule("testa", "testb", "testc"));

            string jsonString = JsonSerializer.Serialize(rules);

            Console.WriteLine(jsonString);


            List<Rule> rules2 = JsonSerializer.Deserialize<List<Rule>>(File.ReadAllText("rules.json"));
            */

            /*
             * 
             * Instructions:
             *   Copy \ThickClientUtils\bin\Debug to the folder in which the thick-client resides
             *   Edit rules.json to add you find/replace rules
             *   Use Dnspy/DnspyEx to edit the method you want to inject this code into
             *   Choose Add Library, and select ThickClientUtils.exe
             *   For Modifying Strings:
             *      Add the following C# code:
             *          content = RuleManager.ApplyRules(content);             *               *   
             *      or the following IL code (you will have to adapt the ldloc/stloc with wherever the variable is)
             *          ldloc.0
             *          call	string ThickClientUtils.RuleManager::ApplyRules(string)
             *          stloc.0
             *   For Logging:
             *      Add the folloing C# code:
             *          Logger.Log(content);
             *      or the following IL code (you will have to adapt the ldloc/stloc with wherever the variable is)
             *          ldloc.0
             *          call	void ThickClientUtils.Logger::Log(string)
             */

            string content = "abctest2deftest2123testb456testbasdf";
            Console.WriteLine(content);
            Logger.Log(content);
            content = RuleManager.ApplyRules(content);
            Console.WriteLine(content);
            //Logger.Log(content);

            Console.ReadLine();
        }
    }
}
