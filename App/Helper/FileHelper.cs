using NJsonSchema;

namespace restsharp_tests_serverest.App.Helper
{
    public class FileHelper
    {
        public JsonSchema GetJsonSchema(string fileName)
        {
            return JsonSchema.FromFileAsync($"../../../App/Data/Schema/{fileName}.json").Result;
        }
    }
}
