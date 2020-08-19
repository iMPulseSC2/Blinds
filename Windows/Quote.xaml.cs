using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace PersiennGiganten_2020.Windows
{
    /// <summary>
    /// Interaction logic for Quote.xaml
    /// </summary>
    /// 

    public partial class Quote : UserControl
    {
        public Quote()
        {
            InitializeComponent();

            //prices.Add(measurements5.PricePerPiece.ToString());

            //DataGridXAML.Items.Add(measurements5);

            //DataGridXAML.ItemsSource = MainWindow.list;

            //DataGridXAML.ItemsSource = listProducts;

            //this.comboBox.DataContext = this;

            var mainState = new ExcelState
            {
                State = false
            };

            //Get relative path to excel file
            string exeDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            _Application excel = new _Excel.Application();
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;

            Range rngWidth;
            try
            {
                xlWorkBook = excel.Workbooks.Open(System.IO.Path.Combine(exeDir, excelCurrentPriceList), 0, true, 5, "", "", true, _Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Worksheet excelSheet = xlWorkBook.ActiveSheet;
                //First number is row, second is column, third is row, fourth is column.
                rngWidth = (Range)excelSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[19, 1]];
                Range rngHeight = (Range)excelSheet.Range[xlWorkSheet.Cells[1, 2], xlWorkSheet.Cells[1, 19]];
                Range rngFullPricelist = (Range)excelSheet.Range[xlWorkSheet.Cells[2, 2], xlWorkSheet.Cells[19, 19]];

                holderWidth = rngWidth.Value2;
                holderHeight = rngHeight.Value2;
                holderFullPricelist = rngFullPricelist.Value2;

                mainState.State = true;

                xlWorkBook.Close();
                excel.Quit();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                //Close();
            }


            //Display correct items in the combobox menu
            items.Add(new ComboBoxCategory() { Name = "16mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm - (Täta Stegband +15%)", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm - (Färgtillägg +30%)", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "35mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "50mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "PG RE", Category = "Rullgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG R1", Category = "Rullgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG R2", Category = "Rullgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG R3", Category = "Rullgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG R4", Category = "Rullgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG PE", Category = "Plisségardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG P1", Category = "Plisségardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG P2", Category = "Plisségardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG HE", Category = "Honeycellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG H1", Category = "Honeycellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG H2", Category = "Honeycellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG H3", Category = "Honeycellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "PG H4", Category = "Honeycellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "89mm PG LE", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "89mm PG L1", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "89mm PG L2", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "127mm PG LE", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "127mm PG L1", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "127mm PG L2", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "127mm PG L3", Category = "Lamellgardiner" });
            items.Add(new ComboBoxCategory() { Name = "Ek, Furu", Category = "Träpersienner" });

            ListCollectionView lcv = new ListCollectionView(items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            CbboxProducts.ItemsSource = lcv;
        }
        //Save the prices
        public static object[,] holderWidth;
        public static object[,] holderHeight;
        public static object[,] holderFullPricelist;

        //List for the product combobox
        public static List<ComboBoxCategory> items = new List<ComboBoxCategory>();

        //Declaring the different products
        public Persienner persienner;
        public Rullgardiner rullgardiner;
        public Plissegardiner plissegardiner;
        public Honeycellgardiner honeycellgardiner;
        public Lamellgardiner lamellgardiner;
        public Trapersienner trapersienner;

        List<Persienner> listPersienner = new List<Persienner>();
        List<Rullgardiner> listRullgardiner = new List<Rullgardiner>();
        List<Plissegardiner> listPlissegardiner = new List<Plissegardiner>();
        List<Honeycellgardiner> listHoneycellgardiner = new List<Honeycellgardiner>();
        List<Lamellgardiner> listLamellgardiner = new List<Lamellgardiner>();
        List<Trapersienner> listTrapersienner = new List<Trapersienner>();

        public DataGrid dataGrid;

        public ObservableCollection<DataGrid> listDataGrid = new ObservableCollection<DataGrid>();

        List<Product> listProducts = new List<Product>();

        //List of strings from measurements
        List<string> listRawQuantity = new List<string>();
        List<string> listRawWidth = new List<string>();
        List<string> listRawHeight = new List<string>();

        //List of converted measurements
        List<int> listConvertedQuantity = new List<int>();
        List<double> listConvertedWidth = new List<double>();
        List<double> listConvertedHeight = new List<double>();
        List<object> listConvertedMeasurements = new List<object>();

        public static string rngFullPrice;

        //The various pricelists
        string excelCurrentPriceList;
        string excelFilePersienner = "pricelistPersienner.xlsx";
        string excelFileRullgardinerPGRE = "pricelistRollerblindsPGE.xlsx";
        string excelFileRullgardinerPGR1 = "pricelistRollerblindsPGRR1.xlsx";
        string excelFileRullgardinerPGR2 = "pricelistRollerblindsPGRR2.xlsx";
        string excelFileRullgardinerPGR3 = "pricelistRollerblindsPGRR3.xlsx";
        string excelFileRullgardinerPGR4 = "pricelistRollerblindsPGR4.xlsx";
        string excelFilePlissegardinerPGPE = "pricelistPlissegardinerPGPE.xlsx";
        string excelFilePlissegardinerPGP1 = "pricelistPlissegardinerPGP1.xlsx";
        string excelFilePlissegardinerPGP2 = "pricelistPlissegardinerPGP2.xlsx";
        string excelFileHoneycellgardinerPGHE = "pricelistHoneycellgardinerPGHE.xlsx";
        string excelFileHoneycellgardinerPGH1 = "pricelistHoneycellgardinerPGH1.xlsx";
        string excelFileHoneycellgardinerPGH2 = "pricelistHoneycellgardinerPGH2.xlsx";
        string excelFileHoneycellgardinerPGH3 = "pricelistHoneycellgardinerPGH3.xlsx";
        string excelFileHoneycellgardinerPGH4 = "pricelistHoneycellgardinerPGH4.xlsx";
        string excelFileLamellgardiner89mmPGL1 = "pricelistBlinds.xlsx";
        string excelFileTrapersienner = "pricelistBlinds.xlsx";

        int size = 0;

        //Declare sizes from textboxes
        int width1 = 0;
        int height1 = 0;
        int width2 = 0;
        int height2 = 0;
        int width3 = 0;
        int height3 = 0;
        int width4 = 0;
        int height4 = 0;
        int width5 = 0;
        int height5 = 0;
        int width6 = 0;
        int height6 = 0;
        int width7 = 0;
        int height7 = 0;
        int width8 = 0;
        int height8 = 0;
        int width9 = 0;
        int height9 = 0;
        int width10 = 0;
        int height10 = 0;
        int width11 = 0;
        int height11 = 0;
        int width12 = 0;
        int height12 = 0;
        int width13 = 0;
        int height13 = 0;
        int width14 = 0;
        int height14 = 0;
        int width15 = 0;
        int height15 = 0;

        private void CustomerInfoClear()
        {
            TxtboxCustomerInfoName.Text = "";
            TxtboxCustomerInfoPhone.Text = "";
            TxtboxCustomerInfoAddress.Text = "";
            TxtboxCustomerInfoZipCode.Text = "";
            TxtboxCustomerInfoCompany.Text = "";
        }

        private async void BtnMoreInfoInstallationCost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var metroWindow = (System.Windows.Application.Current.MainWindow as MetroWindow);
            await metroWindow.ShowMessageAsync("Specifikation", "Här kommer mer specifik information om kostnader ang. montering för respektive produkter.");
        }

        private void BtnClearContantInfo_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfoClear();
        }
        private void ClearMeasurements()
        {
            TxtboxQuantity1.Text = "";
            TxtboxQuantity2.Text = "";
            TxtboxQuantity3.Text = "";
            TxtboxQuantity4.Text = "";
            TxtboxQuantity5.Text = "";
            TxtboxQuantity6.Text = "";
            TxtboxQuantity7.Text = "";
            TxtboxQuantity8.Text = "";
            TxtboxQuantity9.Text = "";
            TxtboxQuantity10.Text = "";
            TxtboxQuantity11.Text = "";
            TxtboxQuantity12.Text = "";
            TxtboxQuantity13.Text = "";
            TxtboxQuantity14.Text = "";
            TxtboxQuantity15.Text = "";

            TxtboxWidth1.Text = "";
            TxtboxWidth2.Text = "";
            TxtboxWidth3.Text = "";
            TxtboxWidth4.Text = "";
            TxtboxWidth5.Text = "";
            TxtboxWidth6.Text = "";
            TxtboxWidth7.Text = "";
            TxtboxWidth8.Text = "";
            TxtboxWidth9.Text = "";
            TxtboxWidth10.Text = "";
            TxtboxWidth11.Text = "";
            TxtboxWidth12.Text = "";
            TxtboxWidth13.Text = "";
            TxtboxWidth14.Text = "";
            TxtboxWidth15.Text = "";

            TxtboxHeight1.Text = "";
            TxtboxHeight2.Text = "";
            TxtboxHeight3.Text = "";
            TxtboxHeight4.Text = "";
            TxtboxHeight5.Text = "";
            TxtboxHeight6.Text = "";
            TxtboxHeight7.Text = "";
            TxtboxHeight8.Text = "";
            TxtboxHeight9.Text = "";
            TxtboxHeight10.Text = "";
            TxtboxHeight11.Text = "";
            TxtboxHeight12.Text = "";
            TxtboxHeight13.Text = "";
            TxtboxHeight14.Text = "";
            TxtboxHeight15.Text = "";
        }

        private void BtnClearMeasurements_Click(object sender, RoutedEventArgs e)
        {
            ClearMeasurements();
        }

        private void BtnAddMeasurementsToDataGrid_Click(object sender, RoutedEventArgs e)
        {
            //Reset lists
            listRawQuantity.Clear();
            listRawWidth.Clear();
            listRawHeight.Clear();
            listConvertedQuantity.Clear();
            listConvertedWidth.Clear();
            listConvertedHeight.Clear();

            listPersienner.Clear();
            DataGridXAML.Items.Refresh();


            //Add measurements to lists
            listRawQuantity.Add(TxtboxQuantity1.Text);
            listRawQuantity.Add(TxtboxQuantity2.Text);
            listRawQuantity.Add(TxtboxQuantity3.Text);
            listRawQuantity.Add(TxtboxQuantity4.Text);
            listRawQuantity.Add(TxtboxQuantity5.Text);
            listRawQuantity.Add(TxtboxQuantity6.Text);
            listRawQuantity.Add(TxtboxQuantity7.Text);
            listRawQuantity.Add(TxtboxQuantity8.Text);
            listRawQuantity.Add(TxtboxQuantity9.Text);
            listRawQuantity.Add(TxtboxQuantity10.Text);
            listRawQuantity.Add(TxtboxQuantity11.Text);
            listRawQuantity.Add(TxtboxQuantity12.Text);
            listRawQuantity.Add(TxtboxQuantity13.Text);
            listRawQuantity.Add(TxtboxQuantity14.Text);
            listRawQuantity.Add(TxtboxQuantity15.Text);

            try
            {
                //Add the converted measurements to new list
                listConvertedQuantity = listRawQuantity.Select(s => { int i; return int.TryParse(s, out i) ? i : (int?)null; })
                               .Where(i => i.HasValue)
                                  .Select(i => i.Value)
                                    .ToList();
            }
            catch (Exception)
            {
            }

            listRawWidth.Add(TxtboxWidth1.Text);
            listRawWidth.Add(TxtboxWidth2.Text);
            listRawWidth.Add(TxtboxWidth3.Text);
            listRawWidth.Add(TxtboxWidth4.Text);
            listRawWidth.Add(TxtboxWidth5.Text);
            listRawWidth.Add(TxtboxWidth6.Text);
            listRawWidth.Add(TxtboxWidth7.Text);
            listRawWidth.Add(TxtboxWidth8.Text);
            listRawWidth.Add(TxtboxWidth9.Text);
            listRawWidth.Add(TxtboxWidth10.Text);
            listRawWidth.Add(TxtboxWidth11.Text);
            listRawWidth.Add(TxtboxWidth12.Text);
            listRawWidth.Add(TxtboxWidth13.Text);
            listRawWidth.Add(TxtboxWidth14.Text);
            listRawWidth.Add(TxtboxWidth15.Text);

            try
            {
                //Add the converted measurements to new list
                listConvertedWidth = listRawWidth.Select(s => { double i; return double.TryParse(s, out i) ? i : (double?)null; })
                             .Where(i => i.HasValue)
                                .Select(i => i.Value)
                                  .ToList();
            }
            catch (Exception)
            {
            }

            listRawHeight.Add(TxtboxHeight1.Text);
            listRawHeight.Add(TxtboxHeight2.Text);
            listRawHeight.Add(TxtboxHeight3.Text);
            listRawHeight.Add(TxtboxHeight4.Text);
            listRawHeight.Add(TxtboxHeight5.Text);
            listRawHeight.Add(TxtboxHeight6.Text);
            listRawHeight.Add(TxtboxHeight7.Text);
            listRawHeight.Add(TxtboxHeight8.Text);
            listRawHeight.Add(TxtboxHeight9.Text);
            listRawHeight.Add(TxtboxHeight10.Text);
            listRawHeight.Add(TxtboxHeight11.Text);
            listRawHeight.Add(TxtboxHeight12.Text);
            listRawHeight.Add(TxtboxHeight13.Text);
            listRawHeight.Add(TxtboxHeight14.Text);
            listRawHeight.Add(TxtboxHeight15.Text);

            try
            {
                //Add the converted measurements to new list
                listConvertedHeight = listRawHeight.Select(s => { double i; return double.TryParse(s, out i) ? i : (double?)null; })
                             .Where(i => i.HasValue)
                                .Select(i => i.Value)
                                  .ToList();
            }
            catch (Exception)
            {
            }

            //Round the sizes to 10s
            width1 = SizeRounded(TxtboxWidth1.Text);
            width2 = SizeRounded(TxtboxWidth2.Text);
            width3 = SizeRounded(TxtboxWidth3.Text);
            width4 = SizeRounded(TxtboxWidth4.Text);
            width5 = SizeRounded(TxtboxWidth5.Text);
            width6 = SizeRounded(TxtboxWidth6.Text);
            width7 = SizeRounded(TxtboxWidth7.Text);
            width8 = SizeRounded(TxtboxWidth8.Text);
            width9 = SizeRounded(TxtboxWidth9.Text);
            width10 = SizeRounded(TxtboxWidth10.Text);
            width11 = SizeRounded(TxtboxWidth11.Text);
            width12 = SizeRounded(TxtboxWidth12.Text);
            width13 = SizeRounded(TxtboxWidth13.Text);
            width14 = SizeRounded(TxtboxWidth14.Text);
            width15 = SizeRounded(TxtboxWidth15.Text);

            height1 = SizeRounded(TxtboxHeight1.Text);
            height2 = SizeRounded(TxtboxHeight2.Text);
            height3 = SizeRounded(TxtboxHeight3.Text);
            height4 = SizeRounded(TxtboxHeight4.Text);
            height5 = SizeRounded(TxtboxHeight5.Text);
            height6 = SizeRounded(TxtboxHeight6.Text);
            height7 = SizeRounded(TxtboxHeight7.Text);
            height8 = SizeRounded(TxtboxHeight8.Text);
            height9 = SizeRounded(TxtboxHeight9.Text);
            height10 = SizeRounded(TxtboxHeight10.Text);
            height11 = SizeRounded(TxtboxHeight11.Text);
            height12 = SizeRounded(TxtboxHeight12.Text);
            height13 = SizeRounded(TxtboxHeight13.Text);
            height14 = SizeRounded(TxtboxHeight14.Text);
            height15 = SizeRounded(TxtboxHeight15.Text);

            //Make sure the sizes are within the pricelist
            width1 = CheckWidthSizing(width1);
            width2 = CheckWidthSizing(width2);
            width3 = CheckWidthSizing(width3);
            width4 = CheckWidthSizing(width4);
            width5 = CheckWidthSizing(width5);
            width6 = CheckWidthSizing(width6);
            width7 = CheckWidthSizing(width7);
            width8 = CheckWidthSizing(width8);
            width9 = CheckWidthSizing(width9);
            width10 = CheckWidthSizing(width10);
            width11 = CheckWidthSizing(width11);
            width12 = CheckWidthSizing(width12);
            width13 = CheckWidthSizing(width13);
            width14 = CheckWidthSizing(width14);
            width15 = CheckWidthSizing(width15);

            height1 = CheckHeightSizing(height1);
            height2 = CheckHeightSizing(height2);
            height3 = CheckHeightSizing(height3);
            height4 = CheckHeightSizing(height4);
            height5 = CheckHeightSizing(height5);
            height6 = CheckHeightSizing(height6);
            height7 = CheckHeightSizing(height7);
            height8 = CheckHeightSizing(height8);
            height9 = CheckHeightSizing(height9);
            height10 = CheckHeightSizing(height10);
            height11 = CheckHeightSizing(height11);
            height12 = CheckHeightSizing(height12);
            height13 = CheckHeightSizing(height13);
            height14 = CheckHeightSizing(height14);
            height15 = CheckHeightSizing(height15);

            int rowListValue1 = CheckWidthToPrice(width1, holderWidth);
            int rowListValue2 = CheckWidthToPrice(width2, holderWidth);
            int rowListValue3 = CheckWidthToPrice(width3, holderWidth);
            int rowListValue4 = CheckWidthToPrice(width4, holderWidth);
            int rowListValue5 = CheckWidthToPrice(width5, holderWidth);
            int rowListValue6 = CheckWidthToPrice(width6, holderWidth);
            int rowListValue7 = CheckWidthToPrice(width7, holderWidth);
            int rowListValue8 = CheckWidthToPrice(width8, holderWidth);
            int rowListValue9 = CheckWidthToPrice(width9, holderWidth);
            int rowListValue10 = CheckWidthToPrice(width10, holderWidth);
            int rowListValue11 = CheckWidthToPrice(width11, holderWidth);
            int rowListValue12 = CheckWidthToPrice(width12, holderWidth);
            int rowListValue13 = CheckWidthToPrice(width13, holderWidth);
            int rowListValue14 = CheckWidthToPrice(width14, holderWidth);
            int rowListValue15 = CheckWidthToPrice(width15, holderWidth);

            int colListValue1 = CheckHeightToPrice(height1, holderHeight);
            int colListValue2 = CheckHeightToPrice(height2, holderHeight);
            int colListValue3 = CheckHeightToPrice(height3, holderHeight);
            int colListValue4 = CheckHeightToPrice(height4, holderHeight);
            int colListValue5 = CheckHeightToPrice(height5, holderHeight);
            int colListValue6 = CheckHeightToPrice(height6, holderHeight);
            int colListValue7 = CheckHeightToPrice(height7, holderHeight);
            int colListValue8 = CheckHeightToPrice(height8, holderHeight);
            int colListValue9 = CheckHeightToPrice(height9, holderHeight);
            int colListValue10 = CheckHeightToPrice(height10, holderHeight);
            int colListValue11 = CheckHeightToPrice(height11, holderHeight);
            int colListValue12 = CheckHeightToPrice(height12, holderHeight);
            int colListValue13 = CheckHeightToPrice(height13, holderHeight);
            int colListValue14 = CheckHeightToPrice(height14, holderHeight);
            int colListValue15 = CheckHeightToPrice(height15, holderHeight);

            //Create an object(product) based on the selected item in the combobox menu
            int comboboxIndex = CbboxProducts.SelectedIndex;

            if (CbboxProducts.SelectionBoxItem.ToString() == "Persienner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    persienner = new Persienner(listConvertedQuantity[i], "Persienner", listConvertedWidth[i], listConvertedHeight[i]);
                    listPersienner.Add(persienner);
                }

                for (int i = 0; i < listPersienner.Count; i++)
                {
                    dataGrid = new DataGrid(persienner.ToString(), persienner.quantity, persienner.width, persienner.height);

                }

                foreach (var item in listPersienner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }

            else if (CbboxProducts.SelectionBoxItem.ToString() == "Rullgardiner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    rullgardiner = new Rullgardiner(listConvertedQuantity[i], "Rullgardiner", listConvertedWidth[i], listConvertedHeight[i]);
                    listRullgardiner.Add(rullgardiner);
                }

                for (int i = 0; i < listRullgardiner.Count; i++)
                {
                    dataGrid = new DataGrid(rullgardiner.ToString(), rullgardiner.quantity, rullgardiner.width, rullgardiner.height);
                }

                foreach (var item in listRullgardiner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }
            else if (CbboxProducts.SelectionBoxItem.ToString() == "Plisségardiner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    plissegardiner = new Plissegardiner(listConvertedQuantity[i], "Plisségardiner", listConvertedWidth[i], listConvertedHeight[i]);
                    listPlissegardiner.Add(plissegardiner);
                }

                for (int i = 0; i < listPlissegardiner.Count; i++)
                {
                    dataGrid = new DataGrid(plissegardiner.ToString(), plissegardiner.quantity, plissegardiner.width, plissegardiner.height);
                }

                foreach (var item in listPlissegardiner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }
            else if (CbboxProducts.SelectionBoxItem.ToString() == "Honeycellgardiner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    honeycellgardiner = new Honeycellgardiner(listConvertedQuantity[i], "Honeycellgardiner", listConvertedWidth[i], listConvertedHeight[i]);
                    listHoneycellgardiner.Add(honeycellgardiner);
                }

                for (int i = 0; i < listHoneycellgardiner.Count; i++)
                {
                    dataGrid = new DataGrid(honeycellgardiner.ToString(), honeycellgardiner.quantity, honeycellgardiner.width, honeycellgardiner.height);
                }

                foreach (var item in listHoneycellgardiner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }
            else if (CbboxProducts.SelectionBoxItem.ToString() == "Lamellgardiner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    lamellgardiner = new Lamellgardiner(listConvertedQuantity[i], "Lamellgardiner", listConvertedWidth[i], listConvertedHeight[i]);
                    listLamellgardiner.Add(lamellgardiner);
                }

                for (int i = 0; i < listLamellgardiner.Count; i++)
                {
                    dataGrid = new DataGrid(lamellgardiner.ToString(), lamellgardiner.quantity, lamellgardiner.width, lamellgardiner.height);
                }

                foreach (var item in listLamellgardiner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }
            else if (CbboxProducts.SelectionBoxItem.ToString() == "Träpersienner")
            {
                for (int i = 0; i < listConvertedQuantity.Count; i++)
                {
                    trapersienner = new Trapersienner(listConvertedQuantity[i], "Träpersienner", listConvertedWidth[i], listConvertedHeight[i]);
                    listTrapersienner.Add(trapersienner);
                }

                for (int i = 0; i < listTrapersienner.Count; i++)
                {
                    dataGrid = new DataGrid(trapersienner.ToString(), trapersienner.quantity, trapersienner.width, trapersienner.height);
                }

                foreach (var item in listTrapersienner)
                {
                    dataGrid = new DataGrid(items[comboboxIndex].Category + ": " + items[comboboxIndex].Name, item.quantity, item.width, item.height);
                    listDataGrid.Add(dataGrid);
                }
            }


            //Add info to textboxes
            double sum = listDataGrid.Sum(price => price.PricePerPiece);
            sum = dataGrid.Quantity * sum;
            TxtboxPrice.Text = sum.ToString();

            TxtboxTotalPriceSum.Text = TxtboxTotalPriceSum.ToString();

            TxtboxTotalPriceSumExclTax.Text = dataGrid._PriceExclTax.ToString();
            TxtboxPrice.Text = dataGrid.PriceInclTax.ToString();

            DataGridXAML.ItemsSource = listDataGrid;

        }

        private void AddProductSelection()
        {

        }

        private void BtnRemoveSelectedCellsDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridXAML.SelectedItem;
            if (selectedItem != null)
            {
                try
                {
                    //CHANGE TO REMOVE OBJECTS FROM LIST INSTEAD OF DATAGRID
                    DataGridXAML.Items.Remove(selectedItem);
                    DataGridXAML.Items.Refresh();
                }
                catch (Exception)
                {
                }
            }
        }

        int SizeRounded(string sizeText)
        {
            int roundedValue = 0;
            if (sizeText != "")
            {
                //Parse to int
                try
                {
                    size = int.Parse(sizeText);
                }
                catch (Exception)
                {

                }
                //Round to closest 10
                int rounded = ExtensionMethods.RoundOff(size);
                roundedValue = rounded;
                return roundedValue;
            }
            return roundedValue;
        }

        int CheckWidthSizing(int width)
        {
            if (width != 0)
            {
                if (width <= 50) return width = 50;
                else if (width >= 220) return width = 220;
                else return width;
            }
            else return width;
        }

        int CheckHeightSizing(int height)
        {
            if (height != 0)
            {
                if (height <= 50) return height = 50;
                else if (height >= 220) return height = 220;
                else return height;
            }
            else return height;
        }

        int CheckWidthToPrice(int width, object[,] holderWidth)
        {
            int rowListValue = 0;

            for (int j = 1; j < holderWidth.Length + 1; j++)
            {
                if (width.ToString() == holderWidth[j, 1].ToString())
                {
                    rowListValue = j;
                    return rowListValue;
                }
            }
            return rowListValue;
        }
        int CheckHeightToPrice(int height, object[,] holderHeight)
        {
            int colListValue = 0;

            for (int k = 1; k < holderHeight.Length + 1; k++)
            {
                if (height.ToString() == holderHeight[1, k].ToString())
                {
                    colListValue = k;
                    return colListValue;
                }
            }
            return colListValue;
        }


        private void CbboxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Change the product label to match the combobox category
            LabelProductSelected.Content = items[CbboxProducts.SelectedIndex].ToString();
        }

        private void BtnDeleteAllCellsDataGrid_Click(object sender, RoutedEventArgs e)
        {
            listDataGrid.Clear();
            DataGridXAML.Items.Refresh();
        }
        private void NumberValidationTextBoxQuantity(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberValidationTextBoxMeasurements(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
