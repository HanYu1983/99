using UnityEngine;
using System.Collections;

public class Card : ICard
{
	CardType _type;
	int _id;
	public CardType Type { get{ return _type; }}
	public int Id { get{ return _id; }}
	public Card(CardType type, int id){
		_type = type;
		_id = id;
	}
}

