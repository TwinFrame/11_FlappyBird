using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSetterColor : MonoBehaviour
{
	[Header("Colors")]
	[SerializeField] private Color _main;
	[SerializeField] private Color _shadow;
	[SerializeField] private Color _secondary;

	[Header("Parts Fill")]
	[SerializeField] private SpriteRenderer _body;
	[SerializeField] private SpriteRenderer _hatUp;
	[SerializeField] private SpriteRenderer _hatDown;

	[Header("Parts Shadow")]
	[SerializeField] private SpriteRenderer _bodyShadow;
	[SerializeField] private SpriteRenderer _hatUpShadow;
	[SerializeField] private SpriteRenderer _hatDownShadow;

	private Color _previousColor;
	private float _timeToChangeColor = 2f;
	private float _currentTimeToChangeColor;

	private Coroutine ChangeCurrentColorJob;


	private void Awake()
	{
		ResetColor();
	}

	public void ResetColor()
	{
		if (ChangeCurrentColorJob != null)
			StopCoroutine(ChangeCurrentColorJob);

		SetFillColor(_main);

		SetShadowColor(_shadow);

		_previousColor = _main;
	}

	public void ChangeCurrentColor(Color color)
	{
		_previousColor = _body.color;

		if (ChangeCurrentColorJob != null)
			StopCoroutine(ChangeCurrentColorJob);

		ChangeCurrentColorJob = StartCoroutine(OnChangeCurrentColor(color));
	}

	private IEnumerator OnChangeCurrentColor(Color color)
	{
		_currentTimeToChangeColor = 0;

		while (_currentTimeToChangeColor <= _timeToChangeColor)
		{
			_currentTimeToChangeColor += Time.deltaTime;

			float _normalizeCurrentTime = _currentTimeToChangeColor / _timeToChangeColor;

			Debug.Log(_normalizeCurrentTime);

			Color currentColor = Color.Lerp(_previousColor, color, _normalizeCurrentTime);

			SetFillColor(currentColor);

			yield return null;
		}

	}

	private void SetFillColor(Color color)
	{
		_body.color = color;
		_hatDown.color = color;
		_hatUp.color = color;
	}

	private void SetShadowColor(Color color)
	{
		_bodyShadow.color = color;
		_hatDownShadow.color = color;
		_hatUpShadow.color = color;
	}
}
