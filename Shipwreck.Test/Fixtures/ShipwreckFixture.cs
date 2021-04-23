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
                    Player = new PlayerSettings()
                }
            };
        }
        
        public void Dispose()
        {
        }
    }
}