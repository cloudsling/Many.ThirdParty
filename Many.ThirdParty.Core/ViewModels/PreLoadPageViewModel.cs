using Many.ThirdParty.Core.Models.HomeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Many.ThirdParty.Core.ViewModels
{
    public class PreLoadPageViewModel
    {
        public PreLoadPageViewModel()
        {
            TodayHomePageModel = new HomeModel()
            {
                Author="虐猫狂人薛定谔",
                ImageUrl="ms-appx:///Resources/test.jpg",
                MainContent="ba la ba la bal ablalba",
                Title="VOL.1313",
                Day="12",
                YearAndMonth="2016-4"
            }; 
        }

        public HomeModel TodayHomePageModel { get; set; }
    }
}
