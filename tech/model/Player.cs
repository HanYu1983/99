using UnityEngine;
using System.Collections.Generic;

public class Player : Deck, IPlayer
{
	public int EntityID{ get{ return 0; } }
	public EntityType EntityType{ get { return EntityType.Player; } }
}

