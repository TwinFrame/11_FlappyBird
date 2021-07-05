using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
	public event UnityAction RestartButtonClick;

	public override void Close()
	{
		Debug.Log("Close GameOverScreen");
		CanvasGroup.alpha = 0;
		CanvasGroup.interactable = false;
		Button.interactable = false;
		ExitButton.interactable = false;
	}

	public override void Open()
	{
		CanvasGroup.alpha = 1;
		CanvasGroup.interactable = true;
		Button.interactable = true;
		ExitButton.interactable = true;
	}

	protected override void OnButtonClick()
	{
		RestartButtonClick?.Invoke();
	}
}
