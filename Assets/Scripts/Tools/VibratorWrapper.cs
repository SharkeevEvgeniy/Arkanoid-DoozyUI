using UnityEngine;
using Arkanoid.Common;

namespace Arkanoid.Tools
{
    public class VibratorWrapper
    {
        private AndroidJavaObject vibrator = null;

        private readonly UserPrefs userPrefs = null;

        public VibratorWrapper(UserPrefs userPrefs)
        {
#if !UNITY_EDITOR
        var unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        vibrator = unityPlayerActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#endif
            this.userPrefs = userPrefs;
        }
        public void Vibrate(long time)
        {
#if !UNITY_EDITOR
        if (userPrefs.UseVibration() == true)
        {
            vibrator.Call("vibrate", time);
        }
#endif
        }
    }
}