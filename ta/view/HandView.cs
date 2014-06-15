using UnityEngine;
using System.Collections;

public class HandView : MonoBehaviour{

	ArrayList _ary_card = new ArrayList();
	void Start(){
		addCard (Card.Club4);
		addCard (Card.Diamond9);
		addCard (Card.Heart8);
		addCard (Card.Spade2);
		addCard (Card.SpadeJ);
		addCard (Card.Spade4);
		addCard (Card.Diamond4);
		replaceCard ();
	}

	void Update(){

	}

	public void addCard( Card cardModel ){
		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> (100).Instance;
		GameObject c = (GameObject)Instantiate (prefabSource.Card );

		c.transform.parent = this.transform;
		c.GetComponent<CardViewConfig> ().cardModel = cardModel;
		_ary_card.Add (c);
	}

	public void replaceCard(){
		GameObject c;
		float tx, ty, tr;
		for( int i = 0; i < _ary_card.Count; ++i ){
			c = (GameObject)_ary_card[i];
			//c.transform.position = new Vector3( -2, 3, 0 );
			tx = i * ( 12 - _ary_card.Count ) * 15;
			ty = -Mathf.Abs( ( i - _ary_card.Count / 2 ) ) * 6;
			tr = -( Mathf.PI * (( i - _ary_card.Count / 2 ) * .6f ) / 180 );
			iTween.MoveTo(c, iTween.Hash("x", tx / 100, "y", ty / 100, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", .5));
			iTween.FadeTo(c, iTween.Hash("alpha", 0, "time", 0));
			iTween.FadeTo(c, iTween.Hash("alpha", 1, "time", 1, "delay", i *.1));
			iTween.RotateBy( c, iTween.Hash("z", tr, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", 1));
		}
	}
	
}

