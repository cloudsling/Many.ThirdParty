using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Models.CommonModels
{
    public class User
    {
        public string User_Id { get; set; }

        public string User_Name { get; set; }


        public string _web_Url;
        public string Web_Url
        {
            get { return _web_Url ?? ""; }
            set { _web_Url = value; }
        }

    }
}
