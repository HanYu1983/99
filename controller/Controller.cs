using UnityEngine;
using System.Collections;
using System.Linq;
public class Controller : ReceiverMono, IViewInject, IMainPageDelegate, IPausePanelDelegate, IPlayPageDelegate, IRankPageDelegate, IResultPageDelegate
{
	IView _view;
	public IView view{ set { _view = value; } get { return _view; } }

	public void onMainPageBtnStartClick(object sender){
		view.CloseTargetPage ( UIType.MainPage );
		view.OpenTargetPage ( UIType.PlayPage );
	}

	public void onMainPageBtnRankClick(object sender){
		view.CloseTargetPage ( UIType.MainPage);
		view.OpenTargetPage ( UIType.RankPage);
	}

	public void onMainPageBtnQuitClick(object sender){

	}

	public void onPausePanelBtnResumeClick (object sender){
		view.CloseTargetPage (UIType.PausePanel);
	}

	public void onPausePanelBtnQuitClick (object sender){
		view.CloseTargetPage (UIType.PausePanel);
		view.CloseTargetPage (UIType.PlayPage);
		view.OpenTargetPage (UIType.MainPage);
	}

	public void onPlayPageBtnPauseClick( object sender ){
		Debug.Log ("onPlayPageBtnPauseClick");
		view.OpenTargetPage(UIType.PausePanel );
	}

	public void onPlayPageBtnEnterClick( object sender ){
		view.CloseTargetPage (UIType.PlayPage);
		view.OpenTargetPage (UIType.ResultPage);
	}

	public void onRankPageBtnQuitClick( object sender ){
		view.CloseTargetPage (UIType.RankPage);
		view.OpenTargetPage (UIType.MainPage);
	}

	public void onResultPageBtnReplayClick( object sender ){
		view.CloseTargetPage (UIType.ResultPage);
		view.OpenTargetPage (UIType.PlayPage);
	}

	public void onResultPageBtnRankClick( object sender ){
		view.CloseTargetPage (UIType.ResultPage);
		view.OpenTargetPage (UIType.RankPage);
	}

	public void onResultPageBtnQuitClick( object sender ){
		view.CloseTargetPage (UIType.ResultPage);
		view.OpenTargetPage (UIType.MainPage);
	}
}

