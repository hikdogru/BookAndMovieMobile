using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Json
{
    public class JsonConvertModel
    {
        public JsonSerializerSettings Settings { get; set; }

        public JsonConvertModel(NamingStrategy namingStrategy)
        {
            Settings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = namingStrategy } };
        }

        public T GetContent<T>(string jsonContent)
        {
            var content = JsonConvert.DeserializeObject<T>(jsonContent, Settings);
            return content;
        }
    }
}
