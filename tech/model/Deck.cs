using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Deck : IDeck
{
	List<ICard> _cards;
	
	public Deck(){
		_cards = new List<ICard>{
			SpadeA, Spade2, Spade3, Spade4, Spade5, Spade6, Spade7, Spade8, Spade9, Spade10, SpadeJ, SpadeQ, SpadeK,
			HeartA, Heart2, Heart3, Heart4, Heart5, Heart6, Heart7, Heart8, Heart9, Heart10, HeartJ, HeartQ, HeartK,
			DiamondA, Diamond2, Diamond3, Diamond4, Diamond5, Diamond6, Diamond7, Diamond8, Diamond9, Diamond10, DiamondJ, DiamondQ, DiamondK,
			ClubA, Club2, Club3, Club4, Club5, Club6, Club7, Club8, Club9, Club10, ClubJ, ClubQ, ClubK
		};
		this.Shuffle ();
	}

	public List<ICard> Cards{ get { return _cards; } }
	public bool IsEmpty { get{ return _cards.Count == 0; } }

	public void Shuffle(){
		_cards.Sort ((ICard left, ICard right) => {
			return 1;
		});
	}

	public List<ICard> Peek(int amount){
		int count = Mathf.Max (_cards.Count, amount);
		return _cards.GetRange( _cards.Count-1-count, _cards.Count-1 );
	}
			
	public void Draw(IDeckPlayer player){
		if (!IsEmpty) {
			ICard card = _cards [_cards.Count - 1];
			player.AddCard (card);
			_cards.Remove (card);
		}
	}

	public void Push(IDeckPlayer player, ICard card){
		if( player.IsContainCard(card) )
			_cards.Add (player.RemoveCard (card));
	}
							
	public void Insert(IDeckPlayer player, ICard card, int index){
		if (player.IsContainCard (card)) {
			_cards.Insert(index, card);
		}
	}
								
	public void InsertBottom(IDeckPlayer player, ICard card){
		if(player.IsContainCard(card))
			_cards.Insert ( 0, player.RemoveCard (card));
	}

	public Card SpadeA = new Card(CardType.Spade, 0);
	public Card Spade2 = new Card(CardType.Spade, 1);
	public Card Spade3 = new Card(CardType.Spade, 2);
	public Card Spade4 = new Card(CardType.Spade, 3);
	public Card Spade5 = new Card(CardType.Spade, 4);
	public Card Spade6 = new Card(CardType.Spade, 5);
	public Card Spade7 = new Card(CardType.Spade, 6);
	public Card Spade8 = new Card(CardType.Spade, 7);
	public Card Spade9 = new Card(CardType.Spade, 8);
	public Card Spade10 = new Card(CardType.Spade, 9);
	public Card SpadeJ = new Card(CardType.Spade, 10);
	public Card SpadeQ = new Card(CardType.Spade, 11);
	public Card SpadeK = new Card(CardType.Spade, 12);
			
	public Card HeartA = new Card(CardType.Heart, 13);
	public Card Heart2 = new Card(CardType.Heart, 14);
	public Card Heart3 = new Card(CardType.Heart, 15);
	public Card Heart4 = new Card(CardType.Heart, 16);
	public Card Heart5 = new Card(CardType.Heart, 17);
	public Card Heart6 = new Card(CardType.Heart, 18);
	public Card Heart7 = new Card(CardType.Heart, 19);
	public Card Heart8 = new Card(CardType.Heart, 20);
	public Card Heart9 = new Card(CardType.Heart, 21);
	public Card Heart10 = new  Card(CardType.Heart, 22);
	public Card HeartJ = new Card(CardType.Heart, 23);
	public Card HeartQ = new Card(CardType.Heart, 24);
	public Card HeartK = new Card(CardType.Heart, 25);
			
	public Card DiamondA = new Card(CardType.Diamond, 26);
	public Card Diamond2 = new Card(CardType.Diamond, 27);
	public Card Diamond3 = new Card(CardType.Diamond, 28);
	public Card Diamond4 = new Card(CardType.Diamond, 29);
	public Card Diamond5 = new Card(CardType.Diamond, 30);
	public Card Diamond6 = new Card(CardType.Diamond, 31);
	public Card Diamond7 = new Card(CardType.Diamond, 32);
	public Card Diamond8 = new Card(CardType.Diamond, 33);
	public Card Diamond9 = new Card(CardType.Diamond, 34);
	public Card Diamond10 = new Card(CardType.Diamond, 35);
	public Card DiamondJ = new Card(CardType.Diamond, 36);
	public Card DiamondQ = new Card(CardType.Diamond, 37);
	public Card DiamondK = new Card(CardType.Diamond, 38);
			
	public Card ClubA = new Card(CardType.Club, 39);
	public Card Club2 = new Card(CardType.Club, 40);
	public Card Club3 = new Card(CardType.Club, 41);
	public Card Club4 = new Card(CardType.Club, 42);
	public Card Club5 = new Card(CardType.Club, 43);
	public Card Club6 = new Card(CardType.Club, 44);
	public Card Club7 = new Card(CardType.Club, 45);
	public Card Club8 = new Card(CardType.Club, 46);
	public Card Club9 = new Card(CardType.Club, 47);
	public Card Club10 = new Card(CardType.Club, 48);
	public Card ClubJ = new Card(CardType.Club, 49);
	public Card ClubQ = new Card(CardType.Club, 50);
	public Card ClubK = new Card(CardType.Club, 51);


}

