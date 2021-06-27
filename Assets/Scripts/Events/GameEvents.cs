using System;

namespace aburron.Events
{
	public static class GameEvents
	{
		public static Action<int> onPageInteraction;
		public static Action onPageTaken;
		public static Action onAllPagesTaken;
		public static Action onGameWon;
		public static Action onGameLost;
	}
}