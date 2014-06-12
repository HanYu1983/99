using UnityEngine;
using System.Collections;

public class TestDeck : MonoBehaviour
{
	IDeck _deck = new Deck();
	void Start (){
		_deck.Cards.ForEach (Debug.Log);
	}
}

