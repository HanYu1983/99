using UnityEngine;
using System.Collections;

public interface ICardAbilityReceiver
{
	IDeckPlayer CardOwner{ get; }
	Direction Direction{ get; set; }
	void AddNumber(int number);
	void ControlNumber(int number, IDeckPlayer owner);
	void AssignPlayer(IDeckPlayer owner);
}