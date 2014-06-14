using UnityEngine;
using System.Collections;

public class CardView : MonoBehaviour {

	TextMesh _txt_name;
	CardType _type;
	int _id;
	public CardType Type { get{ return _type; }}
	public int Id { get{ return _id; }}

	public void init( CardType type, int id){
		_txt_name = GetComponentInChildren<TextMesh> ();
		_type = type;
		_id = id;
		setCard (_type, _id);
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCard( CardType ct, int id ){
		Debug.Log (id);
		Debug.Log (_txt_name);
		_txt_name.text = getShowText (id);
	}

	string getShowText( int id ){
		switch (id) {
		case 0:return "A";
		case 1:return "2";
		case 2:return "3";
		case 3:return "4";
		case 4:return "5";
		case 5:return "6";
		case 6:return "7";
		case 7:return "8";
		case 8:return "9";
		case 9:return "10";
		case 10:return "J";
		case 11:return "Q";
		case 12:return "K";
		default:return "";
		}
	}
}
