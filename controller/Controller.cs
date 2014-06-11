using UnityEngine;
using System.Collections;
using System.Linq;
public class Controller : ReceiverMono, IMainPageDelegate
{
	public IView view;

	public void onBtnStartClick(object sender){
		view.closeTargetPage ("mainPage");
		view.openTargetPage ("playPage");
	}

	public void onBtnRankClick(object sender){
		view.closeTargetPage ("mainPage");
		view.openTargetPage ("rankPage");
	}

	public void onBtnQuitClick(object sender){

	}
}

