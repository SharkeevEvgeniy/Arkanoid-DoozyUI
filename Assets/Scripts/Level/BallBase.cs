using System.Collections;
using UnityEngine;
using Arkanoid.Common;

namespace Arkanoid.Level
{
    public abstract class BallBase : MonoBehaviour, IPauseHandler
    {
        [SerializeField] protected UserPrefs userPrefs;
        [SerializeField] protected Session.Session session;

        protected Vector2 direction;
        protected float velocity;
        protected float velocityMuiltplier;
        protected float timeToFullVelocity;
        protected AnimationCurve changeVelocityCurve = null;

        protected float startTime;
        protected float startVelocity;

        private SpriteRenderer spriteRenderer = null;
        private TrailRenderer trailRenderer = null;

        protected bool isPause;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            trailRenderer = GetComponentInChildren<TrailRenderer>();
        }

        private void Start() => Initialize();

        private void Initialize()
        {
            startTime = Time.time;
        }

        public void SetVelocity(float value)
        {
            velocity = value;
            startVelocity = value;
        }

        public void SetVelocityMultiplier(float value) => velocityMuiltplier = value;

        public void SetTimeToFullVelocity(float value) => timeToFullVelocity = value;

        public void SetVelocityCurve(AnimationCurve curve) => changeVelocityCurve = curve;

        public virtual void Move()
        {
            transform.Translate(direction * velocity * Time.deltaTime);
        }

        public void Blink()
        {
            StartCoroutine(BlinkRoution());
        }

        private IEnumerator BlinkRoution()
        {
            trailRenderer.emitting = false;

            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.5f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.5f);
            }

            trailRenderer.emitting = true;

            session.SwitchPause(false);
        }

        public void Continue()
        {
            isPause = false;
        }

        public void Pause()
        {
            isPause = true;
        }
    }
}
