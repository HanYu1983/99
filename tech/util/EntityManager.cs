using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EntityManager : IEntityManager
{
	public static IEntityManager Singleton = new EntityManager();
	Dictionary<int, IEntity> _entities = new Dictionary<int, IEntity>();
	public T Create<T>(int id = -1) where T : IEntity, new(){
		T ret = new T ();
		Register (ret);
		return ret;
	}
	public void Destroy(int id){
		if (_entities.ContainsKey (id)) {
			Unregister(_entities[id]);
			_entities[id].OnEntityDestroy(this);
		}
	}
	public void Register(IEntity entity){
		if (entity.EntityID == -1) {
			entity.EntityID = GenerateId();
		}
		Debug.Log ("Register "+entity+" "+entity.EntityID);
		_entities [entity.EntityID] = entity;
		AddEventManager (entity);
	}
	public void Unregister(IEntity entity){
		RemoveEventManager(entity);
		_entities.Remove(entity.EntityID);
	}
	public IOption<T> GetEntity<T>(int entityId){
		return Option<T>.Wrap(entityId, this);
	}
	public IEnumerable<IOption<T>> GetType<T>(EntityType type){
		return _entities.Values.ToList ().FindAll (entity=>{
			return entity.EntityType == type;
		}).Select(entity=>{ return (IOption<T>)Option<T>.Wrap(entity.EntityID, this); });
	}
	public object GetObject(int id){
		if (_entities.ContainsKey (id))
			return _entities [id];
		else
			return null;
	}
	void AddEventManager(object obj){
		EventManager.Singleton.AddReceiver (obj);
		if (obj is IEventSender) {
			EventManager.Singleton.AddSender((IEventSender)obj);
		}
	}
	void RemoveEventManager(object obj){
		EventManager.Singleton.RemoveReceiver (obj);
		if (obj is IEventSender) {
			EventManager.Singleton.RemoveSender((IEventSender)obj);
		}
	}
	int _id = -1;
	int GenerateId(){
		return --_id;
	}
}