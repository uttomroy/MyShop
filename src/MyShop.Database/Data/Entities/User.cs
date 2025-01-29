using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Database.Data.Entities;

public class User
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("org_id")]
    public int OrgId { get; set; }
    [Column("name_local_lang")]
    public string LocalName { get; set; }
    public string Name { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }
    [Column("password_hash")]
    public string Password { get; set; }
}