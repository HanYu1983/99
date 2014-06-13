using UnityEngine;
using System.Collections;

public class HandView : MonoBehaviour{

	ArrayList ary_card = new ArrayList();
	void Start(){
		addCard (CardType.Club, 10);
	}

	void Update(){

	}

	public void addCard( CardType ct, int id){
		GameObject c = (GameObject)Instantiate (PrefabSource.Card, transform.position, transform.rotation);

		c.transform.parent = this.transform;
		c.GetComponent<CardView> ().init (ct, id);
		ary_card.Add (c);
	}

	void replaceCard(){

	}
}

