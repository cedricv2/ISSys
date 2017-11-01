using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using InventorySystem.DataAccess;
using InventorySystem.Models.PartNameModel;
using Nito.AsyncEx;

namespace InventorySystem.Modules
{
    public class PartNameModule : ObservableObject
    {
        #region Fields
        private IRepository _repository;
        private double _partCount;

        #endregion

        public PartNameModule(IRepository repository)
        {
            _repository = repository;
            LoadPartNames();
        }

        #region Load Fields
        public ObservableCollection<PartNameModel> PartNamesList { get; } = new ObservableCollection<PartNameModel>();
        public INotifyTaskCompletion PartNameLoading { get; private set; }
        #endregion

        #region LoadHelper
        public double PartNameCount
        {
            get { return _partCount; }
            set
            {
                _partCount = value;
                RaisePropertyChanged(nameof(PartNameCount));
            }
        }
        #endregion

        #region Public Load
        public void LoadPartNames()
        {
            PartNameLoading = NotifyTaskCompletion.Create(LoadPartNameAsync());
        }

        private async Task LoadPartNameAsync()
        {
            PartNamesList.Clear();
            //var sorted = CollectionViewSource.GetDefaultView(AttendanceList11);
            var list = await _repository.PartNames.GetRangeAsync(CancellationToken.None);
            float count = list.Count;
            int x = 0;

            foreach (var item in list)
            {
                PartNamesList.Add(new PartNameModel(item, _repository));
                await Task.Delay(1);
                x++;
                PartNameCount = (x / count) * 100;
            }
            x = 0;
            var sorted = CollectionViewSource.GetDefaultView(PartNamesList);
            sorted.SortDescriptions.Add(new SortDescription("Model.Name", ListSortDirection.Descending));
        }
        #endregion
    }
}

