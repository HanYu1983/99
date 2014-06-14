using UnityEngine;
using System.Collections.Generic;

public interface IDeck : IDeckPlayer
{
	IDeckDelegate DeckDelegate{ get; set; }
	bool IsEmpty{ get; }
	void Shuffle();
	IList<ICard> Peek(int amount);
	void Draw(IDeckPlayer player);
	void Push(IDeckPlayer player, ICard card);
	void Insert(IDeckPlayer player, ICard card, int index);
	void InsertBottom(IDeckPlayer player, ICard card);
}

