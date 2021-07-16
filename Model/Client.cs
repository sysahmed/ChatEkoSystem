using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Model
{
    public class Client
    {
        [Key]
        [Index(IsUnique = true)]
        public int ClinetId { get; set; }
        public string ConnectionId { get; set; }
        public string NickName { get; set; }
        public DateTime TimeStampBegin { get; set; }
        public DateTime TimeStampEnd { get; set; }
    }
}
