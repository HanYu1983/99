using UnityEngine;
using System.Collections;

public interface IMainPageDelegate{
	void onBtnStartClick(object sender);
	void onBtnRankClick(object sender);
	void onBtnQuitClick(object sender);
}