using PilotDesktop.Settings.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotDesktop.Settings.Constants;

namespace PilotDesktop.Settings.Objects
{
    public class PilotApplicationSettings
    {
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();

        public bool RequiredFieldValid()
        {
            if (!Settings.ContainsKey(PilotApplicationSettingsConstants.MasterProject))
                return false;
            if (string.IsNullOrEmpty(PilotApplicationSettingsConstants.MasterProject))
                return false;

            if (!Settings.ContainsKey(PilotApplicationSettingsConstants.ProjectFolder))
                return false;
            if (string.IsNullOrEmpty(PilotApplicationSettingsConstants.ProjectFolder))
                return false;

            if (!Settings.ContainsKey(PilotApplicationSettingsConstants.BaseUrl))
                return false;
            if (string.IsNullOrEmpty(PilotApplicationSettingsConstants.BaseUrl))
                return false;

            if (!Settings.ContainsKey(PilotApplicationSettingsConstants.ApiSecret))
                return false;
            if (string.IsNullOrEmpty(PilotApplicationSettingsConstants.ApiSecret))
                return false;

            return true;
        }
    }
}
