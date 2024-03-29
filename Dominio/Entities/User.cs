namespace Dominio.Entities;

public class User : BaseEntity
{
    public string Usuario { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<UserRol> UsersRols { get; set;}
     public ICollection<RefreshToken> RefreshTokens { get; set; }
}