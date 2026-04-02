using Syncfusion.Olap.Manager;
using Syncfusion.Olap.Reports;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFOlapDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString;
        private OlapDataManager _olapDataManager;

        public MainWindow()
        {
            InitializeComponent();
            _connectionString = "Data Source=https://bi.syncfusion.com/olap/msmdpump.dll; Initial Catalog=Adventure Works DW 2008 SE;";
            //Connection string is passed to OlapDataManager as an argument
            _olapDataManager = new OlapDataManager(_connectionString);
            //A default OlapReport is set to OlapDataManager
            _olapDataManager.SetCurrentReport(CreateOlapReport());
            // Finally OlapChart gets the information from the OlapDataManager
            this.olapChart.OlapDataManager = _olapDataManager;
            this.olapChart.DataBind();
        }

        /// <summary>
		/// Defining OlapReport with Dimension and Measure
		/// </summary>
		private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport();
            // Setting the Cube name
            olapReport.CurrentCubeName = "Adventure Works";
            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the name of the Dimension
            dimensionElementColumn.Name = "Customer";
            // Specifying the Hierarchy and Level name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");
            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the Measure name
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });
            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the name of the Dimension
            dimensionElementRow.Name = "Date";
            // Specifying the Hierarchy and Level name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            ///Adding Dimension in column axis
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            ///Adding Measure in column axis
            olapReport.CategoricalElements.Add(measureElementColumn);
            ///Adding Dimension in row axis
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }
    }
}
