using UnityEngine;
using System.Collections;

public class HandView : MonoBehaviour{

	ArrayList _ary_card = new ArrayList();
	void Start(){
		addCard (CardType.Club, 0);
		addCard (CardType.Club, 1);
		addCard (CardType.Club, 2);
		addCard (CardType.Club, 3);
		addCard (CardType.Club, 4);
		addCard (CardType.Club, 5);
		addCard (CardType.Club, 6);
		replaceCard ();
	}

	void Update(){

	}

	public void addCard( CardType ct, int id){
		GameObject c = (GameObject)Instantiate (PrefabSource.Card, transform.position, transform.rotation);

		c.transform.parent = this.transform;
		c.GetComponent<CardView> ().init (ct, id);
		_ary_card.Add (c);
	}

	public void replaceCard(){
		GameObject c;
		float tx, ty, tr;
		for( int i = 0; i < _ary_card.Count; ++i ){
			c = (GameObject)_ary_card[i];
			//c.transform.position = new Vector3( -2, 3, 0 );
			tx = i * ( 12 - _ary_card.Count ) * 15;
			ty = -Mathf.Abs( ( i - _ary_card.Count / 2 ) ) * 4;
			tr = -( Mathf.PI * (( i - _ary_card.Count / 2 ) * 1 ) / 180 );
			iTween.MoveTo(c, iTween.Hash("x", tx / 100, "y", 0, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", .5));
			iTween.FadeTo(c, iTween.Hash("alpha", 0, "time", 0));
			iTween.FadeTo(c, iTween.Hash("alpha", 1, "time", 1, "delay", i *.1));
			iTween.RotateBy( c, iTween.Hash("z", 1, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", 1));
		}
	}
	
}

