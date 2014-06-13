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
	}

	public IList<ICard> Cards{ get { return _cards; } }
	public bool IsEmpty { get{ return _cards.Count == 0; } }

	public void Shuffle(){
		/*
		_cards.Sort ((ICard left, ICard right) => {
			return 1;
		});
		*/
	}

	public IList<ICard> Peek(int amount){
		int count = Mathf.Min (_cards.Count, amount);
		return _cards.GetRange( _cards.Count-count, count );
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
			_cards.Insert(index, player.RemoveCard (card));
		}
	}
								
	public void InsertBottom(IDeckPlayer player, ICard card){
		if(player.IsContainCard(card))
			_cards.Insert ( 0, player.RemoveCard (card));
	}

	public static Card SpadeA = new Card(CardType.Spade, 1, 0);
	public static Card Spade2 = new Card(CardType.Spade, 2, 1);
	public static Card Spade3 = new Card(CardType.Spade, 3, 2);
	public static Card Spade4 = new Card(CardType.Spade, 4, 3);
	public static Card Spade5 = new Card(CardType.Spade, 5, 4);
	public static Card Spade6 = new Card(CardType.Spade, 6, 5);
	public static Card Spade7 = new Card(CardType.Spade, 7, 6);
	public static Card Spade8 = new Card(CardType.Spade, 8, 7);
	public static Card Spade9 = new Card(CardType.Spade, 9, 8);
	public static Card Spade10 = new Card(CardType.Spade, 10, 9);
	public static Card SpadeJ = new Card(CardType.Spade, 11, 10);
	public static Card SpadeQ = new Card(CardType.Spade, 12, 11);
	public static Card SpadeK = new Card(CardType.Spade, 13, 12);
			
	public static Card HeartA = new Card(CardType.Heart, 1, 13);
	public static Card Heart2 = new Card(CardType.Heart, 2, 14);
	public static Card Heart3 = new Card(CardType.Heart, 3, 15);
	public static Card Heart4 = new Card(CardType.Heart, 4, 16);
	public static Card Heart5 = new Card(CardType.Heart, 5, 17);
	public static Card Heart6 = new Card(CardType.Heart, 6, 18);
	public static Card Heart7 = new Card(CardType.Heart, 7, 19);
	public static Card Heart8 = new Card(CardType.Heart, 8, 20);
	public static Card Heart9 = new Card(CardType.Heart, 9, 21);
	public static Card Heart10 = new  Card(CardType.Heart, 10, 22);
	public static Card HeartJ = new Card(CardType.Heart, 11, 23);
	public static Card HeartQ = new Card(CardType.Heart, 12, 24);
	public static Card HeartK = new Card(CardType.Heart, 13, 25);
			
	public static Card DiamondA = new Card(CardType.Diamond, 1, 26);
	public static Card Diamond2 = new Card(CardType.Diamond, 2, 27);
	public static Card Diamond3 = new Card(CardType.Diamond, 3, 28);
	public static Card Diamond4 = new Card(CardType.Diamond, 4, 29);
	public static Card Diamond5 = new Card(CardType.Diamond, 5, 30);
	public static Card Diamond6 = new Card(CardType.Diamond, 6, 31);
	public static Card Diamond7 = new Card(CardType.Diamond, 7, 32);
	public static Card Diamond8 = new Card(CardType.Diamond, 8, 33);
	public static Card Diamond9 = new Card(CardType.Diamond, 9, 34);
	public static Card Diamond10 = new Card(CardType.Diamond, 10,35);
	public static Card DiamondJ = new Card(CardType.Diamond, 11, 36);
	public static Card DiamondQ = new Card(CardType.Diamond, 12, 37);
	public static Card DiamondK = new Card(CardType.Diamond, 13, 38);
			
	public static Card ClubA = new Card(CardType.Club, 1, 39);
	public static Card Club2 = new Card(CardType.Club, 2, 40);
	public static Card Club3 = new Card(CardType.Club, 3, 41);
	public static Card Club4 = new Card(CardType.Club, 4, 42);
	public static Card Club5 = new Card(CardType.Club, 5, 43);
	public static Card Club6 = new Card(CardType.Club, 6, 44);
	public static Card Club7 = new Card(CardType.Club, 7, 45);
	public static Card Club8 = new Card(CardType.Club, 8, 46);
	public static Card Club9 = new Card(CardType.Club, 9, 47);
	public static Card Club10 = new Card(CardType.Club, 10, 48);
	public static Card ClubJ = new Card(CardType.Club, 11, 49);
	public static Card ClubQ = new Card(CardType.Club, 12, 50);
	public static Card ClubK = new Card(CardType.Club, 13, 51);


}

