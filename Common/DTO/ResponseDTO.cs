using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }
    }
}
