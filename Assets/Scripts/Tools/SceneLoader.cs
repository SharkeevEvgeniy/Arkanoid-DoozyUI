using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Tools
{ 
    public class SceneLoader
    {
        private AsyncOperation asyncOperation;

        public async void LoadScene(int indexScene)
        {
            try
            {
                await AsyncLoadScene(indexScene);
            }
            catch (OperationCanceledException exception)
            {
#if UNITY_EDITOR
                Debug.LogError(exception);
#endif
            }
        }

        private async Task AsyncLoadScene(int indexScene)
        {
            asyncOperation = SceneManager.LoadSceneAsync(indexScene);
            asyncOperation.allowSceneActivation = false;
            return;
        }

        public void AllowLoadScene()
        {
            asyncOperation.allowSceneActivation = true;
        }
    }
}
