using UnityEngine;
using System.Collections;

public class AIPlayerController : PlayerControllerDefaultAdapter, IMatchDelegate, IInjectUpdate
{
	AIThinkingData _thinking = new AIThinkingData();

	public void OnCurrentPlayerChange(IMatch match, IOption<IPlayer> player){
		if (match == Owner.Match) {
			bool isTurnToMe = player.Instance == Owner;
			if (isTurnToMe) {
				Owner.DrawCard();
			}
		}
	}
	public void OnUpdate(object sender){
		if (IsMyTurn) {
			_thinking.Match = Owner.Match;

			if(_thinking.WillOutOf99(Owner)){
				IPlayer leastCardPlayer = _thinking.LeastCardOfPlayer(Owner);
				bool leastCardPlayerMaybeWillOutOf99 = leastCardPlayer.Cards.Count < 1;
			}

			if(Owner.Cards.Count>0)
				Owner.PushCard(Owner.Cards[0]);


			Owner.Match.CurrentPlayer = Owner.Match.NextPlayer;
		}
	}
	public override void AssignPlayer(IDeckPlayer owner){
		
	}
	public override void ControlNumber(int number, IDeckPlayer owner){
		Owner.Match.GameState.AddNumber (number);
	}
}