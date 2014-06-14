using UnityEngine;
using System.Collections;

public interface IPlayerController : ICardAbilityReceiver
{
	void Think();
	IPlayer Owner{ get; set; }
}