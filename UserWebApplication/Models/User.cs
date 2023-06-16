using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace UserWebApplication.Models
{
    [Table("usm_user_mst", Schema = "dbo")]
    public class User
    {    
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Column("usm_user_id")]
            public int Id { get; set; }

            [Required]
        [Column("usm_user_name")]
        [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "UserPassword")]
        [Column("usm_user_password")]
        public string UserPassword { get; set; }
            [Required]
            [Display(Name = "UserEmail")]
        [Column("usm_user_email")]
        public string UserEmail { get; set; }

        [Display(Name = "UserAddress")]
        [Column("usm_user_address")]
        public string UserAddress { get; set; }

        [Required]
        [Display(Name = "UserPhone")]
        [Column("usm_user_phone")]
        public string UserPhone { get; set; }

        [Required]
            [Display(Name = "CreatedOn")]
        [Column("usm_user_add_date")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Active")]

        [Column("usm_user_active")]
        public byte Active   { get; set; } = 1;

 
    }
}
