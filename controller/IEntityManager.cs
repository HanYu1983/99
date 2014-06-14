using UnityEngine;
using System.Collections.Generic;



public interface IEntityManager
{
	void Register(IEntity entity);
	void Remove(IEntity entity);
	IOption<T> GetEntity<T>(int entityId);
	IList<IOption<T>> GetType<T>(EntityType type);
}