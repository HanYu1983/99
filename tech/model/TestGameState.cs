using UnityEngine;
using System.Collections;

public class TestGameState : TestMono
{

	void Start ()
	{
		IGameState gameState = new GameState();
		IPlayer player = new Player();
		gameState.CenterDeck = new Deck ();
		Assert (gameState.CurrentNumber == 0, "1");
		player.AddCard(Card.Club10);
		player.AddCard(Card.ClubJ);
		player.AddCard(Card.ClubQ);
		player.AddCard(Card.ClubK);
		gameState.CenterDeck.Push (player, Card.Club10);
		Assert (gameState.CurrentNumber == 10, "2");
		gameState.CenterDeck.Push (player, Card.ClubJ);
		Assert (gameState.CurrentNumber == 20, "3");
		gameState.CenterDeck.Push (player, Card.ClubQ);
		Assert (gameState.CurrentNumber == 40, "4");
		gameState.CenterDeck.Push (player, Card.ClubK);
		Assert (gameState.CurrentNumber == 99, "5");
		Assert (player.IsNoCard, "5");
	}
}