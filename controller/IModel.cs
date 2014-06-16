using UnityEngine;
using System.Collections;

public interface IModel : IModelGetter
{
	void StartGame();
	void PlayerJoin(IOption<IPlayer> player);
}