using UnityEngine;
using System.Collections;
using System.Linq;
public class PlayPage : SenderMono {

	GameObject cardPrefab = Resources.LoadAssetAtPath<GameObject> ("Assets/gitAssets/ta/prefab/sub/Card.prefab") ;
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		GameObject cardParent = GameObject.Find ("container_hand");
		GameObject c = (GameObject)Instantiate (cardPrefab, cardParent.transform.position, cardParent.transform.rotation);
		c.transform.parent = GameObject.Find ("container_hand").transform;
		//c.transform.Translate (new Vector3 (1, 0));
		//StartCoroutine (delayAndPlay ());
	}
	/*
	IEnumerator delayAndPlay(){
		yield return new WaitForSeconds (3);
		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageBtnEnterClick( this );
		});
	}
	*/
	// Update is called once per frame
	void Update () {

	}

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
		case "btn_pause":
			Sender.Receivers.ToList().ForEach( obj => {
				((IPlayPageDelegate)obj).onPlayPageBtnPauseClick( this );
			});
			break;
		}
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IPlayPageDelegate).IsAssignableFrom (receiver.GetType ());
	}
}