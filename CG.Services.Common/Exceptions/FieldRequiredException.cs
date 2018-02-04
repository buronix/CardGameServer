using ServiceStack;
using ServiceStack.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CG.Server.Common.Exceptions
{
    [DataContract]
    public class FieldRequiredException : Exception, IResponseStatusConvertible
    {
        public string FieldName { get; set; }

        public FieldRequiredException(string message, string fieldName, Exception innerException = null) : base (message, innerException)
        {
            FieldName = fieldName;
        }

        public ResponseStatus ToResponseStatus()
        {
            return new ResponseStatus
            {
                ErrorCode = GetType().Name,
                Message = $"Field {FieldName} is Required",
                Errors = new List<ResponseError> {
                    new ResponseError {
                        ErrorCode = ExceptionStatus.NOT_EMPTY_FIELD,
                        FieldName = FieldName,
                        Message = Message
                    }
                }
            };
        }
    }
}
