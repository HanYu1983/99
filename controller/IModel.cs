using UnityEngine;
using System.Collections;

public interface IModel
{
	void StartGame();
	void PlayerJoin(IOption<IPlayer> player);
}