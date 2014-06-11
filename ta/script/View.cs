using UnityEngine;
using System.Collections.Generic;

public class View : SenderMono, IView {

	public GameObject mainPagePrefab;
	public GameObject playPagePrefab;
	public GameObject resultPagePrefab;
	public GameObject rankPagePrefab;
	public GameObject pausePanelPrefab;

	Dictionary<UI, GameObject> pages = new Dictionary<UI, GameObject>();

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		openTargetPage ( UI.MainPage );
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void openTargetPage( UI pn ){
		if (pages.ContainsKey(pn))	return;
		GameObject p = null;
		GameObject layer = null;
		switch (pn) {
		case UI.MainPage:p = (GameObject)Instantiate( mainPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
		case UI.PlayPage:p = (GameObject)Instantiate( playPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
		case UI.ResultPage:p = (GameObject)Instantiate( resultPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
		case UI.RankPage:p = (GameObject)Instantiate( rankPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
		case UI.PausePanel:p = (GameObject)Instantiate( pausePanelPrefab );layer = GameObject.Find( "panelLayer" ); break;
		default: break;
		}
		p.transform.parent = layer.transform;
		pages.Add (pn, p);
	}

	public void closeTargetPage( UI pn ){
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
