namespace Shipwreck.Model
{
    public class Day
    {
        public int Number { get; set; }
        public Weather Weather { get; set; }

        public Day()
        {
            Number = 1;
            Weather = new Weather();
        }

        public void IncrementDay()
        {
            Number++;
        }
    }
}
