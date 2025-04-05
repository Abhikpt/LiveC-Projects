using DataDrivenFramework.Framework;
using Newtonsoft.Json.Linq;

namespace DataDrivenFramework.Utilities
{
    public class JsonReader 
    {

      private string _path;
      private string _startupPath = Environment.CurrentDirectory;
      private string JsonPath;
        public JsonReader(String path)
        {
           _path = path;
          JsonPath = _startupPath.Replace("bin\\Debug\\net8.0", _path); 
        }

         
        public string extractData(String tokenName)
        {
          
          String myJsonString = File.ReadAllText(JsonPath);

           var jsonObject = JToken.Parse(myJsonString);
           return jsonObject.SelectToken(tokenName).Value<string>();

        }

        public string[] extractDataArray(String tokenName)
        {
          String myJsonString = File.ReadAllText(JsonPath);

          var jsonObject = JToken.Parse(myJsonString);
          List<String> productsList=   jsonObject.SelectTokens(tokenName).Values<string>().ToList();
          return productsList.ToArray();

        }
    }
}
