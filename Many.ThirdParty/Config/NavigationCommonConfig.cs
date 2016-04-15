using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Config
{
    internal class NavigationCommonConfig
    {
        internal static readonly List<Scenario> MainScenarios = new List<Scenario>
        {
            new Scenario { PageTitle="ONE", PageType=typeof(HomePage), Index = 0},
            new Scenario { PageTitle="阅读", PageType=typeof(ReadingPage), Index = 1},
            new Scenario { PageTitle="音乐", PageType=typeof(MusicPage), Index = 2},
            new Scenario { PageTitle="电影", PageType=typeof(MoviePage), Index = 3},
            new Scenario { PageType=typeof(MovieDetail), Index = 4},
        };

        internal static readonly Dictionary<string, Scenario> GetScenarioByName = new Dictionary<string, Scenario>
        {
            {typeof(HomePage).Name , MainScenarios[0] },
            {typeof(ReadingPage).Name , MainScenarios[1] },
            {typeof(MusicPage).Name , MainScenarios[2] },
            {typeof(MoviePage).Name , MainScenarios[3] },
            {typeof(MovieDetail).Name , MainScenarios[4] }
        };
    }

    internal class Scenario
    {
        public string PageTitle { get; set; }

        public Type PageType { get; set; }

        public string PageTypeName { get; set; } 

        public int Index { get; set; }
    }
}
