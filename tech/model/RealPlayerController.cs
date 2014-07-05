using UnityEngine;
using System.Collections;

public class RealPlayerController : PlayerControllerDefaultAdapter, IPlayPageDelegate, IMatchDelegate
{
	public void OnCurrentPlayerChange(IMatch match, IOption<IPlayer> player){
		if (match == Owner.Match) {
			bool isTurnToMe = player.Identity == Owner.EntityID;
			if (isTurnToMe) {
				Owner.DrawCard();
			}
		}
	}

	public void onPlayPageBtnPauseClick( object sender ){}
	public void onPlayPageBtnEnterClick( object sender ){}
	public void onPlayPageGameStart( object sender ){}
	public void onPlayPageSendCard( object sender, ICard cardModel ){
		Owner.PushCard(cardModel);
	}
	public override void AssignPlayer(IDeckPlayer owner){
		
	}
	public override void ControlNumber(int number, IDeckPlayer owner){
		
	}
}

