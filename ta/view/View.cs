﻿using UnityEngine;
using System.Collections.Generic;

public class View : SenderMono, IView {
	Dictionary<UIType, GameObject> pages = new Dictionary<UIType, GameObject>();

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		openTargetPage ( UIType.PlayPage );
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void openTargetPage( UIType pn ){
		if (pages.ContainsKey(pn))	return;
		GameObject p = null;
		GameObject layer = null;
		switch (pn) {
		case UIType.MainPage:
			layer = GameObject.Find( "pageLayer" );
			p = (GameObject)Instantiate( PrefabSource.MainPage, layer.transform.position, layer.transform.rotation ); 
			break;
		case UIType.PlayPage:
			layer = GameObject.Find( "pageLayer" ); 
			p = (GameObject)Instantiate( PrefabSource.PlayPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.ResultPage:
			layer = GameObject.Find( "pageLayer" ); 
			p = (GameObject)Instantiate( PrefabSource.ResultPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.RankPage:
			layer = GameObject.Find( "pageLayer" ); 
			p = (GameObject)Instantiate( PrefabSource.RankPage, layer.transform.position, layer.transform.rotation );
			break;
		case UIType.PausePanel:
			layer = GameObject.Find( "panelLayer" ); 
			p = (GameObject)Instantiate( PrefabSource.PausePanel, layer.transform.position, layer.transform.rotation );
			break;
		default: break;
		}
		p.transform.parent = layer.transform;
		pages.Add (pn, p);
	}

	public void closeTargetPage( UIType pn ){
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
