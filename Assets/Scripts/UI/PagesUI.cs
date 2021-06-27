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
		}

		private void PageTakenEventUI()
		{
			pagePanel.SetActive(false);
			pageAmountPanel.SetActive(true);

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