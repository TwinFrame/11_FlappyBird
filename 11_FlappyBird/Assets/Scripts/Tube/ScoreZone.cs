using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
	[SerializeField] private int _reward;

	public int Reward => _reward;
}
