﻿using UnityEngine;
using System.Collections;
using System.Linq;
public class MainPage : SenderMono {

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
			case "btn_start":
			Sender.Receivers.ToList ().ForEach (obj => {
				((IMainPageDelegate)obj).onMainPageBtnStartClick( this);
			});
			break;
			case "btn_rank":
			Sender.Receivers.ToList ().ForEach (obj => {
				((IMainPageDelegate)obj).onMainPageBtnRankClick(this);
			});
			break;
			case "btn_quit":
			Sender.Receivers.ToList ().ForEach (obj => {
				((IMainPageDelegate)obj).onMainPageBtnQuitClick(this);
			});
			break;
		}
	}

	void onTouchConsumerEventMouseUp(){

	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return receiver is IMainPageDelegate;
	}
}
