using UnityEngine;
using System.Collections;

public interface IPlayer : IDeckPlayer, IEntity
{
	void PushCard(ICard card);
	void DrawCard();
	IMatch Match{ get; }
	IPlayerController Controller{ get; set; }
	IOption<IPlayer> Next{ get; set; }
	IOption<IPlayer> Prev{ get; set; }
}