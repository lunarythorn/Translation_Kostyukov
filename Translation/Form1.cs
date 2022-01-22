using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translation
{
    public partial class Form1 : Form
    {
        string currLang = "English";
        private void SetCulture(string culture)
        {
            // Make the CultureInfo.
            CultureInfo culture_info = new CultureInfo(culture);

            // Make a ComponentResourceManager.
            ComponentResourceManager component_resource_manager
                = new ComponentResourceManager(this.GetType());

            // Apply resources to the form.
            component_resource_manager.ApplyResources(
                this, "$this", culture_info);

            // Apply resources to the form's controls.
            foreach (Control ctl in this.Controls)
            {
                component_resource_manager.ApplyResources(
                    ctl, ctl.Name, culture_info);
            }
        }
        public Form1()
        {
            
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();

            var usTimeZone = TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time");

            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            DateTime universalTime = curTimeZone.ToUniversalTime(DateTime.Now);

            var usTime = TimeZoneInfo.ConvertTimeFromUtc(universalTime, usTimeZone);
            
            label13.Text = usTime.Hour.ToString() + "." + usTime.Minute.ToString() + "." + usTime.Second.ToString();
        }

        private void languageToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem.CheckState == CheckState.Unchecked)
            {
                foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
                {
                    item.Checked = false;
                }
                menuItem.CheckState = CheckState.Checked;
                switch (menuItem.Name)
                {
                    case "englishToolStripMenuItem":
                        SetCulture("en-US");
                        languageToolStripMenuItem.Text = "Language";
                        englishToolStripMenuItem.Text = "English";
                        russianToolStripMenuItem.Text = "Russian";
                        frenchToolStripMenuItem.Text = "French";
                        currLang = "English";
                        break;
                    case "russianToolStripMenuItem":
                        SetCulture("ru-RU");
                        languageToolStripMenuItem.Text = "Язык";
                        englishToolStripMenuItem.Text = "Английский";
                        russianToolStripMenuItem.Text = "Русский";
                        frenchToolStripMenuItem.Text = "Французский";
                        currLang = "Russian";
                        break;
                    case "frenchToolStripMenuItem":
                        SetCulture("fr");
                        languageToolStripMenuItem.Text = "Langue";
                        englishToolStripMenuItem.Text = "Anglais";
                        russianToolStripMenuItem.Text = "Russe";
                        frenchToolStripMenuItem.Text = "Français";
                        currLang = "French";
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            switch (currLang)
            {
                case "English":
                    var usTimeZone = TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time");

                    DateTime universalTime = curTimeZone.ToUniversalTime(DateTime.Now);

                    var usTime = TimeZoneInfo.ConvertTimeFromUtc(universalTime, usTimeZone);
                    label13.Text = usTime.Hour.ToString() + "." + usTime.Minute.ToString() + "." + usTime.Second.ToString();
                    break;
                case "Russian":
                    var MoscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

                    DateTime universalTime2 = curTimeZone.ToUniversalTime(DateTime.Now);

                    var moscowTime = TimeZoneInfo.ConvertTimeFromUtc(universalTime2, MoscowTimeZone);
                    label13.Text = moscowTime.Hour.ToString() + "." + moscowTime.Minute.ToString() + "." + moscowTime.Second.ToString();
                    break;
                case "French":
                    var EuropeTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

                    DateTime universalTime3 = curTimeZone.ToUniversalTime(DateTime.Now);

                    var parisTime = TimeZoneInfo.ConvertTimeFromUtc(universalTime3, EuropeTimeZone);
                    label13.Text = parisTime.Hour.ToString() + "." + parisTime.Minute.ToString() + "." + parisTime.Second.ToString();
                    break;
            }

        }

    }
}
