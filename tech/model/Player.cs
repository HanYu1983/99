using UnityEngine;
using System.Collections.Generic;

public class Player : IDeckPlayer
{
	List<ICard> _cards = new List<ICard>();
	public bool IsNoCard{ get{ return _cards.Count == 0; } }
	public void AddCard(ICard card){
		_cards.Add (card);
	}
	public bool IsContainCard(ICard card){
		return _cards.Contains (card);
	}
	public ICard RemoveCard(ICard card){
		_cards.Remove (card);
		return card;
	}
}

