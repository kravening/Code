using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboSystem : MonoBehaviour {
	[SerializeField]private int currentCombo;
	[SerializeField]private float comboFallOffTime = 1;
	private float TimeStamp;

	private int highestCombo;
	
	void Update () {
		if (Time.time >= TimeStamp && currentCombo > 0) {
			DecreaseCombo ();
		}
	}

	//Private functions
	private void DecreaseCombo(){
		currentCombo--;
		UpdateComboTime ();
	}
	private void UpdateComboTime(){
		TimeStamp = Time.time + comboFallOffTime;
	}

	//Public Functions
	public int getCurrentCombo(){
		return currentCombo;
	}
	public int getHighestCombo(){
		return highestCombo;
	}

	
	public void IncreaseCombo(){
		currentCombo++;
		if (currentCombo > highestCombo) {
			highestCombo = currentCombo;
		}
		UpdateComboTime ();
	}


}
