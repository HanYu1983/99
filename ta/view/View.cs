using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class View : SenderMono, IView {
	Dictionary<UIType, GameObject> pages = new Dictionary<UIType, GameObject>();

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		StartCoroutine (delayAndPlay ());
	}

	IEnumerator delayAndPlay(){
		yield return new WaitForEndOfFrame ();
		OpenTargetPage ( UIType.MainPage );
	}

	public void AddCard( IDeck deck, IDeckPlayer player, ICard card ){
		if (!pages.ContainsKey (UIType.PlayPage))	throw new UnityException ("You should at playPage");
		PlayPage playPage = pages [UIType.PlayPage].GetComponent<PlayPage> ();
		playPage.dealCard (deck, player, card);
	}

	public void PushCardToStack( IDeck deck, IDeckPlayer player, ICard card ){

	}

	public void OpenTargetPage( UIType pn ){
		if (pages.ContainsKey(pn))	return;
		GameObject p = null;
		GameObject layer = GameObject.Find ("View");
		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> (100).Instance;
		switch (pn) {
		case UIType.MainPage:
			p = (GameObject)Instantiate( prefabSource.MainPage, layer.transform.position, layer.transform.rotation ); 
			break;
		case UIType.PlayPage:
			p = (GameObject)Instantiate( prefabSource.PlayPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.ResultPage:
			p = (GameObject)Instantiate( prefabSource.ResultPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.RankPage:
			p = (GameObject)Instantiate( prefabSource.RankPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.PausePanel:
			p = (GameObject)Instantiate( prefabSource.PausePanel, layer.transform.position, layer.transform.rotation );
			break;
		default: break;
		}
		p.transform.parent = layer.transform;
		pages.Add (pn, p);
	}

	public void CloseTargetPage( UIType pn ){
		if (pages [pn] == null)	return;
		Destroy ( pages [pn]);
		pages.Remove (pn);
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		bool isTarget = typeof(IViewInject).IsAssignableFrom (receiver.GetType ());
		if (isTarget) {
			((IViewInject)receiver).view = this;
		}
		return false;
	}
}
