using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
	[SerializeField] private Color _color;
	[Header("Parts")]
	[SerializeField] private SpriteRenderer _stroke;
	[SerializeField] private SpriteRenderer _fill;

	private bool _isFill = true;

	public bool IsFill => _isFill;

	private void Awake()
	{
		_fill.color = _color;
	}

	public void EmptyHeart()
	{
		_isFill = false;
		_fill.gameObject.SetActive(false);
	}

	public void FillHeart()
	{
		_isFill = true;
		_fill.gameObject.SetActive(true);
	}
}
