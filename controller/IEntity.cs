using UnityEngine;
using System.Collections;

public interface IEntity
{
	int EntityID{ get; }
	EntityType EntityType{ get; }
}

