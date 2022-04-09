using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndManager : MonoBehaviour
{
	[SerializeField]
	private TMP_Text soulsText;
	
	[SerializeField]
	private TMP_Text deathsText;


	private void Awake()
	{
		deathsText.SetText(string.Format("Only {0} slimeöös were harmed during this run", GameManager.deathCounter));
		soulsText.SetText(string.Format("You collected {0}/16 mägmöömömmös", GameManager.collectibles));
	}
}
