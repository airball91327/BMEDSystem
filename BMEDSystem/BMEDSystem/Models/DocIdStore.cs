using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class DocIdStore
    {
        [Key, Column(Order = 1)]
        public string DocType { get; set; }
        [Key, Column(Order = 2)]
        public string DocId { get; set; }
    }
}
