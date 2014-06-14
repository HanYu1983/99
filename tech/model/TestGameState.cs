using UnityEngine;
using System.Collections;

public class TestGameState : TestMono, IPlayerController
{
	IGameState _currGameState;

	void Start ()
	{
		TestAbility ();
	}

	void TestAbility(){
		IGameState gameState = new GameState();
		_currGameState = gameState;
		IPlayer player = new Player();
		player.Controller = this;
		gameState.CenterDeck = new Deck ();
		Assert (gameState.CurrentNumber == 0, "1");
		player.AddCard(Card.ClubA);
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
		gameState.CenterDeck.Push (player, Card.ClubA);
		Assert (gameState.CurrentNumber == 100, "6");
		Assert (gameState.IsOutOf99, "7");
		Assert (player.IsNoCard, "8");
	}
	public IPlayer Owner{ get{ return null; } set{ } }
	public IDeckPlayer CardOwner{ get{ return null; } }
	public Direction Direction{ get{ return Direction.Forward; } set{} }
	public void AddNumber(int number){ }
	public void Pass(IDeckPlayer owner){ }
	public void FullNumber(){ }
	public void AssignPlayer(IDeckPlayer owner){

	}
	public void ControlNumber(int number, IDeckPlayer owner){
		_currGameState.AddNumber (number);
	}
}