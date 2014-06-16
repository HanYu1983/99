using UnityEngine;
using System.Collections;

public class StackView : MonoBehaviour {

	public GameObject container_hand;
	public GameObject container_hand2;
	public GameObject container_hand3;
	public GameObject container_hand4;

	public void dealCard( IDeckPlayer player, ICard card ){
		PrefabSource ps = EntityManager.Singleton.GetEntity<PrefabSource> ((int)EnumEntityID.PrefabeSource).Instance;

		GameObject cv = (GameObject)Instantiate (ps.Card, this.transform.position, this.transform.rotation);
		cv.GetComponent<CardViewConfig> ().cardModel = card;

		Transform targetTransform = null;

		switch (player.EntityID) {
		case (int)EnumEntityID.Player1:targetTransform = container_hand.transform;break;
		case (int)EnumEntityID.Player2:targetTransform = container_hand2.transform;break;
		case (int)EnumEntityID.Player3:targetTransform = container_hand3.transform;break;
		case (int)EnumEntityID.Player4:targetTransform = container_hand4.transform;break;
		}
		iTween.MoveTo( (GameObject)cv, iTween.Hash("x", targetTransform.position.x,
		                               "y", targetTransform.position.y,
		                               "time", 1 ));
	}
}
