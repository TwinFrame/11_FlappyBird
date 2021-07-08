using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdSetterColor))]

public class Bird : MonoBehaviour
{
	[SerializeField] private int _startingNumberOfHearts;
	[SerializeField] private int _maxNumberOfHearts;

	private BirdMover _mover;
	private BirdSetterColor _birdSetterColor;
	private int _score;
	private int _amongUs;
	private int _currentNumberOfHeart;
	private int _currentMaxNumberOfHeart;

	public int CurrentNumberOfHeart => _currentNumberOfHeart;
	public int CurrentMaxNumberOfHeart => _currentMaxNumberOfHeart;

	public int StartNumberOfHeart => _startingNumberOfHearts;

	public event UnityAction GameOver;
	public event UnityAction<int> ScoreChanged;
	public event UnityAction<int> AmongUsChanged;
	public event UnityAction ChangeHeart;

	private void Awake()
	{
		InitHearts();
	}

	private void Start()
	{
		_mover = GetComponent<BirdMover>();
		_birdSetterColor = GetComponent<BirdSetterColor>();

		_currentMaxNumberOfHeart = _startingNumberOfHearts;

		ChangeHeart?.Invoke();
	}

	public void IncreaseScore(int reward)
	{
		_score += reward;

		ScoreChanged?.Invoke(_score);
	}

	public bool TryTakeHeart()
	{
		if (_currentNumberOfHeart > 0)
		{
			if (--_currentNumberOfHeart == 0)
				return false;

			ChangeHeart?.Invoke();

			return true;
		}
		else
			return false;
	}

	public bool TryAddHeart()
	{
		if (_currentNumberOfHeart < _currentMaxNumberOfHeart)
		{
			_currentNumberOfHeart++;
			ChangeHeart?.Invoke();

			return true;
		}

		if (_currentNumberOfHeart >= _currentMaxNumberOfHeart && _currentNumberOfHeart < _maxNumberOfHearts)
		{
			_currentMaxNumberOfHeart++;
			_currentNumberOfHeart++;
			ChangeHeart?.Invoke();

			return true;
		}

		return false;
	}

	public bool TryAddAmongUs()
	{
		_amongUs++;

		AmongUsChanged?.Invoke(_amongUs);

		return true;
	}
	public bool TryChangeColor(Color color)
	{
		_birdSetterColor.ChangeCurrentColor(color);

		return true;
	}

	public void ResetPlayer()
	{
		_amongUs = 0;
		AmongUsChanged?.Invoke(_amongUs);

		_score = 0;
		ScoreChanged?.Invoke(_score);

		InitHearts();
		_currentMaxNumberOfHeart = _startingNumberOfHearts;
		ChangeHeart?.Invoke();

		_mover.ResetBird();
		_birdSetterColor.ResetColor();
	}

	public void Die()
	{
		ChangeHeart?.Invoke();

		GameOver?.Invoke();
	}

	private void InitHearts()
	{
		_currentNumberOfHeart = _startingNumberOfHearts;
	}
}
