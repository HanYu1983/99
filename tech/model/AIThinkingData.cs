using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AIThinkingData
{
	IMatch _match;
	internal IMatch Match{ get { return _match; } set { _match = value; } }
	internal bool HasAssignTargetAbility(IPlayer player){
		return player.Cards.ToList ().Exists ((ICard card) => { return card.Ability == CardAbility.AssignPlayer; });
	}
	internal bool WillOutOf99(IPlayer player){
		List<ICard> minNumberPlayers = player.Cards.ToList ().FindAll ((ICard card) => {
			return card.Ability == CardAbility.Unknown;
		}).OrderBy ((ICard card) => {
			return card.Number;
		}).ToList();
		if (minNumberPlayers.Count > 0) {
			bool willOutOf99 = _match.GameState.CurrentNumber + minNumberPlayers.First().Number > 99;
			return willOutOf99;
		} else {
			return false;
		}
	}
	internal IPlayer LeastCardOfPlayer(IPlayer currentPlayer){
		return _match.Players.ToList().FindAll((IOption<IPlayer> op)=>{
					return op.Identity != currentPlayer.EntityID && !op.IsDeleted;
				}).Select((IOption<IPlayer> op)=>{
					return op.Instance;
				}).ToList().OrderBy ((IPlayer p) => {
					return p.Cards.Count;
				}).First ();
	}
	internal float NumberRisk(){
		return _match.GameState.CurrentNumber/ 99.0f;
	}
	internal float CardCountRisk(IPlayer player){
		if (player.Cards.Count > 4) {
			return 0;
		}else {
			return 1 - (player.Cards.Count/ 4.0f);
		}
	}
	internal float CardStrength(IPlayer player){
		int maxpoint = 5;
		int skillCardNumber = player.Cards.ToList ().FindAll ((ICard card) => {
			return card.Ability != CardAbility.Unknown;
		}).Count;
		return skillCardNumber > maxpoint ? 1 : skillCardNumber / (float)maxpoint;
	}
	internal IPlayer TheFewestCardPlayer{ 
		get{
			return _match.Players.ToList()
				.FindAll(obj=>!obj.IsDeleted)
				.Select(obj=>obj.Instance)
				.OrderByDescending((IPlayer p)=>{
					return p.Cards.Count;
				}).First();
		}
	}

}