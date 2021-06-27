using UnityEngine;
using TMPro;

namespace aburron.UI
{
	using Events;
	using Utils;

	public class PagesUI : MonoBehaviour
	{

		[SerializeField] private float pageAmountTextVisibilityInScreen = 3.0f;
		[Space]
		[SerializeField, Editor.Required] private GameObject pagePanel;
		[SerializeField, Editor.Required] private GameObject pageAmountPanel;
		[SerializeField, Editor.Required] private TextMeshProUGUI pageAmountText;
		[SerializeField, Editor.Required] private GameObject helpText;

		private int internalPageAmount;

		private void Awake()
		{
			GameEvents.onPageInteraction += PageInteractionEventUI;
			GameEvents.onPageTaken += PageTakenEventUI;
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

			AbuTimer.Play(pageAmountTextVisibilityInScreen, () => pageAmountPanel.SetActive(false));
		}

		private void OnDestroy()
		{
			Events.GameEvents.onPageInteraction -= PageInteractionEventUI;
			Events.GameEvents.onPageTaken -= PageTakenEventUI;
		}
	}
}