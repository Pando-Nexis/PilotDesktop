using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Objects;
using PilotDesktop.Settings.Services;
using System.Globalization;
using System.Text.RegularExpressions;
using PilotDesktop.General.Services;
using Solution.Extensions.PNPilot.Objects;

namespace PilotDesktop
{
    internal static class Program
    {
        public static PilotApplicationSettings _pilotApplicationSettings = new PilotApplicationSettings();
        public static List<PilotCustomer> _customers = new List<PilotCustomer>();
        public static List<WorkItem> workItems = new List<WorkItem>();
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
     var settingService = new PilotApplicationSettingsService();
            _pilotApplicationSettings = settingService.GetSettings();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PilotNavigator());
        }

        public static class Global
        {
            
        }
    }
}