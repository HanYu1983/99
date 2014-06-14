using UnityEngine;
using System.Collections;

public class AIPlayerController : PlayerControllerDefaultAdapter, IMatchDelegate
{
	public void OnCurrentPlayerChange(IMatch match, IOption<IPlayer> player){
		if (match == Owner.Match) {
			bool isTurnToMe = player.Instance == Owner;
			if (isTurnToMe) {
				Owner.DrawCard();
			}
		}
	}
	public void OnUpdate(){
		if (IsMyTurn) {
			//Owner.Match.CurrentPlayer = Owner.Match.NextPlayer;
		}
	}
	public override void AssignPlayer(IDeckPlayer owner){
		
	}
	public override void ControlNumber(int number, IDeckPlayer owner){
		Owner.Match.GameState.AddNumber (number);
	}
}