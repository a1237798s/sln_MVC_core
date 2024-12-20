namespace prj_MVC_core.Models
{
    public class CMyClass
    {
        public TCustomer customer1;
        public CMyClass(TCustomer customer2) 
        {
            customer1= customer2;
        }
        public void insert1() 
        {
            TCustomer customer = new TCustomer();   
            customer.FName= "Test";
            customer.FPhone = "097711231";
            new DbdemoContext().TCustomers.Add(customer);
        }

        public void insert2(TCustomer customer)
        {           
            new DbdemoContext().TCustomers.Add(customer);
        }

        public void insert3()
        {
            new DbdemoContext().TCustomers.Add(customer1);
        }
     
    }
}
