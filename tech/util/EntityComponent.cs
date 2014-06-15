using UnityEngine;
using System.Collections;

public class EntityComponent : MonoBehaviour, IEntity
{
	public int entityId = -1;
	public EntityType entityType;

	public int EntityID{ get{ return entityId; } set{ entityId = value; } }
	public EntityType EntityType{ get { return entityType; } set{ entityType = value; } }
	public void OnEntityDestroy(IEntityManager mgr){}


}