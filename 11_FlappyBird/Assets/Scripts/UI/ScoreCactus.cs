using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCactus : Score
{
	protected override void SubscribeEvent()
	{
		_bird.ScoreChanged += OnScoreChanged;
	}

	protected override void UnsubscribeEvent()
	{
		_bird.ScoreChanged -= OnScoreChanged;
	}
}
