using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada.App_Code
{
    public class Initializer
    {
        public static void AppInitialize()
        {
            DbManager.tags = FileManager.readFromConfig();
            DbManager.alarms = FileManager.readAlarms();
            TagProccessing.startSimulation();
        }
    }
}