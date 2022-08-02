using UnityEngine;

namespace Arkanoid.Common
{
    public class UserPrefs : MonoBehaviour
    {
        private int currentLevel;
        private bool useSound;
        private bool useVibration;

        void Start() => Initialize();

        private void Initialize()
        {
            if (PlayerPrefs.HasKey("currentLevel") == true)
            {
                currentLevel = PlayerPrefs.GetInt("currentLevel");
                int useSound = PlayerPrefs.GetInt("useSound");
                this.useSound = useSound == 1 ? true : false;
                int useVibration = PlayerPrefs.GetInt("useVibration");
                this.useVibration = useVibration == 1 ? true : false;
            }
            else
            {
                currentLevel = 1;
                useSound = true;
                useVibration = true;
                PlayerPrefs.SetInt("currentLevel", currentLevel);
                PlayerPrefs.SetInt("useSound", 1);
                PlayerPrefs.SetInt("useVibration", 1);
            }
        }

        public void SetCurrentLevel(int currentLevel)
        {
            this.currentLevel = currentLevel;
            PlayerPrefs.SetInt("currentLevel", currentLevel);
        }

        public int GetCurrentLevel() => currentLevel;

        public void UseSound(bool value)
        {
            useSound = value;
            PlayerPrefs.SetInt("useSound", useSound ? 1 : 0);
        }

        public bool UseSound() => useSound;

        public void UseVibration(bool value)
        {
            useVibration = value;
            PlayerPrefs.SetInt("useVibration", useVibration ? 1 : 0);
        }

        public bool UseVibration() => useVibration;
    }
}
