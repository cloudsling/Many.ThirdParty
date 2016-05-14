using Many.ThirdParty.AddlPages;
using Many.ThirdParty.SubPages;
using Many.ThirdParty.SubPages.ReadingDetailPage;
using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.Config
{
    internal class NavigationManager
    {
        private static Frame _generalFrame;

        internal static Frame GeneralFrame
        {
            get { return _generalFrame; }
            set { _generalFrame = value; }
        }

        internal static void GeneralNavigate(Type pageType)
        {
            _generalFrame?.Navigate(pageType);
        }

        internal static void GoBack(Frame frame)
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }

        internal static readonly List<Scenario> MainScenarios = new List<Scenario>
        {
            new Scenario { PageTitle="ONE", PageType=typeof(HomePage), Index = 0},
            new Scenario { PageTitle="阅读", PageType=typeof(ReadingPage), Index = 1},
            new Scenario { PageTitle="音乐", PageType=typeof(MusicPage), Index = 2},
            new Scenario { PageTitle="电影", PageType=typeof(MoviePage), Index = 3},
            new Scenario { PageType=typeof(MovieDetailPage), Index = 4},

            new Scenario {PageTitle="短篇",PageType=typeof(EssayDetailPage), Index= 5 },
            new Scenario {PageTitle="连载",PageType=typeof(SerialDetailPage), Index= 6 },
            new Scenario {PageTitle="问答",PageType=typeof(QuestionDetailPage), Index= 7 },
        };

        internal static readonly Dictionary<string, Scenario> GetScenarioByName = new Dictionary<string, Scenario>
        {
            {typeof(HomePage).Name , MainScenarios[0] },
            {typeof(ReadingPage).Name , MainScenarios[1] },
            {typeof(MusicPage).Name , MainScenarios[2] },
            {typeof(MoviePage).Name , MainScenarios[3] },
            {typeof(MovieDetailPage).Name , MainScenarios[4] },
            {typeof(EssayDetailPage).Name , MainScenarios[5] },
            {typeof(SerialDetailPage).Name , MainScenarios[6] },
            {typeof(QuestionDetailPage).Name , MainScenarios[7] },
        };
    }

    internal class Scenario
    {
        internal string PageTitle { get; set; }

        internal Type PageType { get; set; }

        internal string PageTypeName { get; set; }

        internal int Index { get; set; }
    }
}
