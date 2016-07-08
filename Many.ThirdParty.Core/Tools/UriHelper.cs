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
            RelatedContentOption action;
            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    {
                        action = RelatedContentOption.Question;
                        break;
                    }
                case nameof(EssayDetailPageViewModel):
                    {
                        action = RelatedContentOption.Essay;
                        break;
                    }
                case nameof(SerialDetailPageViewModel):
                    {
                        action = RelatedContentOption.Serial;
                        break;
                    }
                default:
                    {
                        action = RelatedContentOption.Question;
                        break;
                    }
            }
            return string.Format(ServicesUrl.GetRelatedContent(action), id);
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
            string uri;
            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    {
                        uri = ServicesUrl.QuestionComment;
                        break;
                    }
                case nameof(EssayDetailPageViewModel):
                    {
                        uri = ServicesUrl.EssayComment;
                        break;
                    }
                case nameof(SerialDetailPageViewModel):
                    {
                        uri = ServicesUrl.SerialComment;
                        break;
                    }
                default:
                    {
                        uri = ServicesUrl.SerialComment;
                        break;
                    }
            }
            return string.Format(uri, id, "0");
        }
    }
}
