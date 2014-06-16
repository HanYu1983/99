using UnityEngine;
using System.Collections;

public class TableView : MonoBehaviour {
	private int _zindex = 0;

	public void PushCardToTable( IDeck deck, IDeckPlayer player, ICard card ){
		PrefabSource ps = EntityManager.Singleton.GetEntity<PrefabSource> ((int)EnumEntityID.PrefabeSource).Instance;
		
		GameObject cv = (GameObject)Instantiate (ps.Card, this.transform.position, this.transform.rotation);
		cv.GetComponent<CardViewConfig> ().cardModel = card;
		cv.transform.parent = this.transform;
		cv.transform.position = new Vector3( cv.transform.position.x, cv.transform.position.y, cv.transform.position.z + _zindex );
		cv.transform.transform.Translate (new Vector3 (Random.value * 2, 0, 0));
		cv.transform.Rotate( new Vector3(0, 0, Random.value * 360));
		_zindex--;
	}
}
