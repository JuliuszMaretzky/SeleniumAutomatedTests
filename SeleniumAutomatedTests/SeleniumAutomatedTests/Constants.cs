using System.Collections.Generic;

namespace SeleniumAutomatedTests
{
    public static class Constants
    {
        public static Dictionary<string, string> LanguageCode = new Dictionary<string, string>()
        {
            ["Chinese"] = "cn",
            ["English"] = "en",
            ["Esperanto"] = "eo",
            ["Finnish"] = "fi",
            ["Greek"] = "el",
            ["German"] = "de",
            ["Japanese"] = "ja",
            ["Polish"] = "pl"
        };

        public static Dictionary<string, string> LanguageInPolish = new Dictionary<string, string>()
        {
            ["Chinese"] = "chiński",
            ["English"] = "angielski",
            ["Esperanto"] = "esperanto",
            ["Finnish"] = "fiński",
            ["Greek"] = "grecki",
            ["German"] = "niemiecki",
            ["Japanese"] = "japoński",
            ["Polish"] = "polski"
        };
    }
}
