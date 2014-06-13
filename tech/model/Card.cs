using UnityEngine;
using System.Collections;

public class Card : ICard
{
	CardType _type;
	int _number;
	int _id;
	public CardType Type { get{ return _type; }}
	public int Id { get{ return _id; }}
	public int Number { get { return _number; } }	
	public Card(CardType type, int number, int id){
		_type = type;
		_id = id;
		_number = number;
	}
	public override string ToString(){
		return "Card(" + _type + "," +_number+ ")";
	}
}

