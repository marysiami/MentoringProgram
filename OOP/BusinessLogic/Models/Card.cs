namespace BusinessLogic
{
    public class Card
    {
        public string Type { get; set; }
        public string Number { get; set; }

        public string GetCardName()
        {
            return $"{Type}_#{Number}";
        }
    }
}
