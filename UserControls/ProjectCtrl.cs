using PilotDesktop.Pilot.Objects;
using PilotDesktop.Work.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotDesktop.UserControls
{
    public partial class ProjectCtrl : UserControl
    {
        public ProjectCtrl()
        {
            InitializeComponent();
        }

        private void ProjectCtrl_Load(object sender, EventArgs e)
        {
            LoadProjects(null);
        }
        public void LoadProjects(Guid? selectedProjectSystemId)
        {   
            var projects = new List<PilotProject>();
            foreach (var customer in Program.Customers)
            {
                if (customer.Projects.Any())
                {
                  projects.AddRange(customer.Projects);
                }
            }
            LoadProjects(projects, selectedProjectSystemId);
        }
        public void LoadProjects(List<PilotProject> projects, Guid? selectedProjectSystemId)
        {
            cbProjects.Items.Clear();   
            if (projects.Any())
            {
                foreach (var project in projects)
                {
                    cbProjects.Items.Add(project);
                    if (selectedProjectSystemId.HasValue && project.SystemId == selectedProjectSystemId)
                        cbProjects.SelectedItem = project;
                }
            }
        }
        public PilotProject GetData()
        {
            if (cbProjects.SelectedItem != null)
            {
                return (PilotProject)cbProjects.SelectedItem;
            }
            return null;
        }

        #region Eventhandlers
        public event EventHandler OnIndexChanged;
        public virtual void RaiseIndexChanged(EventArgs ea)
        {
            var handler = OnIndexChanged;
            if (OnIndexChanged != null)
                OnIndexChanged(this, ea);
        }





        //public string GetSelectedText()
        //{
        //    return ((Project)cbProject.SelectedItem)?.ToString() ?? "";
        //}
        #endregion

        private void cbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaiseIndexChanged(e);
        }
    }
}
