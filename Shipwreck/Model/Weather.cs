namespace Shipwreck.Model
{
    class Weather
    {
        public Type WeatherType { get; }
        public string Name { get; }

        public Weather()
        {
            WeatherType = Type.Sunny;
            Name = "Sunny";
        }
        public enum Type
        {
            Cloudy,
            Hurricane,
            Rainy,
            Sunny,
            Thunderstorm,
        }
    }
}
