using UnityEngine;
using System.Collections;

public class TestDeck : TestMono
{
	IDeck _deck = new Deck();
	IPlayer _player = new Player();
	void Start (){
		Assert (_deck.Cards.Count == 52, "1");
		Assert (_player.Cards.Count == 0, "2");
		Assert (Deck.ClubK == _deck.Peek(1)[0], "3");
		_deck.Draw (_player);
		Assert (_player.Cards.Count == 1, "4");
		Assert (_player.Cards [0] == Deck.ClubK, "5");
		Assert (_deck.Cards.Count == 51, "6");
		Assert (Deck.ClubQ == _deck.Peek(1)[0], "7");
		_deck.InsertBottom (_player, Deck.ClubK);
		Assert (_player.IsNoCard, "8");
		Assert (_deck.Cards [0] == Deck.ClubK, "9");
		_deck.Draw (_player);
		_deck.Draw (_player);
		Assert (_player.Cards.Count == 2, "10");
		Assert (_player.Cards [0] == Deck.ClubQ && _player.Cards [1] == Deck.ClubJ, "11");
		Assert (_deck.Peek (1) [0] == Deck.Club10, "12");
		_deck.Insert (_player, Deck.ClubQ, 1);
		Assert (_player.Cards.Count == 1, "13");
		Assert (_deck.Cards [1] == Deck.ClubQ, "14");
		_deck.Insert (_player, Deck.ClubJ, 1);
		Assert (_deck.Cards [1] == Deck.ClubJ, "15");
		Assert (_player.IsNoCard, "16");
		Assert (_deck.Cards.Count == 52, "17");
		Debug.Log ("Test OK");
	}
}