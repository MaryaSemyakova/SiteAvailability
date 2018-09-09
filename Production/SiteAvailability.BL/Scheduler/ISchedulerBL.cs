namespace SiteAvailability.BL.Scheduler
{
    public interface ISchedulerBL
    {
        void ChangePeriod(int period);
        void StartNow();
        int GetSchedulerPeriod();
    }
}
