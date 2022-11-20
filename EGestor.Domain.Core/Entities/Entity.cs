using FluentValidator;

namespace EGestor.Shared.Entities;

public abstract class Entity : Notifiable
{
    public Guid Id { get; protected set; }

	public Entity()
	{
		Id = Guid.NewGuid();
	}
}
