using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Game.Common.Models
{
    [Serializable]
    public class ServiceResult<T> : BaseServiceResult<T>
    {
        [JsonProperty(PropertyName = "warnMessage")]
        public List<KeyValuePair<string, string>> WatnMessage { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        [JsonProperty(PropertyName = "failedMessage")]
        public List<KeyValuePair<string, string>> FailedMessage { get; set; }

        public ServiceResult() : base()
        {

        }

        public ServiceResult(T data) : base(data)
        {

        }

        public static ServiceResult<T> Succeeded(T data)
        {
            return new ServiceResult<T>
            {
                ErrorOccured = false,
                Success = true,
                Data = data
            };
        }

        public static ServiceResult<T> Error(string message, string id)
        {
            return new ServiceResult<T>
            {
                ErrorOccured = true,
                Success = false,
                Id = id,
                ErrorMessage = message
            };
        }

        public static ServiceResult<T> Warning(T data, List<KeyValuePair<string, string>> messages)
        {
            return new ServiceResult<T>
            {
                ErrorOccured = false,
                Success = true,
                WatnMessage = messages,
                Data = data
            };
        }

        public static ServiceResult<T> Failed(T data, List<KeyValuePair<string, string>> messages)
        {
            return new ServiceResult<T>
            {
                ErrorOccured = false,
                Success = false,
                WatnMessage = messages,
                Data = data
            };
        }

        public static ServiceResult<T> Result(HttpResponseMessage result)
        {
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var serviceResult = JsonConvert.DeserializeObject<ServiceResult<T>>(result.Content.ReadAsStringAsync().Result);
                if (serviceResult.ErrorOccured)
                {
                    throw new Exception($"address: {result.RequestMessage.RequestUri}, method {result.RequestMessage.Method} Error: {serviceResult.ErrorMessage}");
                }
                return serviceResult;
            }
            throw new Exception($"address: {result.RequestMessage.RequestUri}, method {result.RequestMessage.Method} Error: {result.ReasonPhrase}");

        }
    }
}
