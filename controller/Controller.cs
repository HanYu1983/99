using UnityEngine;
using System.Collections;
using System.Linq;
public class Controller : ReceiverMono, IMainPageDelegate, IPausePanelDelegate, IPlayPageDelegate, IRankPageDelegate, IResultPageDelegate
{
	public GameObject viewGameObject;

	IView view {
		get{ return (IView)viewGameObject.GetComponent<InterfaceComponent> ().implementation; }
	}

	public void onMainPageBtnStartClick(object sender){
		view.closeTargetPage ( UI.MainPage );
		view.openTargetPage ( UI.PlayPage );
	}

	public void onMainPageBtnRankClick(object sender){
		view.closeTargetPage ( UI.MainPage);
		view.openTargetPage ( UI.RankPage);
	}

	public void onMainPageBtnQuitClick(object sender){

	}

	public void onPausePanelBtnResumeClick (object sender){
		view.closeTargetPage (UI.PausePanel);
	}

	public void onPausePanelBtnQuitClick (object sender){
		view.closeTargetPage (UI.PausePanel);
		view.closeTargetPage (UI.PlayPage);
		view.openTargetPage (UI.MainPage);
	}

	public void onPlayPageBtnPauseClick( object sender ){
		Debug.Log ("onPlayPageBtnPauseClick");
		view.openTargetPage(UI.PausePanel );
	}

	public void onPlayPageBtnEnterClick( object sender ){
		view.closeTargetPage (UI.PlayPage);
		view.openTargetPage (UI.ResultPage);
	}

	public void onRankPageBtnQuitClick( object sender ){
		view.closeTargetPage (UI.RankPage);
		view.openTargetPage (UI.MainPage);
	}

	public void onResultPageBtnReplayClick( object sender ){
		view.closeTargetPage (UI.ResultPage);
		view.openTargetPage (UI.PlayPage);
	}

	public void onResultPageBtnRankClick( object sender ){
		view.closeTargetPage (UI.ResultPage);
		view.openTargetPage (UI.RankPage);
	}

	public void onResultPageBtnQuitClick( object sender ){
		view.closeTargetPage (UI.ResultPage);
		view.openTargetPage (UI.MainPage);
	}
}

