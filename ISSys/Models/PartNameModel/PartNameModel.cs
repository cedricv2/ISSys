using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.DataAccess;
using InventorySystem.DataAccess.EntityFramework;

namespace InventorySystem.Models.PartNameModel
{
    public class PartNameModel : ModelBase<PartName>
    {
        #region Fields
        private IRepository _repository;
        #endregion

        public PartNameModel(PartName model, IRepository repository) : base(model, repository)
        {
            _repository = repository;
        }
    }
}
