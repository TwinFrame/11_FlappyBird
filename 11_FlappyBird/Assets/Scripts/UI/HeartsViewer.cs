using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsViewer : MonoBehaviour
{
	[SerializeField] private Bird _bird;
	[SerializeField] private GameObject _container;
	[SerializeField] private HeartUI template;

	private void OnEnable()
	{
		_bird.ChangeHeart += InitHearts;
	}

	private void OnDisable()
	{
		_bird.ChangeHeart -= InitHearts;
	}

	private void InitHearts()
	{
		for (int i = 0; i < _container.transform.childCount; i++)
		{
			Destroy(_container.transform.GetChild(i).gameObject);
		}

		for (int i = 0; i < _bird.CurrentMaxNumberOfHeart; i++)
		{
			var heart = Instantiate(template, _container.transform);

			if (_bird.CurrentNumberOfHeart > i)
				heart.FillHeart();
			else
				heart.EmptyHeart();
		}
	}
}
