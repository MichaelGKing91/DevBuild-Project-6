using System;
using System.Collections.Generic;

namespace POSProject
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


        public Product(string name, string category, string desc, double price)
        {
            Name = name;
            Category = category;
            Description = desc;
            Price = price;
        }

        public override string ToString()
        {
            return $" - Item: {Name}\n - Category: {Category}\n - Desc: {Description}\n - Price: ${Price:0.00}";
        }

        public void SetQuantity(int quan)
        {
            Quantity = quan;
        }

    }
    public class Calcs
    {
        public static double CalcSubtotal(int quantity, double price)
        {
            return quantity * price;
        }
        public static double CalcTotalTax(double subTotal)
        {
            return subTotal * 0.07;
        }
        public static double CalcGrandTotal(double totalTax, double runningSubTotal)
        {
            return totalTax + runningSubTotal;
        }

        public static double GetAmountTendered(double amountTendered)
        {
            return amountTendered;
        }

        public static double CalcChange(double amountTendered, double grandTotal)
        {
            return amountTendered - grandTotal;
        }
    }

    public class MenuItems
    {
        public List<Product> realMenu = new List<Product>();
        public void MakeInitialMenu()
        {
            realMenu.Add(new Product("Coffee", "beverage", "a delicious and refreshing energy enhancing beverage", 4.60));
            realMenu.Add(new Product("Milk", "beverage", "a delicious and refreshing smooth-flow beverage", 2.46));
            realMenu.Add(new Product("Soda", "beverage", "a delicious and refreshing carbonated beverage", 3.59));
            realMenu.Add(new Product("Chocolate", "candy", "a rich and creamy chocolate candy, ", 6.60));
            realMenu.Add(new Product("Stars", "candy", "a delectible and savory fruity delight", 14.60));
            realMenu.Add(new Product("Straws", "utensil", "drinks made easy", 55.60));
            realMenu.Add(new Product("Banana", "fruit", "a nice fruit", 42.60));
            realMenu.Add(new Product("Plum", "fruit", "a nice pitted fruit", 22.61));
            realMenu.Add(new Product("Soup", "dinner", "a delicious and refreshing energy enhancing food", 4.60));
            realMenu.Add(new Product("Pizza", "snack", "a delicious and refreshing smooth-flow food", 2.46));
            realMenu.Add(new Product("Bagles", "breakfast", "a delicious and refreshing breakfast bite", 3.59));
            realMenu.Add(new Product("Syrup", "condiment", "a rich and creamy food topping, ", 6.60));

        }

        public void DisplayMenu()
        {
            // Present a menu to the user and let them choose an item (by number or letter).
            //  • Allow the user to choose a quantity for the item ordered.
            //  • Give the user a line total(item price * quantity).
            int index = 0;
            foreach (Product thisProd in realMenu)
            {
                index++;
                Console.WriteLine($"--- Product {index} ---");
                Console.WriteLine(thisProd);
                Console.WriteLine();
            }
        }
        public Product SelectProd(int userSel)
        {
            return realMenu[userSel];
        }


    }



    public class Program
    {
        public static bool DoneYN()
        {
            string doneString = Console.ReadLine().ToLower();
            while (doneString != "y" && doneString != "yes" && doneString != "n" && doneString != "no")
            {
                Console.Write("Invalid respone || Please type 'Y' or 'N': ");
                doneString = Console.ReadLine();
            }
            if (doneString == "n" || doneString == "no")
            {
                return true;
            }
            return false;

        }

        static void Main(string[] args)
        {
            List<Product> myCart = new List<Product>();
            MenuItems myMenu = new MenuItems();
            myMenu.MakeInitialMenu();
            myMenu.DisplayMenu();

            double totalTax = 0;
            double runningSubtotal = 0;
            double grandTotal = 0;

            bool done = false;
            while (!done)
            {
                Console.Write("Please select an item by number: ");
                int userSel = Convert.ToInt32(Console.ReadLine());
                userSel = userSel - 1;
                Product selectedProd = myMenu.SelectProd(userSel);
                Console.WriteLine();
                Console.WriteLine($"You selected {selectedProd.Name} @ ${selectedProd.Price:0.00}ea.");
                Console.WriteLine();
                Console.Write("How many would you like to buy? ");
                selectedProd.Quantity = Convert.ToInt32(Console.ReadLine());
                double subtotal = Calcs.CalcSubtotal(selectedProd.Quantity, selectedProd.Price);
                totalTax += Calcs.CalcTotalTax(subtotal);
                runningSubtotal += subtotal;

                Console.WriteLine(
                    $"\nAdded to cart..." +
                    $"\n- Item: {selectedProd.Name}" +
                    $"\n- Quantity: {selectedProd.Quantity}" +
                    $"\n- Price: {selectedProd.Price:0.00}" +
                    $"\n===================" +
                    $"\nSubtotal: ${subtotal:0.00}");

                //Console.WriteLine("Continue shopping [1], reveiw cart[2], checkout[3]");
                myCart.Add(selectedProd);
                Console.WriteLine();
                Console.Write("Continue (Y/N): ");
                done = DoneYN();
            }
            grandTotal = Calcs.CalcGrandTotal(totalTax, runningSubtotal);

            Console.Write("How much money will you be paying with: ");
            double cash = Convert.ToDouble(Console.ReadLine());
            double change = Calcs.CalcChange(cash, grandTotal);
            Console.WriteLine($"\nYou owed: {grandTotal}" +
                $"\nYou paid: ${cash:0.00}" +
                $"\nYour Change: ${change:0.00}");

            Console.WriteLine("You purchased...");
            //Recipt
            foreach (Product cur in myCart)
            {
                Console.WriteLine(
                    $"\n- Item: {cur.Name}" +
                    $"\n- Quantity: {cur.Quantity}" +
                    $"\n- Price: ${cur.Price:0.00}");


            }
        }
    }
}
