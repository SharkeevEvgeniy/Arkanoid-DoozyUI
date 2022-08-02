namespace Arkanoid.Level.Session
{
    public class SessionInfo
    {
        protected string startSessionDate;
        protected string startSessionTime;
        protected float batteryLevel;
        protected string device;

        public string GetInfo()
        {
            return $"Date:{startSessionDate}\n Time:{startSessionTime}\n Battery level:{batteryLevel}\n Device:{device}";
        }
    }
}
