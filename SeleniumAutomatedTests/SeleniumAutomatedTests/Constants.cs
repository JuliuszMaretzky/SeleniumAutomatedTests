using System.Collections.Generic;

namespace SeleniumAutomatedTests
{
    public static class Constants
    {
        public static Dictionary<string, string> LanguageCode = new Dictionary<string, string>()
        {
            ["English"] = "en",
            ["Esperanto"] = "eo",
            ["Finnish"] = "fi",
            ["Greek"] = "el",
            ["German"] = "de",
            ["Polish"] = "pl"
        };

        public static Dictionary<string, string> LanguageInPolish = new Dictionary<string, string>()
        {
            ["English"] = "angielski",
            ["Esperanto"] = "esperanto",
            ["Finnish"] = "fiński",
            ["Greek"] = "grecki",
            ["German"] = "niemiecki",
            ["Polish"] = "polski"
        };
    }
}
