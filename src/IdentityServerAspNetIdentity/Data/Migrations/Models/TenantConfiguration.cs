using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerAspNetIdentity.Data.Migrations.Models
{
    public class TenantConfiguration
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TenantID { get; set; }
        public string ClientId { get; set; }
        //public Client Client { get; set; }
        public List<ExternalProvider> ExternalProviders { get; set; }
        public string Domain { get; set; }
    }
}
