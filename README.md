# Getting Started with WPF OlapChart

This sample demonstrates how to create a WPF OlapChart control bound to an OLAP data source.

## Requirements

* **Visual Studio** 2019 or later
* **.NET Framework** 4.6.2

## NuGet Packages

The following Syncfusion NuGet packages are used in this sample:

| Package | Description |
|---------|-------------|
| `Syncfusion.Chart.WPF.Classic` | Core WPF chart library |
| `Syncfusion.Olap.Base` | OLAP base library for data management |
| `Syncfusion.OlapChart.WPF` | OLAP chart control for WPF |
| `Syncfusion.OlapShared.WPF` | Shared OLAP components for WPF |
| `Syncfusion.SfChart.WPF` | SfChart WPF library |
| `Syncfusion.Shared.WPF` | Shared WPF controls and utilities |
| `Syncfusion.Tools.WPF` | WPF tools and utility controls |
| `Syncfusion.Linq.Base` | LINQ base library |
| `Syncfusion.Licensing` | Syncfusion license key validation |

## Getting Started

### Step 1: Create a WPF Application

Open Visual Studio and navigate to **File > New > Project > WPF Application** (inside Visual C# Templates) to create a new WPF application.

### Step 2: Add Syncfusion Assemblies

Add the following Syncfusion assemblies to the project by referencing the NuGet packages or by adding them manually from the installed location:

* `Syncfusion.Chart.WPF`
* `Syncfusion.Olap.Base`
* `Syncfusion.OlapChart.WPF`
* `Syncfusion.OlapShared.WPF`
* `Syncfusion.Shared.WPF`
* `Syncfusion.Tools.WPF`

> **NOTE:** You can also get the assemblies by browsing to the default assembly location:
> `{System Drive}:\Program Files (x86)\Syncfusion\Essential Studio\<version number>\precompiledassemblies\<version number>\<framework version>\`

### Step 3: Register the Syncfusion License Key

Starting with v16.2.0.x, you must include a valid Syncfusion license key in your application. Register the license key in `App.xaml.cs`:

```csharp
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
```

Refer to the [Syncfusion License Key documentation](https://help.syncfusion.com/common/essential-studio/licensing/license-key) for more details.

### Step 4: Add the OlapChart to MainWindow.xaml

Add the `syncfusion` XML namespace and place the `OlapChart` control inside the `Grid` in `MainWindow.xaml`:

```xml
<Window x:Class="WPFOlapDemo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <syncfusion:OlapChart x:Name="olapChart"
                              HorizontalAlignment="Left"
                              VerticalAlignment="Top"
                              Height="319" Width="517"/>
    </Grid>
</Window>
```

### Step 5: Bind OLAP Data in Code-Behind

Include the following namespaces in `MainWindow.xaml.cs`:

```csharp
using Syncfusion.Olap.Manager;
using Syncfusion.Olap.Reports;
```

In the `MainWindow` constructor, initialize the `OlapDataManager` with a connection string, create an `OlapReport`, and bind it to the `OlapChart`:

```csharp
public partial class MainWindow : Window
{
    private string _connectionString;
    private OlapDataManager _olapDataManager;

    public MainWindow()
    {
        InitializeComponent();
        _connectionString = "Data Source=http://bi.syncfusion.com/olap/msmdpump.dll; Initial Catalog=Adventure Works DW 2008 SE;";
        // Connection string is passed to OlapDataManager as an argument
        _olapDataManager = new OlapDataManager(_connectionString);
        // A default OlapReport is set to OlapDataManager
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
        // Specifying the Measure name
        measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

        DimensionElement dimensionElementRow = new DimensionElement();
        // Specifying the name of the Dimension
        dimensionElementRow.Name = "Date";
        // Specifying the Hierarchy and Level name
        dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

        // Adding Dimension in column axis
        olapReport.CategoricalElements.Add(dimensionElementColumn);
        // Adding Measure in column axis
        olapReport.CategoricalElements.Add(measureElementColumn);
        // Adding Dimension in row axis
        olapReport.SeriesElements.Add(dimensionElementRow);

        return olapReport;
    }
}
```

### Step 6: Run the Application

Build and run the application. The WPF OlapChart will be displayed with data from the Adventure Works cube, showing **Internet Sales Amount** by **Customer Geography (Country)** across **Fiscal Years**.

## Project Structure

```
WPFOlapDemo/
├── WPFOlapDemo.slnx          # Solution file
├── packages/                  # NuGet packages
└── WPFOlapDemo/
    ├── App.xaml               # Application entry point
    ├── App.xaml.cs            # Application code-behind
    ├── MainWindow.xaml        # Main window with OlapChart declaration
    ├── MainWindow.xaml.cs     # Main window code-behind with data binding
    ├── packages.config        # NuGet package references
    └── WPFOlapDemo.csproj     # Project file
```

## References

* [Syncfusion WPF OlapChart Getting Started](https://help.syncfusion.com/wpf/olap-chart/getting-started)
* [Syncfusion WPF OlapChart Documentation](https://help.syncfusion.com/wpf/olap-chart/overview)
* [Syncfusion License Key](https://help.syncfusion.com/common/essential-studio/licensing/license-key)
