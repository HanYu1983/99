using UnityEngine;
using System.Collections;
using System.Linq;
public class PausePanel : SenderMono {

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
		case "btn_resume":
			Sender.Receivers.ToList ().ForEach (obj => {
				((IPausePanelDelegate)obj).onPausePanelBtnResumeClick( this );
			});
			break;
		case "btn_quit":
			Sender.Receivers.ToList ().ForEach (obj => {
				((IPausePanelDelegate)obj).onPausePanelBtnQuitClick( this );
			});
			break;
		}
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IPausePanelDelegate).IsAssignableFrom (receiver.GetType ());
	}
}
