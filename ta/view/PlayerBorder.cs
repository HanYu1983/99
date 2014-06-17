using UnityEngine;
using System.Collections;

public class PlayerBorder : MonoBehaviour {

	public GameObject go_playerHand;

	Vector3 _mouseDownPosition;
	Vector3 _currentMousePoisition;
	private float _borderMax = 4;
	private bool _mouseDown = false;

	void Update(){
		if (_mouseDown) {
			_currentMousePoisition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float per = _currentMousePoisition.x / _borderMax;
			go_playerHand.GetComponent<HandView>().focusCardByBorderPer( per );
			go_playerHand.GetComponent<HandView>().moveCardByBorder( _currentMousePoisition.y - _mouseDownPosition.y );
		}
	}

	void onTouchConsumerEventMouseDown( TouchEvent te ){
		_mouseDown = true;
		_mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void onTouchConsumerEventMouseUp( TouchEvent te ){
		_mouseDown = false;
		go_playerHand.GetComponent<HandView> ().releaseCardByBorder ( _currentMousePoisition.y );
	}
}
