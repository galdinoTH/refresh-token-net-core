namespace RefreshToken.Domain.Entity;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; private set; }

    public bool Active { get; private set; }

    public Guid? RegisteredById { get; private set; }

    public Guid? LastChangeById { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        Active = true;
    }

    public void SetId(Guid id)
    {
        Id = id;
    }

    public void ChangeUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetRegisteredById(Guid value)
    {
        RegisteredById = value;
    }

    public void SetLastChangeById(Guid value)
    {
        LastChangeById = value;
    }

    public void InactivateLogical()
    {
        Active = false;
    }

    public void ActivateLogical()
    {
        Active = true;
    }

    public void SetCreatedAt(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }
}
