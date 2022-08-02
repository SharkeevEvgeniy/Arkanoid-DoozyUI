using UnityEngine;
using Arkanoid.Level.Input;
using Arkanoid.Level.Session;

namespace Arkanoid.Level
{
    public abstract class PlatformBase : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private InputHandler inputHandler;

        [SerializeField] protected float clampRange;

        [SerializeField] protected Session.Session session;

        protected bool isPause;

        private void Awake()
        {
            session.AddPauseHandler(this);
        }

        private void OnEnable()
        {
            inputHandler.OnPositionChangedEvent += SetPosition;
        }

        private void OnDisable()
        {
            inputHandler.OnPositionChangedEvent -= SetPosition;
        }

        protected abstract void SetPosition(Vector2 position);

        public void Continue() => isPause = false;

        public void Pause() => isPause = true;
    }
}
