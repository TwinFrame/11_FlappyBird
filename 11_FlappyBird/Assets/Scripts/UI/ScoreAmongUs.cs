using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAmongUs : Score
{
	protected override void SubscribeEvent()
	{
		_bird.AmongUsChanged += OnScoreChanged;
	}

	protected override void UnsubscribeEvent()
	{
		_bird.AmongUsChanged -= OnScoreChanged;
	}
}
