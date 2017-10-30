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
using InventorySystem.Models;
using InventorySystem.Models.PartModel;
using Nito.AsyncEx;

namespace InventorySystem.Modules
{
    public class PartModule : ObservableObject
    {
        #region Fields
        private IRepository _repository;
        private double _partCount;

        #endregion

        public PartModule(IRepository repository)
        {
            _repository = repository;
            LoadParts();
        }

        #region Load Fields
        public ObservableCollection<PartModel> PartsList { get; } = new ObservableCollection<PartModel>();
        public INotifyTaskCompletion PartLoading { get; private set; }
        #endregion

        #region LoadHelper
        public double PartCount
        {
            get { return _partCount; }
            set
            {
                _partCount = value;
                RaisePropertyChanged(nameof(PartCount));
            }
        }
        #endregion

        #region Public Load
        public void LoadParts()
        {
            PartLoading = NotifyTaskCompletion.Create(LoadPartAsync());
        }

        private async Task LoadPartAsync()
        {
            PartsList.Clear();
            //var sorted = CollectionViewSource.GetDefaultView(AttendanceList11);
            var list = await _repository.Parts.GetRangeAsync(CancellationToken.None);
            float count = list.Count;
            int x = 0;

            foreach (var item in list)
            {
                PartsList.Add(new PartModel(item, _repository));
                await Task.Delay(1);
                x++;
                PartCount = (x / count) * 100;
            }
            x = 0;
            var sorted = CollectionViewSource.GetDefaultView(PartsList);
            sorted.SortDescriptions.Add(new SortDescription("Model.Name", ListSortDirection.Descending));
        }
        #endregion
    }
}
