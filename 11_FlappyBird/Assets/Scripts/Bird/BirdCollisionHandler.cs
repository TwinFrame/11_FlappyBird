using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Bird))]

public class BirdCollisionHandler : MonoBehaviour
{
	private Bird _bird;

	private void Start()
	{
		_bird = GetComponent<Bird>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Enemy enemy))
		{
			if (!_bird.TryTakeHeart())
			{
				_bird.Die();
			}

			return;
		}

		if (collision.TryGetComponent(out HeartThing heartThing))
		{
			Destroy(heartThing.gameObject);

			_bird.TryAddHeart();

			return;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out ScoreZone scoreZone))
			_bird.IncreaseScore(scoreZone.Reward);
	}
}
