using UnityEngine;
using System.Collections;

public interface IModelDelegate
{
	void onValueChanged(IModel sender);
}