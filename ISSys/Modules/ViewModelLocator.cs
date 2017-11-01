using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InventorySystem.DataAccess;

namespace InventorySystem.Modules
{
    public class ViewModelLocator
    {
        private static readonly IRepository Repository = new EfRepository();

        public ViewModelLocator()
        {
            PartModule = new PartModule(Repository);
            PartNameModule = new PartNameModule(Repository);
        }

        public PartModule PartModule { get; }
        public PartNameModule PartNameModule { get; }

    }
    public static class ViewModelLocatorStatic
    {
        public static ViewModelLocator Locator { get; } = Application.Current.Resources["Locator"] as ViewModelLocator;
    }
}
