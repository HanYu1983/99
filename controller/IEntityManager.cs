using UnityEngine;
using System.Collections.Generic;



public interface IEntityManager
{
	void Register(IEntity entity);
	void Remove(IEntity entity);
	IList<IOption<T>> Get<T>(T clz, EntityType type);
}