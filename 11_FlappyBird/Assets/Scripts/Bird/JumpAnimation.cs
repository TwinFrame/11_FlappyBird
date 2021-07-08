using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class JumpAnimation : MonoBehaviour
{
	[SerializeField] private BirdMover _birdMover;

	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnEnable()
	{
		_birdMover.Jump += OnJump;
	}

	private void OnDisable()
	{
		_birdMover.Jump -= OnJump;
	}

	public void OnJump()
	{
		_animator.SetTrigger("Jump");
	}
}
