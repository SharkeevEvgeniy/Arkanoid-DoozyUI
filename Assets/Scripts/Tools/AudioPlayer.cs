using UnityEngine;

namespace Arkanoid.Tools
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance { get; private set; } = null;

        private AudioSource audioSource = null;
        [SerializeField] private AudioClip[] clips;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClips clip) => audioSource.PlayOneShot(clips[(int)clip]);

        public void Stop() => audioSource.Stop();

        public void Play() => audioSource.Play();
    }
}
