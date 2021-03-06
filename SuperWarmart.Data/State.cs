﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperWarmart.Data
{
    [DataContract]

    public class State
    {
        [Key]
        [DataMember]
        public int StateId { get; set; }
        [Required]
        [DataMember]
        public string StateName { get; set; }
        [Required]
        [DataMember]
        public string Abbr { get; set; }
    }
}
