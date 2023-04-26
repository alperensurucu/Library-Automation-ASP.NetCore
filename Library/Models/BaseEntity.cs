using Library.Enum;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.VisualBasic;
using System;

namespace Library.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateAndTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DataStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
