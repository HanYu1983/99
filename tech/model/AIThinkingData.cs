using UnityEngine;
using System.Collections;
using System.Linq;

public class AIThinkingData : MonoBehaviour
{
	IMatch _match;
	internal IMatch Match{ get { return _match; } set { _match = value; } }
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