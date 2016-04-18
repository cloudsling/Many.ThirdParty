using Many.ThirdParty.Core.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class EssayModel : IReadingModel
    {
        public override IReadingContent Content { get; set; }
    }

    public class EssayContent : IReadingContent
    {
        public string Content_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Guide_Word { get; set; }

        public AuthorModel Author { get; set; }
    }
}
