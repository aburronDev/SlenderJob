using UnityEngine;

namespace aburron.Controllers
{
	public class PagesController : MonoBehaviour
	{
		[SerializeField] private Sprite[] pages;
		[SerializeField] private SpriteRenderer[] pagesRend;

		private void Awake()
		{
			Events.GameEvents.onPageInteraction += ChangePageSprite;
		}

		private void ChangePageSprite(int pageIndex)
		{
			if (pageIndex >= 8)
				return;

			for (int i = 0; i < pages.Length; ++i)
				pagesRend[i].sprite = pages[pageIndex];
		}

		private void OnDestroy()
		{
			Events.GameEvents.onPageInteraction -= ChangePageSprite;
		}
	}
}