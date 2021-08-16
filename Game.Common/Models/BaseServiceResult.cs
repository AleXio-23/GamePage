using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Common.Models
{
    public class BaseServiceResult<T>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }


        [JsonProperty(PropertyName = "errorOccured")]
        public bool ErrorOccured { get; set; }


        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }


        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        public BaseServiceResult()
        {

        }

        public BaseServiceResult(T data)
        {
            Success = true;
            Data = data;
            ErrorOccured = false;
        }

        public static BaseServiceResult<T> SucceededBase(T data)
        {
            return new BaseServiceResult<T>
            {
                ErrorOccured = false,
                Success = true,
                Data = data
            };
        }

        public static BaseServiceResult<T> ErrorBase(string message, string id)
        {
            return new BaseServiceResult<T>
            {
                ErrorOccured = true,
                Success = false,
                Id = id,
                ErrorMessage = message
            };
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, CamelCase);
        }

        public static JsonSerializerSettings CamelCase => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
