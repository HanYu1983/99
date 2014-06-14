using UnityEngine;
using System.Collections;

public interface IPlayer : IDeckPlayer, IEntity
{
	void PushCard(ICard card);
	IPlayerController Controller{ get; set; }
}