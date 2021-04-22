using System;
using Shipwreck.Model.Game;
using Shipwreck.Model.Settings;

namespace Shipwreck.Test.Fixtures
{
    public class ShipwreckFixture : IDisposable
    {
        public ShipwreckFixture()
        {
            Shipwreck.Settings = new ShipwreckSettings
            {
                EasyGameSettingsPath = ""
            };
            
            Shipwreck.CurrentGame = new Game
            {
                GameSettings = new GameSettings
                {
                    Player = new PlayerSettings
                    {
                        BaseExpPerDay = 25,
                        HungerPerDay = 3,
                        InitialHunger = 15,
                        HealthGrowth = 1,
                        AttackGrowth = 1,
                        DefenseGrowth = 1,
                        MaxHunger = 20
                    }
                }
            };
        }
        
        public void Dispose()
        {
        }
    }
}