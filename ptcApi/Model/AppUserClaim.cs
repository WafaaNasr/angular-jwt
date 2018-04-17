using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ptcApi.Model {
    [Table ("UserClaim", Schema = "Security")]
    public class AppUserClaim {
        [Required ()]
        public Guid ClaimId { get; set; }

        [Required ()]
        public Guid UserId { get; set; }

        [Required ()]
        public string ClaimType { get; set; }

        [Required ()]
        public string ClaimValue { get; set; }
    }
}