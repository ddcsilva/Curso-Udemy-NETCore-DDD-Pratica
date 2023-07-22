using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities;

public class UsuarioEntity : BaseEntity
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
}