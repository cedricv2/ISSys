using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using InventorySystem.DataAccess;

namespace InventorySystem.Models
{
    public class ModelBase<T> : ObservableObject
    {
        private T _model;
        protected IRepository _Repository;

        public ModelBase(T model)
        {
            Model = model;
        }

        public ModelBase(T model, IRepository repository)
        {
            Model = model;
            _Repository = repository;
        }

        public T Model
        {
            get { return _model; }
            protected set
            {
                _model = value;
                RaisePropertyChanged(nameof(Model));
            }
        }
    }
}
