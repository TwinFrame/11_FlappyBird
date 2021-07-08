using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
	[SerializeField] protected Bird _bird;
	[SerializeField] private TMP_Text _score;

	private void OnEnable()
	{
		SubscribeEvent();
	}

	private void OnDisable()
	{
		UnsubscribeEvent();
	}

	protected abstract void SubscribeEvent();
	protected abstract void UnsubscribeEvent();


	protected void OnScoreChanged(int score)
	{
		_score.text = score.ToString();
	}
}
