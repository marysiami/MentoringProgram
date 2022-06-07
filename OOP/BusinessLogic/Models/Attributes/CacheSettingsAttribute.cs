namespace BusinessLogic.Models.Attributes
{
    public class CacheSettingsAttribute: Attribute
    {
        public bool IsEnabled { get; set; }
        public TimeSpan SlidingExpiration { get; set; }

        public CacheSettingsAttribute(bool isEnabled, CacheLifespan life)
        {
            switch (life)
            {
                case CacheLifespan.OneHour:
                    SlidingExpiration = TimeSpan.FromHours(1);
                    break;
                case CacheLifespan.FourHours:
                    SlidingExpiration = TimeSpan.FromHours(4);
                    break;
                case CacheLifespan.Day:
                    SlidingExpiration = TimeSpan.FromDays(1);
                    break;
                case CacheLifespan.Week:
                    SlidingExpiration = TimeSpan.FromDays(7);
                    break;
                case CacheLifespan.Month:
                    SlidingExpiration = TimeSpan.FromDays(30);
                    break;
                default:
                    break;
            }

            IsEnabled = isEnabled;
        }
    }

    public enum CacheLifespan
    {
        Infinite,
        OneHour,
        FourHours,
        Day,
        Week,
        Month
    }
}
