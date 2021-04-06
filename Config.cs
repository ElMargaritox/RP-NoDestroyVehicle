using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace RPNoDestroyVehicle
{
    public class Config : IRocketPluginConfiguration
    {
        public bool vidainfinita;
        public bool mostrarlog;
        public void LoadDefaults()
        {
            vidainfinita = true;
            mostrarlog = true;
        }
    }
}
