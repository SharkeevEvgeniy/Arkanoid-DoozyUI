using UnityEngine;
using Arkanoid.Tools;

namespace Arkanoid.Level
{
    public class Ball : BallBase
    {
        private VibratorWrapper vibratorWrapper = null;

        private void Start() => Initialize();

        private void Initialize()
        {
            direction = new Vector2(Random.Range(-1f, 1f), 1f);
            vibratorWrapper = new VibratorWrapper(userPrefs);
            session.AddPauseHandler(this);
        }

        private void Update()
        {
            if (isPause == true)
                return;

            Move();
            velocity = startVelocity + changeVelocityCurve.Evaluate((Time.time - startTime) / timeToFullVelocity) * velocityMuiltplier;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Reflection"))
            {
                direction = Vector2.Reflect(direction, collision.contacts[0].normal);

                if (collision.gameObject.CompareTag("Block"))
                {
                    collision.gameObject.SetActive(false);
                    AudioPlayer.Instance.PlayOneShot(AudioClips.Destroy);
                    vibratorWrapper.Vibrate(15);
                    session.DecreaseBlockCount();
                }
                else if (collision.gameObject.CompareTag("Lose"))
                {
                    session.Lose();
                }
            }
        }
    }
}
