using UnityEngine;
using System.Collections;

public class RealPlayerController : PlayerControllerDefaultAdapter, IPlayPageDelegate
{
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

