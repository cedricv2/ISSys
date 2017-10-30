using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.DataAccess.EntityFramework;

namespace InventorySystem.DataAccess
{
    public interface IRepository
    {
        IDataService<Brand> Brands { get; }
        IDataService<Category> Categories { get; }
        IDataService<Part> Parts { get; }
        IDataService<PartName> PartNames { get; }
        IDataService<Supplier> Suppliers { get; }
        //IDataService<Customer> Customers { get; }
        //IDataService<Delivery> Deliveries { get; }
        //IDataService<DeliveryInvoice> DeliveryInvoices { get; }
        //IDataService<DeliveryLine> DeliveryLines { get; }
        //IDataService<OrderInvoice> OrderInvoices { get; }
        //IDataService<BorrowedInvoice> BorrowedInvoices { get; }
        //IDataService<Order> Orders { get; }
        //IDataService<OrderLine> OrderLines { get; }

        //IDataService<Representative> Representatives { get; }
        //IDataService<PayableInvoice> PayableInvoices { get; }
    }

    public class EfRepository : IRepository
    {
        public IDataService<Brand> Brands { get; } = new EfDataService<Brand>();
        public IDataService<Category> Categories { get; } = new EfDataService<Category>();
        public IDataService<Part> Parts { get; } = new EfDataService<Part>();
        public IDataService<PartName> PartNames { get; } = new EfDataService<PartName>();
        public IDataService<Supplier> Suppliers { get; } = new EfDataService<Supplier>();
        //public IDataService<Customer> Customers { get; } = new EfDataService<Customer>();
        //public IDataService<Delivery> Deliveries { get; } = new EfDataService<Delivery>();
        //public IDataService<DeliveryInvoice> DeliveryInvoices { get; } = new EfDataService<DeliveryInvoice>();
        //public IDataService<DeliveryLine> DeliveryLines { get; } = new EfDataService<DeliveryLine>();
        //public IDataService<OrderInvoice> OrderInvoices { get; } = new EfDataService<OrderInvoice>();
        //public IDataService<BorrowedInvoice> BorrowedInvoices { get; } = new EfDataService<BorrowedInvoice>();
        //public IDataService<Order> Orders { get; } = new EfDataService<Order>();
        //public IDataService<OrderLine> OrderLines { get; } = new EfDataService<OrderLine>();
        
        //public IDataService<Representative> Representatives { get; } = new EfDataService<Representative>();
        //public IDataService<PayableInvoice> PayableInvoices { get; } = new EfDataService<PayableInvoice>();
    }
}
