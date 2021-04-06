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
    
    public class Class1 : RocketPlugin<Config>
    {
        public Class1 Instance;
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
                SteamPlayer nombre = PlayerTool.getSteamPlayer(instigatorSteamID);
                
                switch (damageOrigin)
                {
                    case EDamageOrigin.Useable_Gun:
                        Logger.Log(nombre.playerID.characterName + " Esta Intentando Romper: " + vehicle.name.ToString());
                        break;
                    case EDamageOrigin.Useable_Melee:
                        Logger.Log(nombre.playerID.characterName + " Esta Intentando Romper: " + vehicle.name.ToString());
                        break;
                    case EDamageOrigin.Punch:
                        Logger.Log(nombre.playerID.characterName + " Esta Intentando Romper: " + vehicle.name.ToString());
                        break;
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
