using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Instagram.Business.Model.ServiceResult
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            Errors = new List<ValidationError>();
        }

        public T Result { get; set; }

        public List<ValidationError> Errors { get; set; }

        public HttpStatusCode? StatusCode { get; set; }

        public bool IsValid => !Errors.Any();
    }
}
