using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Arkanoid.Tools;
using Arkanoid.Common;

namespace Arkanoid.Level.Session
{
    public class Session : MonoBehaviour, IExitTransitionHandler
    {
        [SerializeField] private LevelConfig levelConfig;

        [SerializeField] private BallBase ball;
        [SerializeField] private Transform ballStartPosition;
        [SerializeField] private TextMeshProUGUI ballCountText;
        [SerializeField] private TextMeshProUGUI textMessage;

        [SerializeField] private UserPrefs userPrefs;

        private Transform ballTransform = null;
        private int ballCount;

        private SessionInfo sessionInfo = null;

        private List<IPauseHandler> pauseHandlers = null;
        private bool isPause;

        private SceneLoader sceneLoader = null;

        private int blockCount;

        private void Awake()
        {
            ballTransform = ball.transform;

            pauseHandlers = new List<IPauseHandler>();

            blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        }

        private void Start() => Initialize();

        private void Initialize()
        {
            ball.SetVelocity(levelConfig.StartVelocity);
            ball.SetTimeToFullVelocity(levelConfig.TimeToFullVelocity);
            ball.SetVelocityCurve(levelConfig.ChangeVelocityCurve);
            ball.SetVelocityMultiplier(levelConfig.VelocityMuiltplier);
            ballCount = levelConfig.BallCount;
            ballCountText.text = ballCount.ToString();

            sessionInfo = new SessionInfoBuilder()
                .SetDevice(SystemInfo.deviceName)
#if !UNITY_EDITOR
            .SetBatteryLevel(SystemInfo.batteryLevel)
#endif
            .SetStartSessionDate($"{System.DateTime.Now.Year}/{System.DateTime.Now.Month}/{System.DateTime.Now.Day}")
                .SetStartSessionTime($"{System.DateTime.Now.Hour}:{System.DateTime.Now.Minute}")
                .Build();
        }

        public void AddPauseHandler(IPauseHandler pauseHandler) => pauseHandlers.Add(pauseHandler);

        public void Lose()
        {
            AudioPlayer.Instance.PlayOneShot(AudioClips.Lose);

            SwitchPause(true);

            ballCount--;
            if (ballCount <= 0)
            {
                ShowMessage("Lose!");

                Transition.Instance.Make(0.5f, this);

                sceneLoader = new SceneLoader();
                sceneLoader.LoadScene(0);
                return;
            }

            ballCountText.text = ballCount.ToString();
            ball.Blink();
            ballTransform.position = ballStartPosition.position;
        }

        public void DecreaseBlockCount()
        {
            blockCount--;

            CheckOnVictory();
        }

        private void ShowMessage(string text)
        {
            textMessage.enabled = true;
            textMessage.text = text;
        }

        private void CheckOnVictory()
        {
            if (blockCount <= 0)
            {
                ShowMessage("Victory!");

                userPrefs.SetCurrentLevel(levelConfig.LevelIndex + 1);

                Transition.Instance.Make(0.5f, this);

                sceneLoader = new SceneLoader();
                sceneLoader.LoadScene(0);
            }
        }

        public void SwitchPauseOnClick()
        {
            isPause = !isPause;
            SwitchPause(isPause);
        }

        public void SwitchPause(bool value)
        {
            if (value == true)
            {
                foreach (IPauseHandler pauseHandler in pauseHandlers)
                {
                    pauseHandler.Pause();
                }
            }
            else
            {
                foreach (IPauseHandler pauseHandler in pauseHandlers)
                {
                    pauseHandler.Continue();
                }
            }
        }

        public void TransitionHandle() => sceneLoader.AllowLoadScene();
    }
}
