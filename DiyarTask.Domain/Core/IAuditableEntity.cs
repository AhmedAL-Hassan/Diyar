namespace DiyarTask.Domain.Core;

using System.ComponentModel.DataAnnotations;

public interface IAuditableEntity
{
    DateTime CreatedDate { get; }

    [MaxLength(225)]
    string CreatedBy { get; }

    DateTime? ModifiedDate { get; }

    [MaxLength(225)]
    string ModifiedBy { get; }
}