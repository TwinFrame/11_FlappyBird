using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
	[SerializeField] protected CanvasGroup CanvasGroup;
	[SerializeField] protected Button Button;
	[SerializeField] protected Button ExitButton;

	private void OnEnable()
	{
		Button.onClick.AddListener(OnButtonClick);
		ExitButton.onClick.AddListener(OnExitButtonClick);
	}

	private void OnDisable()
	{
		Button.onClick.RemoveListener(OnButtonClick);
		ExitButton.onClick.RemoveListener(OnExitButtonClick);
	}

	public void Close()
	{
		CanvasGroup.alpha = 0;
		CanvasGroup.blocksRaycasts = false;
		CanvasGroup.interactable = false;
		Button.interactable = false;
		ExitButton.interactable = false;
	}

	public void Open()
	{
		CanvasGroup.alpha = 1;
		CanvasGroup.blocksRaycasts = true;
		CanvasGroup.interactable = true;
		Button.interactable = true;
		ExitButton.interactable = true;
	}

	public void OnExitButtonClick()
	{
		Application.Quit();
	}

	protected abstract void OnButtonClick();
}
