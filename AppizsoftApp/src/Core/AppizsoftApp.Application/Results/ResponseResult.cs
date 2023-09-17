﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Results
{
    public class ResponseResult<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
