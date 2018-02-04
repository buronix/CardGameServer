using System;
using System.Collections.Generic;

namespace CG.Server.Common.Exceptions
{
    public static class ExceptionStatus
    {
        public const string NOT_EMPTY_FIELD = "NotEmpty";
        public static Dictionary<Type, int> MapExceptionToStatusCode = new Dictionary<Type, int>
        {
            { typeof(FieldRequiredException), 400 }
        };
    }
}
