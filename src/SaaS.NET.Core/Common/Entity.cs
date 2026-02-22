using System.ComponentModel.DataAnnotations;

namespace SaaS.NET.Core.Common;

public abstract class Entity
{
    [Key] 
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
}