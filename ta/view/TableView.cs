using UnityEngine;
using System.Collections;

public class TableView : MonoBehaviour {
	public GameObject prefabCard;
	private int _zindex = 0;

	public void PushCardToTable( IDeck deck, IDeckPlayer player, ICard card ){
		GameObject cv = (GameObject)Instantiate (prefabCard, this.transform.position, this.transform.rotation);
		cv.GetComponent<CardViewConfig> ().cardModel = card;
		cv.transform.parent = this.transform;
		cv.transform.position = new Vector3( cv.transform.position.x, cv.transform.position.y, cv.transform.position.z + _zindex );
		cv.transform.transform.Translate (new Vector3 (Random.value * 2 - 2, Random.value * 2 - 2, 0));
		cv.transform.Rotate( new Vector3(0, 0, Random.value * 360));
		iTween.ScaleBy (cv, iTween.Hash ("x", .5, "y", .5, "time", 1));
		iTween.RotateBy( cv, iTween.Hash("z", .6, "easeType", "spring", "loopType", "none", "time", 1));
		_zindex--;
	}
}
