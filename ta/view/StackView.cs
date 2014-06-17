using UnityEngine;
using System.Collections;

public class StackView : MonoBehaviour {
	public GameObject prefabCard;
	public GameObject handView;
	public GameObject handView2;
	public GameObject handView3;
	public GameObject handView4;

	public void dealCard( IDeckPlayer player, ICard card ){
		GameObject cv = (GameObject)Instantiate (prefabCard, this.transform.position, this.transform.rotation);
		cv.GetComponent<CardViewConfig> ().cardModel = card;
		cv.transform.parent = this.transform;

		Transform targetTransform = null;

		switch (player.EntityID) {
		case (int)EnumEntityID.Player1:targetTransform = handView.transform;break;
		case (int)EnumEntityID.Player2:targetTransform = handView2.transform;break;
		case (int)EnumEntityID.Player3:targetTransform = handView3.transform;break;
		case (int)EnumEntityID.Player4:targetTransform = handView4.transform;break;
		}
		iTween.MoveTo ((GameObject)cv, iTween.Hash (	"x", targetTransform.position.x,
						                               	"y", targetTransform.position.y,
						                               	"time", 1));
		iTween.FadeTo ((GameObject)cv, iTween.Hash (	"alpha", 0,
		                                            	"time", 1,
		                                          		"oncomplete", "onMoveToComplete",
		                                            	"oncompletetarget", this.gameObject,
		                                           		"oncompleteparams",(GameObject)cv));

	}

	public void onMoveToComplete( GameObject cardView){
		Destroy (cardView);
	}
}
