using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSetterColor : MonoBehaviour
{
	[Header("Colors")]
	[SerializeField] private Color _main;
	[SerializeField] private Color _secondary;
	[Header("Parts")]
	[SerializeField] private SpriteRenderer _body;
	[SerializeField] private SpriteRenderer _leftLeg;
	[SerializeField] private SpriteRenderer _rightLeg;
	[SerializeField] private SpriteRenderer _upBeak;
	[SerializeField] private SpriteRenderer _downBeak;
	[SerializeField] private SpriteRenderer _eye;
	[SerializeField] private SpriteRenderer _pupil;
	[SerializeField] private SpriteRenderer _wing;

	private void Awake()
	{
		_body.color = _main;
		_leftLeg.color = _main;
		_rightLeg.color = _main;
		_pupil.color = _main;

		_upBeak.color = _secondary;
		_downBeak.color = _secondary;
		_eye.color = _secondary;
		_wing.color = _secondary;
	}
}
