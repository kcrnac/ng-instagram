using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Instagram.Common.ErrorHandling.Models
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            this.Errors = new List<string>();
        }

        public ErrorResponse(int status, string error) : this()
        {
            this.Status = status;
            this.Errors.Add(error);
        }

        public ErrorResponse(int status, List<string> errors) : this()
        {
            this.Status = status;
            this.Errors = errors;
        }

        public int Status { get; set; }

        public List<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver()});
        }
    }
}
