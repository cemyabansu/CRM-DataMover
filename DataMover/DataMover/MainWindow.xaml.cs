using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Messages;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

namespace DataMover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string _connectionString;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            _connectionString = FromOrgTextBox.Text;
            var crmConnection = CrmConnection.Parse(_connectionString);
            //to escape "another assembly" exception
            crmConnection.ProxyTypesAssembly = Assembly.GetExecutingAssembly();

            try
            {
                using (var organizationService = new OrganizationService(crmConnection))
                {
                    organizationService.Execute(new WhoAmIRequest());
                    StepsTabControl.SelectedIndex ++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not Connected!");
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            StepsListBox.Items.Add(new ListBoxItem().Content = "step");
        }

        private void DeleteStepButton_Click(object sender, RoutedEventArgs e)
        {
            StepsListBox.Items.RemoveAt(StepsListBox.SelectedIndex);
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var fetchXml = FetchXmlTextBox.Text;

            var crmConnection = CrmConnection.Parse(_connectionString);
            //to escape "another assembly" exception
            crmConnection.ProxyTypesAssembly = Assembly.GetExecutingAssembly();

            try
            {
                using (var organizationService = new OrganizationService(crmConnection))
                {
                    var fetchExpression = new FetchExpression(fetchXml);
                    var response = organizationService.RetrieveMultiple(fetchExpression);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not Connected!");
            }
        }
    }
}
