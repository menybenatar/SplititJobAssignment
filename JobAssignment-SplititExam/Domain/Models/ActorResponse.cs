﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ActorResponse
    {
        public List<ErrorDetail> Errors { get; set; }
        public int StatusCode { get; set; }
        public string TraceId { get; set; }
        public bool IsSuccess { get; set; }
        public ActorModel Actor { get; set; } // Single ActorModel instead of a list

        public ActorResponse()
        {
            Errors = new List<ErrorDetail>();
        }
    }
}
