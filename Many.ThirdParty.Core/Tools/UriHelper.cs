using System;
using Many.ThirdParty.Core.Enum;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;

namespace Many.ThirdParty.Core.Tools
{
    internal static class UriHelper
    {
        internal static string GetRelatedUri<T>(string id)
        {
            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    return string.Format(ServicesUrl.GetRelatedContent(RelatedContentOption.Question), id);
                case nameof(EssayDetailPageViewModel):
                    return string.Format(ServicesUrl.GetRelatedContent(RelatedContentOption.Essay), id);
                case nameof(SerialDetailPageViewModel):
                    return string.Format(ServicesUrl.GetRelatedContent(RelatedContentOption.Serial), id);
                default:
                    return string.Empty;
            }
        }

        internal static string GetUri<T>(string id) where T : ReadingDetailPageViewModelBase
        {
            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    return string.Format(ServicesUrl.QuestionContent, id, DateTime.Now.ToString("d").Replace("/", "-"));
                case nameof(EssayDetailPageViewModel):
                    return string.Format(ServicesUrl.EssayUpdate, id, "0");
                case nameof(SerialDetailPageViewModel):
                    return string.Format(ServicesUrl.SerialContent, id);
                default:
                    return string.Empty;
            }
        }

        internal static string GetCommentUri<T>(string id)
        {
            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    return string.Format(ServicesUrl.QuestionComment, id, "0");
                case nameof(EssayDetailPageViewModel):
                    return string.Format(ServicesUrl.EssayComment, id, "0");
                case nameof(SerialDetailPageViewModel):
                    return string.Format(ServicesUrl.SerialComment, id, "0");
                default:
                    return string.Empty;
            }
        }
    }
}
