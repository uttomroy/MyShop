using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Database.Data.Entities
{
    public class Organization
    {
        [Key]
        [Column("org_id")]
        public int OrgId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }
    }
}
