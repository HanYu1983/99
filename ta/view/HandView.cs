using UnityEngine;
using System.Collections;

public class HandView : MonoBehaviour{

	public GameObject prefabCard;
	ArrayList _ary_card = new ArrayList();

	public void addCard( ICard cardModel ){
		GameObject c = (GameObject)Instantiate (prefabCard, this.transform.position, this.transform.rotation);

		c.transform.parent = this.transform;
		c.GetComponent<CardViewConfig> ().cardModel = cardModel;
		c.name = "CardView";
		_ary_card.Add (c);
		replaceCard ();
	}

	public void subCard( GameObject card ){
		_ary_card.Remove (card);
		replaceCard ();
	}

	public GameObject getCardViewByModel( ICard cardModel ){
		foreach (GameObject go in _ary_card) {
			if( go.GetComponent<CardViewConfig>().cardModel == cardModel )	return go;
		}
		return null;
	}

	public void replaceCard(){
		GameObject c;
		float tx, ty, tr;
		for( int i = 0; i < _ary_card.Count; ++i ){
			c = (GameObject)_ary_card[i];
			//c.transform.position = new Vector3( 0, 0, 100 );
			//tx = i * ( 14 - _ary_card.Count ) * 30;
			tx = i * 800 / ( _ary_card.Count );
			ty = -Mathf.Abs( ( i - _ary_card.Count / 2 ) ) * 6;
			tr = -( Mathf.PI * (( i - _ary_card.Count / 2 ) * .6f ) / 180 );
			iTween.MoveTo(c, iTween.Hash("x", tx / 100 + this.transform.position.x, 
			                            // "y", ty / 100 + this.transform.position.y, 
			                             "z", this.transform.position.z - i,
			                             "easeType", "spring", "loopType", "none", "delay", i * .1, "time", .5));
			//iTween.FadeTo(c, iTween.Hash("alpha", 0, "time", 0));
			//iTween.FadeTo(c, iTween.Hash("alpha", 1, "time", 1, "delay", i *.1));
			//iTween.RotateBy( c, iTween.Hash("z", tr, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", 1));
		}
	}
	
}

