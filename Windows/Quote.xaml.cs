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



            //Display correct items in the combobox menu
            items.Add(new ComboBoxCategory() { Name = "16mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm - Täta Stegband", Category = "Persienner" });
            items.Add(new ComboBoxCategory() { Name = "25mm - Färgtillägg 30%", Category = "Persienner" });
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
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
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
                dataGrid = new DataGrid(item.ToString(),item.quantity,item.width,item.height);
                listDataGrid.Add(dataGrid);
            }


            //Create an object(product) based on the selected item in the combobox menu
            if (CbboxProducts.SelectionBoxItem.ToString() == "")
            {

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
