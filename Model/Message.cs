using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Model
{
    public class Message
    {
        [Key]
        [Index(IsUnique = true)]
        public int MessagesId { get; set; }  
        public string  ConnectionId { get; set; }
        public string TeextMessage { get; set; }
        public int MessageLength { get; set; }
       
    }
}
