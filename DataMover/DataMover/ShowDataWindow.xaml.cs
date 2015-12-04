using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace DataMover
{
    /// <summary>
    /// Interaction logic for ShowDataWindow.xaml
    /// </summary>
    public partial class ShowDataWindow : Window
    {
        public ShowDataWindow(FetchXmlToQueryExpressionResponse response)
        {
            InitializeComponent();

            DataTable responseDataTable = new DataTable("Response Table");

            var columns = response.Query.ColumnSet.Columns.ToArray();

            foreach (var column in columns)
            {
                responseDataTable.Columns.Add(column);
            }

            var results = response.Results;

            foreach (var record in results)
            {
                var newRow = responseDataTable.NewRow();



                responseDataTable.Rows.Add(newRow);
            }

            ResponseDataGrid.DataContext = responseDataTable;
        }
    }
}
