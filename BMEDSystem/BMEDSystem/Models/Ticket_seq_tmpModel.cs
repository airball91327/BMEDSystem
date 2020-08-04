using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDIS.Models
{
    public partial class Ticket_seq_tmpModel
    {
        [Key]
        public string YYYMM { get; set; }
        public string TICKET_SEQ { get; set; }
    }
}
