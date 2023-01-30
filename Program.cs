using PilotDesktop.Pilot.Objects;
using PilotDesktop.Settings.Objects;
using PilotDesktop.Settings.Services;
using PilotDesktop.Work.Objects;

namespace PilotDesktop
{
    internal static class Program
    {
        public static PilotApplicationSettings _pilotApplicationSettings = new PilotApplicationSettings();
        public static List<PilotCustomer> Customers = new List<PilotCustomer>();
        public static WorkItems WorkItems  =new WorkItems();
        public static List<ItemType> ItemTypes = new List<ItemType>();
        public static List<ItemStatus> ItemStatuses = new List<ItemStatus>(); 
        public static List<Time> Times = new List<Time>();
        public static List<TimeType> TimeTypes = new List<TimeType>();
        public static List<TimeStatus> TimeStatuses= new List<TimeStatus>();
       
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