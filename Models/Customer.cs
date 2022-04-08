using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicScaffold.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Customer")]
        public string Name { get; set; }

        [Display(Name = "Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}