namespace Arkanoid.Level.Session
{
    public class SessionInfoBuilder : SessionInfo
    {
        public SessionInfoBuilder SetStartSessionDate(string date)
        {
            startSessionDate = date;
            return this;
        }

        public SessionInfoBuilder SetStartSessionTime(string time)
        {
            startSessionTime = time;
            return this;
        }

        public SessionInfoBuilder SetBatteryLevel(float batteryLevel)
        {
            this.batteryLevel = batteryLevel;
            return this;
        }

        public SessionInfoBuilder SetDevice(string deviceName)
        {
            device = deviceName;
            return this;
        }

        public SessionInfo Build()
        {
            return this;
        }
    }
}
