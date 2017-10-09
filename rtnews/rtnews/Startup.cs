namespace rtnews.Droid
{
    public class Startup : Singleton<Startup>
    {
        public void RunInit()
        {
            var logEngine = LogEngine.Instance();
            logEngine.Preinit();
            logEngine.EnableDebugLog();

            var uconfig = UConfig.Instance();
            uconfig.RunInit();

            var startRep = StartRep.Instance();
            startRep.RunInit();
        }
    }
}
