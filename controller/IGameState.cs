using UnityEngine;
using System.Collections;

public interface IGameState
{
	IDeck CenterDeck{ get; set; }
	int CurrentNumber{ get; }
	Direction CurrentDirection{ get; }
}