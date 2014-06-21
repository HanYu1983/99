using UnityEngine;
using System.Collections;
using System.Linq;
public class Controller :
	ReceiverMono, 
	IViewInject, 
	IInjectModel,
	IMainPageDelegate, 
	IPausePanelDelegate, 
	IPlayPageDelegate, 
	IRankPageDelegate, 
	IResultPageDelegate,
	IDeckDelegate,
	IMatchDelegate,
	IGameStateDelegate
{
	IView _view;
	public IView view{ set { _view = value; } get { return _view; } }
	IModel _model;
	public IModel Model{ set { _model = value; } get { return _model; } }

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

	public void onPlayPageGameStart( object sender ){
		IPlayer p = EntityManager.Singleton.Create<Player> ((int)EnumEntityID.Player1);
		IPlayer p2 = EntityManager.Singleton.Create<Player> ((int)EnumEntityID.Player2);
		IPlayer p3 = EntityManager.Singleton.Create<Player> ((int)EnumEntityID.Player3);
		IPlayer p4 = EntityManager.Singleton.Create<Player> ((int)EnumEntityID.Player4);

		p.Controller = EntityManager.Singleton.Create<AIPlayerController> ();
		p2.Controller = EntityManager.Singleton.Create<AIPlayerController> ();
		p3.Controller = EntityManager.Singleton.Create<AIPlayerController> ();
		p4.Controller = EntityManager.Singleton.Create<AIPlayerController> ();

		_model.PlayerJoin (EntityManager.Singleton.GetEntity<IPlayer>(p.EntityID));
		_model.PlayerJoin (EntityManager.Singleton.GetEntity<IPlayer>(p2.EntityID));
		_model.PlayerJoin (EntityManager.Singleton.GetEntity<IPlayer>(p3.EntityID));
		_model.PlayerJoin (EntityManager.Singleton.GetEntity<IPlayer>(p4.EntityID));

		_model.StartGame ();
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

	//model----------------------------------------
	public void OnPlayerDraw(IDeck deck, IDeckPlayer player, ICard card){
		view.AddCard (deck, player, card);
	}

	public void OnCardPush(IDeck deck, IDeckPlayer player, ICard card){
		view.PushCardToTable (deck, player, card);
	}

	public void OnCurrentPlayerChange(IMatch match, IOption<IPlayer> player){
		if( match.MatchPhase == MatchPhase.Stop ){
			StartCoroutine (DelayAndNextStep ());
		}
	}

	IEnumerator DelayAndNextStep(){
		yield return new WaitForSeconds (3);
		_model.Step ();
	}

	public void OnGameNumberChanged(IGameState state, int number){
		view.GameNumberChanged (state, number);
	}

	public void OnDirectionChanged(IGameState state, Direction direction){
		view.DirectionChanged (state, direction);
	}
	
}