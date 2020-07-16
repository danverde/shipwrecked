namespace Shipwreck.Model
{
    class Day
    {
        public static int HungerPerDay  = 3;
        public int Number { get; private set; }
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
