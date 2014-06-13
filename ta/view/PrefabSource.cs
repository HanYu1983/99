using UnityEngine;
using System.Collections;

public class PrefabSource
{
	public static GameObject MainPage = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/MainPage.prefab" ) ;
	public static GameObject PlayPage = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/PlayPage.prefab" ) ;
	public static GameObject RankPage = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/RankPage.prefab" ) ;
	public static GameObject ResultPage = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/ResultPage.prefab" ) ;
	public static GameObject PausePanel = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/PausePanel.prefab" ) ;
	public static GameObject Card = Resources.LoadAssetAtPath<GameObject> ( "Assets/gitAssets/ta/prefab/sub/Card.prefab" ) ;
}

