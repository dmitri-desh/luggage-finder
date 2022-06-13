using System;

namespace BLL.Services.Models
{
    public abstract class StandardResultObject
    {
        public bool Success { get; set; }
        public string UserMessage { get; set; }
        internal string InternalMessage { get; set; }
        internal Exception Exception { get; set; }
        public StandardResultObject()
        {
            Success = false;
            UserMessage = string.Empty;
            InternalMessage = string.Empty;
            Exception = null;
        }
 
    }
}
