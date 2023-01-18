using Newtonsoft.Json;
using PilotDesktop.Settings.Constants;
using PilotDesktop.Settings.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Settings.Services
{
    public class PilotApplicationSettingsService
    {
        private readonly string _pilotApplicationSettingsPath = "PilotApplicationSettings.json";


        public PilotApplicationSettings GetSettings()
        {
            if (File.Exists(_pilotApplicationSettingsPath))
            {
                var settingsData = File.ReadAllText(_pilotApplicationSettingsPath);
                var settings = JsonConvert.DeserializeObject<PilotApplicationSettings>(settingsData);
                if (settings != null)
                {
                    return settings;
                }

            }
            return new PilotApplicationSettings();
        }
        public PilotApplicationSettings SaveSettings(PilotApplicationSettings pilotApplicationSettings)
        {
            var settings = JsonConvert.SerializeObject(pilotApplicationSettings);

            File.WriteAllText(_pilotApplicationSettingsPath, settings);

            return pilotApplicationSettings;
        }
        public bool SettingsAreValid(PilotApplicationSettings pilotApplicationSettings)
        {
            if (!pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ProjectFolder))
                return false;
            if (!pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.MasterProject))
                return false;
            if (!pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.ApiSecret))
                return false;
            if (!pilotApplicationSettings.Settings.ContainsKey(PilotApplicationSettingsConstants.BaseUrl))
                return false;


            return true;
        }

    }

}
