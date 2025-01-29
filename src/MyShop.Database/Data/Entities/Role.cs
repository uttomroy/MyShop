using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Database.Data.Entities;

public class Role
{
    [Key]
    [Column("role_id")]
    public int RoleId { get; set; }
    [Column("org_id")]
    public int OrgId { get; set; }
    public string Name { get; set; }
}