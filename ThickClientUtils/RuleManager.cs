using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ThickClientUtils
{
    public static class RuleManager
    {

        public static List<Rule> UpdateRules()
        {
            return JsonSerializer.Deserialize<List<Rule>>(File.ReadAllText("rules.json"));

        }

        public static string ApplyRules(string content)
        {
            Logger.Log("Before: "+content, 3);
            List<Rule> rules = UpdateRules();
            

            foreach (Rule rule in rules)
            {
                content = Regex.Replace(content, rule.FindRegex, rule.ReplaceString);
            }

            Logger.Log("After: " + content, 3);

            return content;
        }
    }
}
