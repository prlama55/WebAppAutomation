using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace WebAppAutomation.Utilities
{
    class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
        public static List<string> ToArray(Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                var text = row[0];
                list.Add(text);
            }
            return list;
        }

    }
}
