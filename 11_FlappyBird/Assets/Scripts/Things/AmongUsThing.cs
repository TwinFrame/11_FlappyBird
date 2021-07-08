using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class AmongUsThing : Thing
{
	[SerializeField] private SpriteRenderer _fill;
	[SerializeField] private AmongUsColorPalette _colorPalette;

	private void OnEnable()
	{
		_fill.color = _colorPalette.ColorPalette[Random.Range(0, _colorPalette.ColorPalette.Count)];
	}

	public Color GetAmongUsColor()
	{
		return _fill.color;
	}
}
