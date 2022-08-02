using UnityEngine;
using UnityEngine.UI;
using Arkanoid.Common;
using Arkanoid.Tools;

namespace Arkanoid.Menu
{
    public class UserSettings : MonoBehaviour
    {
        [SerializeField] private Image sound;
        [SerializeField] private Image vibration;
        [SerializeField] private Sprite[] soundSprites;
        [SerializeField] private Sprite[] vibrationSprites;

        [SerializeField] private UserPrefs userPrefs;

        private void Start() => Initialize();

        private void Initialize()
        {
            UpdateIcons();

            UpdateAudioPlayer();
        }

        private void UpdateAudioPlayer()
        {
            if (userPrefs.UseSound())
            {
                AudioPlayer.Instance.Play();
            }
            else
            {
                AudioPlayer.Instance.Stop();
            }
        }

        private void UpdateIcons()
        {
            sound.sprite = soundSprites[userPrefs.UseSound() ? 0 : 1];
            vibration.sprite = vibrationSprites[userPrefs.UseVibration() ? 0 : 1];
        }

        public void SwitchSoundOnClick()
        {
            bool useSound = !userPrefs.UseSound();
            userPrefs.UseSound(useSound);
            UpdateAudioPlayer();

            UpdateIcons();
        }

        public void SwitchVibrationOnClick()
        {
            bool useVibration = !userPrefs.UseVibration();
            userPrefs.UseVibration(useVibration);

            UpdateIcons();
        }
    }
}
