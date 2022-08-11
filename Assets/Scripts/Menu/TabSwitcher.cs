using Arkanoid.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Menu
{
    public class TabSwitcher : MonoBehaviour, IExitTransitionHandler
    {
        [SerializeField] private GameObject[] tabs;

        [SerializeField] private ScrollRect scrollRect;

        private int currentTab;

        public void SwitchToTabOnClick(int tabIndex)
        {
            currentTab = tabIndex;
            Transition.Instance.Make(0.5f, this);
        }

        private void EnableTab(int index)
        {
            DisableAll();

            tabs[index].SetActive(true);

            scrollRect.verticalNormalizedPosition = 0;
        }

        private void DisableAll()
        {
            foreach (var i in tabs)
            {
                i.SetActive(false);
            }
        }

        public void TransitionHandle() => EnableTab(currentTab);
    }
}
