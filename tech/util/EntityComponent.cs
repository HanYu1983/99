using UnityEngine;
using System.Collections;

public class EntityComponent : ReceiverMono, IEntity, IEntityManagerInject
{
	public int entityId;
	public EntityType entityType;

	public int EntityID{ get{ return entityId; } }
	public EntityType EntityType{ get { return entityType; } }

	IEntityManager _entityManager;
	public IEntityManager EntityManager{ get{ return _entityManager; } set{ _entityManager = value; } }

	protected override void Start(){
		base.Start ();
		EntityManager.Register (this);
	}

	protected override void OnDestroy(){
		EntityManager.Remove (this);
		base.OnDestroy ();
	}
}

