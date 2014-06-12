using UnityEngine;
using System.Collections;

public interface IDeckPlayer
{
	bool IsNoCard{ get; }
	void AddCard(ICard card);
	bool IsContainCard(ICard card);
	ICard RemoveCard(ICard card);
}

