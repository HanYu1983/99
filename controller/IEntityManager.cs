using UnityEngine;
using System.Collections.Generic;

public interface IEntityManager : IOptionContainer
{
	T Create<T> (int id = -1) where T : IEntity, new();
	void Destroy(int id);
	void Register(IEntity entity);
	void Unregister(IEntity entity);
	IOption<T> GetEntity<T>(int entityId);
	IEnumerable<IOption<T>> GetType<T>(EntityType type);
}