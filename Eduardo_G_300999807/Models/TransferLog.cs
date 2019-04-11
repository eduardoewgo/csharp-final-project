using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eduardo_G_300999807.Models
{
    public class TransferLog
    {
        [Key]
        public int TransferId { get; set; }
        public Club FromClub { get; set; }
        public Club ToClub { get; set; }
        public DateTime Date { get; set; }
    }
}