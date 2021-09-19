using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using Logger = Rocket.Core.Logging.Logger;

namespace RPNoDestroyVehicle
{
    
    public class RPNoDestroyVehiclePlugin : RocketPlugin<RPNoDestroyVehicleConfig>
    {
        public RPNoDestroyVehiclePlugin Instance;
        protected override void Load()
        {

            Instance = this;
            base.Load();
            VehicleManager.onDamageVehicleRequested += VehiculoDaño;
        }

        private void VehiculoDaño(CSteamID instigatorSteamID, InteractableVehicle vehicle, ref ushort pendingTotalDamage, ref bool canRepair, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            if (Configuration.Instance.vidainfinita)
            {
                pendingTotalDamage = 0;
                shouldAllow = false;
            }

            if (Configuration.Instance.mostrarlog)
            {
                UnturnedPlayer player = UnturnedPlayer.FromCSteamID(instigatorSteamID);

                if (damageOrigin == EDamageOrigin.Useable_Gun || damageOrigin == EDamageOrigin.Useable_Melee || damageOrigin == EDamageOrigin.Punch)
                {
                    Logger.LogWarning($"{player.CharacterName} Esta Intentando Romper: {vehicle.asset.name}");  
                }
            }
        }


        protected override void Unload()
        {
            base.Unload();
            VehicleManager.onDamageVehicleRequested -= VehiculoDaño;
        }
    }
}
