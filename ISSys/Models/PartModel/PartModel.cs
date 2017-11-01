using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.DataAccess;
using InventorySystem.DataAccess.EntityFramework;

namespace InventorySystem.Models.PartModel
{
    public class PartModel : ModelBase<Part>
    {
        #region Fields
        private IRepository _repository;
        #endregion
        public PartModel(Part model, IRepository repository) : base(model, repository)
        {
            _repository = repository;
        }
    }
}
