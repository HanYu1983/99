using UnityEngine;
using System.Collections;
using System.Linq;
public class Controller : ReceiverMono, IViewInject, IMainPageDelegate, IPausePanelDelegate, IPlayPageDelegate, IRankPageDelegate, IResultPageDelegate
{
	IView _view;
	public IView view{ set { _view = value; } get { return _view; } }

	public void onMainPageBtnStartClick(object sender){
		view.closeTargetPage ( UIType.MainPage );
		view.openTargetPage ( UIType.PlayPage );
	}

	public void onMainPageBtnRankClick(object sender){
		view.closeTargetPage ( UIType.MainPage);
		view.openTargetPage ( UIType.RankPage);
	}

	public void onMainPageBtnQuitClick(object sender){

	}

	public void onPausePanelBtnResumeClick (object sender){
		view.closeTargetPage (UIType.PausePanel);
	}

	public void onPausePanelBtnQuitClick (object sender){
		view.closeTargetPage (UIType.PausePanel);
		view.closeTargetPage (UIType.PlayPage);
		view.openTargetPage (UIType.MainPage);
	}

	public void onPlayPageBtnPauseClick( object sender ){
		Debug.Log ("onPlayPageBtnPauseClick");
		view.openTargetPage(UIType.PausePanel );
	}

	public void onPlayPageBtnEnterClick( object sender ){
		view.closeTargetPage (UIType.PlayPage);
		view.openTargetPage (UIType.ResultPage);
	}

	public void onRankPageBtnQuitClick( object sender ){
		view.closeTargetPage (UIType.RankPage);
		view.openTargetPage (UIType.MainPage);
	}

	public void onResultPageBtnReplayClick( object sender ){
		view.closeTargetPage (UIType.ResultPage);
		view.openTargetPage (UIType.PlayPage);
	}

	public void onResultPageBtnRankClick( object sender ){
		view.closeTargetPage (UIType.ResultPage);
		view.openTargetPage (UIType.RankPage);
	}

	public void onResultPageBtnQuitClick( object sender ){
		view.closeTargetPage (UIType.ResultPage);
		view.openTargetPage (UIType.MainPage);
	}
}

