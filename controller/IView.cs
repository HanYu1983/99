public interface IView
{
	void OpenTargetPage ( UIType pn);
	void CloseTargetPage( UIType pn );
	void AddCard( IDeck deck, IDeckPlayer player, ICard card );
	void PushCardToStack( IDeck deck, IDeckPlayer player, ICard card );
}

