using UnityEngine;
using System.Collections;

public interface IDeckDelegate
{
	void OnCardPush(IDeck deck, IDeckPlayer player, ICard card);
}