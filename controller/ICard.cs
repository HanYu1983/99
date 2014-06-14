public interface ICard
{
	CardType Type { get; }
	CardAbility Ability{ get; }
	int Id { get; }
	int Number { get; }	
	void InvokeAbility (ICardAbilityReceiver receiver);
}