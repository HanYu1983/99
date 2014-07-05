using UnityEngine;
using System.Collections;

public class HandView : MonoBehaviour{

	public GameObject prefabCard;
	public GameObject playPage;
	public int playerId;

	GameObject _currentFocusCardView = null;
	int _currentFocusId = 999;
	float _oldY;
	float _choiseY;
	float _normalY;
	Vector3 _oldScale;
	Vector3 _zoomInScale = new Vector3 (1.2f, 1.2f, 1.2f);
	Vector3 _zoomOutScale = new Vector3 (1, 1, 1);
	ArrayList _ary_card = new ArrayList();

	public void addCard( ICard cardModel ){
		GameObject c = (GameObject)Instantiate (prefabCard, this.transform.position, this.transform.rotation);

		c.transform.parent = this.transform;
		c.GetComponent<CardViewConfig> ().cardModel = cardModel;
		c.name = "CardView";
		_ary_card.Add (c);
		replaceCard ();
	}

	public bool hasCard( CardView view ){
		return _ary_card.IndexOf (view) != -1;
	}

	public void subCard( GameObject card ){
		_ary_card.Remove (card);
		replaceCard ();
	}

	public void moveCardByBorder( float moveY ){
		_choiseY = moveY + _normalY;
	}

	public void focusCardByBorderPer( float per ){
		_currentFocusId = (int)(per * _ary_card.Count + _ary_card.Count / 2);
		if (_currentFocusId < 0)	_currentFocusId = 0;
		else if( _currentFocusId > _ary_card.Count - 1 )	_currentFocusId = _ary_card.Count - 1;
	}

	public void releaseCardByBorder( float moveY ){
		if (moveY > 0)	playPage.GetComponent<PlayPage> ().SendCard ((int)EnumEntityID.Player1, _currentFocusCardView);
		_currentFocusId = 999;
		_currentFocusCardView = null;
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
			tx = i * 300 / ( _ary_card.Count );
			ty = Mathf.Abs( i - _ary_card.Count / 2 ) * -20;
			tr = -(( i - _ary_card.Count / 2 ) * 10f );
			c.transform.localPosition = new Vector3( tx / 100, ty / 100, c.transform.localPosition.z );
			c.transform.localRotation = Quaternion.Euler( new Vector3( 0, 0, tr ));

			/*
			iTween.MoveTo(c, iTween.Hash("x", tx / 100 + this.transform.position.x, 
			                             "y", ty / 100 + this.transform.position.y,
			                             "z", this.transform.position.z - i,
			                             "easeType", "spring", "loopType", "none", "delay", i * .1, "time", .5));
			                             */
			//iTween.FadeTo(c, iTween.Hash("alpha", 0, "time", 0));
			//iTween.FadeTo(c, iTween.Hash("alpha", 1, "time", 1, "delay", i *.1));
			//iTween.RotateBy( c, iTween.Hash("z", tr, "easeType", "spring", "loopType", "none", "delay", i * .1, "time", 1));
			_normalY = c.transform.position.y;
		}
	}

	void Update(){
		activeFocusAnimation ();
	}

	void activeFocusAnimation(){
		//if (_currentFocusId != 999) {
			for( int i = 0; i < _ary_card.Count; ++i ){
				GameObject cv = (GameObject)_ary_card[i];
				Vector3 targetScale;
				float targetY;
				_oldScale = cv.transform.localScale;
				_oldY = cv.transform.position.y;
				if( i == _currentFocusId ){
					targetScale = ( _zoomInScale - _oldScale ) * .2f;
					targetY = ( _choiseY - _oldY ) * .2f;
					_currentFocusCardView = cv;
				}else{
					targetScale = ( _zoomOutScale - _oldScale ) * .2f;
					targetY = ( _normalY - _oldY ) * .2f;
				}
				_oldScale += targetScale;
				_oldY+= targetY;
				cv.transform.localScale = _oldScale;
				cv.transform.position = new Vector3( 	cv.transform.position.x,
				                                    	_oldY,
				                                   		cv.transform.position.z );
			}
		//}
	}
}

