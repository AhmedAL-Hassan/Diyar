namespace DiyarTask.Domain.Core;

public interface ISoftDelete
{
    bool IsDeleted { get; }
}