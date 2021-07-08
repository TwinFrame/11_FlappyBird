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


	private void Awake()
	{
		_body.color = _main;
		_hatDown.color = _main;
		_hatUp.color = _main;

		_bodyShadow.color = _shadow;
		_hatDownShadow.color = _shadow;
		_hatUpShadow.color = _shadow;
	}
}
