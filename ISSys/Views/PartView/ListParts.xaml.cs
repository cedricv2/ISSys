using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using InventorySystem.Modules;

namespace InventorySystem.Views.PartView
{
    /// <summary>
    /// Interaction logic for ListParts.xaml
    /// </summary>
    public partial class ListParts : UserControl
    {
        public ListParts()
        {
            InitializeComponent();
        }

        #region Name
        public static T GetChildOfTypeProduct<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfTypeProduct<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void PreviewTextInput_EnhanceComboSearchProduct(object sender, TextCompositionEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            cmb.IsDropDownOpen = true;

            if (!string.IsNullOrEmpty(cmb.Text))
            {
                string fullText = cmb.Text.Insert(GetChildOfTypeProduct<TextBox>(cmb).CaretIndex, e.Text);
                cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList.Where(s => s.Model.Name.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else if (!string.IsNullOrEmpty(e.Text))
            {
                cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList.Where(s => s.Model.Name.IndexOf(e.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else
            {
                cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList;
            }
        }

        private void Pasting_EnhanceComboSearchProduct(object sender, DataObjectPastingEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            cmb.IsDropDownOpen = true;

            string pastedText = (string)e.DataObject.GetData(typeof(string));
            string fullText = cmb.Text.Insert(GetChildOfTypeProduct<TextBox>(cmb).CaretIndex, pastedText);

            if (!string.IsNullOrEmpty(fullText))
            {
                cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList.Where(s => s.Model.Name.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else
            {
                cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList;
            }
        }

        private void PreviewKeyUp_EnhanceComboSearchProduct(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                ComboBox cmb = (ComboBox)sender;

                cmb.IsDropDownOpen = true;

                Debug.WriteLine($" # cmb.Text po usunięciu: {cmb.Text}");

                if (!string.IsNullOrEmpty(cmb.Text))
                {
                    cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList.Where(s => s.Model.Name.IndexOf(cmb.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
                }
                else
                {
                    cmb.ItemsSource = ViewModelLocatorStatic.Locator.PartNameModule.PartNamesList;//DropdownNames
                }
            }
        }
        #endregion
    }
}
