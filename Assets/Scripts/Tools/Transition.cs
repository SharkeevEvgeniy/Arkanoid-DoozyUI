using System.Collections;
using UnityEngine;

namespace Arkanoid.Tools
{
    public class Transition : MonoBehaviour
    {
        public static Transition Instance { get; private set; }

        [SerializeField] private GameObject transitionPanel;

        private Animator animator = null;

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

            animator = transitionPanel.GetComponent<Animator>();
        }

        public void Make(float duration, IExitTransitionHandler handler)
        {
            StartCoroutine(MakeTransitionRoutine(duration, handler));
        }

        private IEnumerator MakeTransitionRoutine(float duration, IExitTransitionHandler handler)
        {
            transitionPanel.SetActive(true);
            animator.speed = 1f / duration;
            yield return new WaitForSeconds(duration);
            handler.TransitionHandle();
            yield return new WaitForSeconds(duration);
            transitionPanel.SetActive(false);
        }
    }
}
