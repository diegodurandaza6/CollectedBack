namespace Security.Domain.Models
{
    public record UserModelDto(string Identification, string UserName, string Password, string Rol, string Name, string Surname, string Phone, string Email) { }
}
