using UnityEngine;
using System.Collections;
using System.Linq;

public class GameState : IGameState, ICardAbilityReceiver
{
	int _entityId;
	public int EntityID{ get{ return _entityId; } set{ _entityId = value; } }
	public EntityType EntityType{ get { return EntityType.Unknown; } }

	IDeck _centerDeck;
	Direction _direction = Direction.Forward;
	int _currentNumber;

	public IDeck CenterDeck{ 
		get{ return _centerDeck; } 
		set{ _centerDeck = value; } 
	}
	public int CurrentNumber{ 
		get{ return _currentNumber; }
	}
	public bool IsOutOf99{ get{ return CurrentNumber > 99; } }

	public IDeckPlayer CardOwner{ get{ return null; } }
	public Direction Direction{ get{ return _direction; } set{ _direction = value; } }
	public void AddNumber(int number){ 
		_currentNumber += number;
	}
	public void Pass(IDeckPlayer owner){
		// no feature
	}
	public void FullNumber(){
		_currentNumber = 99;
	}
	public void AssignPlayer(IDeckPlayer owner){
		// no feature
	}
	public void ControlNumber(int number, IDeckPlayer owner){
		// no feature
	}
	
}