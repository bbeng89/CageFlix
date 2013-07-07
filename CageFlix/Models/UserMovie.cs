using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CageFlix.Models
{
    [Table("UserMovie")]
    public class UserMovie
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileID { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }

        public int Rating { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual Movie Movie { get; set; }
    }
}