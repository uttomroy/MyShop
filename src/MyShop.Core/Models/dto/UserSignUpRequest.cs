namespace MyShop.Core.Models.dto;

public record class UserSignUpRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LocalName { get; set; }
    public int RoleId { get; set; }
}