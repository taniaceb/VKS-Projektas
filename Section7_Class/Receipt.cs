using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7_Class
{
    class Receipt
    {
        private int receiptNumber;
        private string dateOfPurchase;
        private int customerNumber;
        private string customerName;
        private string customerAdress;
        private string customerPhoneNumber;
        private int itemNumber;
        private string description;
        private double unitPrice;
        private int quantityPurchased;


        public Receipt(int recNumber, string date, int cusNumber, string name, string adress, string phone, int item, string desc, double price, int quantity)
        {
            ReceiptNumber = recNumber;
            DateOfPurchase = date;
            CustomerNumber = cusNumber;
            CustomerName = name;
            CustomerAdress = adress;
            CustomerPhoneNumber = phone;
            ItemNumber = item;
            Description = desc;
            UnitPrice = price;
            QuantityOfPurchase = quantity;
        }

        public int ReceiptNumber
        {
            get  { return receiptNumber; }
            set
            {
                if(value>0)
                {
                    receiptNumber = value;
                }
              
            }

        }

        public string DateOfPurchase
        {
            get  { return dateOfPurchase; }
            set { dateOfPurchase = value; }
        }

        public int CustomerNumber
        {
            get { return customerNumber; }
            set
            {
                if (customerNumber > 0)
                {
                    customerNumber = value;
                }
                else
                {
                    Console.WriteLine("Error customer number must be >0");
                }
            }

        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string CustomerAdress
        {
            get { return customerAdress; }
            set { customerAdress = value; }
        }

        public string CustomerPhoneNumber
        {
            get { return customerPhoneNumber; }
            set { customerPhoneNumber = value; }
        }

        public int ItemNumber
        {
            get { return itemNumber; }
            set
            {
                if (value > 0 && value<9999)
                {
                    itemNumber = value;
                }
                else
                {
                    Console.WriteLine("Error item number must be >0 and  < 9999");
                }
            }

        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set
            {
                if (value > 0 && value < 9999)
                {
                    unitPrice = value;
                }
                else
                {
                    Console.WriteLine("Error unit price must be >0 and  < 9999");
                }
            }

        }

        public int QuantityOfPurchase
        {
            get { return quantityPurchased; }
            set
            {
                if (value > 0)
                {
                    quantityPurchased = value;
                }
                else
                {
                    Console.WriteLine("Error quantity must be >0");
                }
            }

        }

        public double TotalCost ()
        {
            return unitPrice * quantityPurchased;
        }

        public override string ToString()
        {
            return "Customer: " + customerName +
           '\n' + "Customer phone: " + customerPhoneNumber +
           '\n' + "Total purchase: " + string.Format("{0:0.00}", TotalCost());

        }
    }
}
