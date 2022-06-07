namespace BusinessLogic
{
    [Serializable]
    public class LocalizedBook : Book
    {       
        public string? LocalPublisher { get; set; }
        public string? CountryOfLocalization { get; set; }
    }
}