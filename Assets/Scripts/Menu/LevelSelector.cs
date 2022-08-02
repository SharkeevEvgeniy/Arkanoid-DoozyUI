using UnityEngine;
using UnityEngine.UI;
using Arkanoid.Tools;
using Arkanoid.Common;

namespace Arkanoid.Menu
{
    public class LevelSelector : MonoBehaviour, IExitTransitionHandler
    {
        [SerializeField] private GameObject dialogPanel;

        [SerializeField] private Image[] levelImages;
        [SerializeField] private Sprite currentLevelSprite;

        private int selectedLevel = 1;

        [SerializeField] private UserPrefs userPrefs;

        private SceneLoader sceneLoader = null;

        private void OnEnable() => ShowCurrentLevel();

        private void ShowCurrentLevel()
        {
            levelImages[userPrefs.GetCurrentLevel() - 1].sprite = currentLevelSprite;
        }

        public void SelectLevel(int index)
        {
            if (userPrefs.GetCurrentLevel() < index)
                return;

            if (dialogPanel.activeSelf == false)
            {
                dialogPanel.SetActive(true);
            }

            selectedLevel = index;
        }

        public void Play()
        {
            Transition.Instance.Make(0.5f, this);
            sceneLoader = new SceneLoader();
            sceneLoader.LoadScene(selectedLevel);
        }

        public void TransitionHandle()
        {
            sceneLoader.AllowLoadScene();
        }
    }
}
