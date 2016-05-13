using Many.ThirdParty.Core.Models.ReadingModels;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Factories
{
    internal static class ReadingModelFactory
    {
        internal static ReadingModelBase CreateReadingModel(int type, JsonObject json)
        {
            switch (type)
            {
                case 1:
                    return new EssayModel(type, json);
                case 2:
                    return new SerialModel(type, json);
                case 3:
                    return new QuestionModel(type, json);
                default:
                    return null;
            }
        }
    }
}
