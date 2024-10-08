﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketApi.Entities
{
    [PrimaryKey("Id")]
    public class TheatreScreen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //This will make sure it will be an identity column, so will be autogenerated
        public int Id { get; set; }
        [ForeignKey("TheatreMaster")]
        public int TheatreId { get; set; }
        public string? ScreenName { get; set; }
        public required List<int> Rows { get; set; }
        public required List<int> SeatNos { get; set; }


        public virtual TheatreMaster TheatreMaster { get; set; }    //This will be used for FK crud operation
    }
}
