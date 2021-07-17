using UnityEngine;
using TMPro;

namespace aburron.UI
{
	using GameEvents = Events.GameEvents;

	public class PagesUI : MonoBehaviour
	{
		[SerializeField] private float pageAmountTextVisibilityInScreen = 3.0f;
		[Space]
		[SerializeField, Editor.Required] private GameObject pagePanel;
		[SerializeField, Editor.Required] private GameObject pageAmountPanel;
		[SerializeField, Editor.Required] private TextMeshProUGUI pageAmountText;
		[SerializeField, Editor.Required] private GameObject endPanel;
		[SerializeField, Editor.Required] private GameObject helpText;

		private int internalPageAmount;

		private void Awake()
		{
			GameEvents.onPageInteraction += PageInteractionEventUI;
			GameEvents.onPageTaken += PageTakenEventUI;
			GameEvents.onExitDoor += EndPanelEventUI;
		}

		private void PageInteractionEventUI(int pageAmount)
		{
			internalPageAmount = pageAmount;

			pagePanel.SetActive(true);

			if (internalPageAmount >= 8)
				pageAmountText.text = $"pages {pageAmount}/8\nGo to the exit";
			else
				pageAmountText.text = $"pages {pageAmount}/8";

			helpText.SetActive(true);
		}

		private void PageTakenEventUI()
		{
			pagePanel.SetActive(false);
			pageAmountPanel.SetActive(true);
			helpText.SetActive(false);

			if (internalPageAmount == 1)
				GameEvents.onFirstPageTaken?.Invoke();

			if (internalPageAmount >= 8)
				GameEvents.onAllPagesTaken?.Invoke();

			Utils.AbuTimer.Play(pageAmountTextVisibilityInScreen, () => pageAmountPanel.SetActive(false));
		}

		private void EndPanelEventUI()
		{
			endPanel.SetActive(true);
		}

		private void OnDestroy()
		{
			GameEvents.onPageInteraction -= PageInteractionEventUI;
			GameEvents.onPageTaken -= PageTakenEventUI;
			GameEvents.onExitDoor -= EndPanelEventUI;
		}
	}
}