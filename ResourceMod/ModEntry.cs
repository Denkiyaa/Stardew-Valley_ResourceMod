using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ResourceMod
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            // F9 tuşuna basıldığında çalışacak
            if (e.Button == SButton.F9)
            {
                var player = Game1.player;
                if (player != null)
                {
                    // Taş ve odun nesnelerini oluşturun
                    var stone = new StardewValley.Object(390.ToString(), 50); // 50 taş
                    var wood = new StardewValley.Object(388.ToString(), 50);  // 50 odun

                    // Eşyaları envantere ekleyin
                    player.addItemByMenuIfNecessary(stone);
                    player.addItemByMenuIfNecessary(wood);

                    this.Monitor.Log("50 taş ve 50 odun verildi.", LogLevel.Info);
                }
            }
        }
    }
}
