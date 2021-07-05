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

	public void OnExitButtonClick()
	{
		Application.Quit();
	}

	protected abstract void OnButtonClick();

	public abstract void Open();

	public abstract void Close();
}
