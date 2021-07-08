using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private float _speed;
	[SerializeField] private float _tapForce = 10f;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _minRotationZ;
	[SerializeField] private float _maxRotationZ;

	private Rigidbody2D _rigidbody;
	private Quaternion _minRotation;
	private Quaternion _maxRotation;

	public event UnityAction Jump;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();

		_minRotation = Quaternion.Euler(0, 0, _minRotationZ);
		_maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

		ResetBird();
	}

	private void Update()
	{
		if (Time.timeScale == 0)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			Jump?.Invoke();

			_rigidbody.velocity = new Vector2(_speed, 0);

			_rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);

			transform.rotation = _maxRotation;
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
	}

	public void ResetBird()
	{
		_rigidbody.velocity = Vector2.zero;

		transform.position = _startPosition;
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
