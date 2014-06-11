using UnityEngine;
using System.Collections.Generic;

public class View : MonoBehaviour, IView {

	public GameObject mainPagePrefab;
	public GameObject playPagePrefab;
	public GameObject resultPagePrefab;
	public GameObject rankPagePrefab;
	public GameObject pausePanelPrefab;

	Dictionary<string, GameObject> pages = new Dictionary<string, GameObject>();

	// Use this for initialization
	void Start () {
		openTargetPage ("mainPage");
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void openTargetPage( string pn ){
		if (pages.ContainsKey(pn))	return;
		GameObject p = null;
		GameObject layer = null;
		switch (pn) {
			case "mainPage":p = (GameObject)Instantiate( mainPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
			case "playPage":p = (GameObject)Instantiate( playPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
			case "resultPage":p = (GameObject)Instantiate( resultPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
			case "rankPage":p = (GameObject)Instantiate( rankPagePrefab );layer = GameObject.Find( "pageLayer" ); break;
			case "pausePanel":p = (GameObject)Instantiate( pausePanelPrefab );layer = GameObject.Find( "panelLayer" ); break;
			default: break;
		}
		p.transform.parent = layer.transform;
		pages.Add (pn, p);
	}

	public void closeTargetPage( string pn ){
		if (pages [pn] == null)	return;
		Destroy ( pages [pn]);
		pages.Remove (pn);
	}
}
