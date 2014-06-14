using UnityEngine;
using System.Collections.Generic;

public class Player : Deck, IPlayer
{
	public int EntityID{ get{ return 0; } set{ } }
	public EntityType EntityType{ get { return EntityType.Player; } }

	IPlayerController _controller;
	public IPlayerController Controller{ get{ return _controller; } set{ _controller = value; } }

	public void PushCard(ICard card){

	}
}

