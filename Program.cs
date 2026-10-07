

using System;

namespace Program
{
    internal class Program
    {

        // Question 1 Subscription Revenue Calculator

        /*static void Main(string[] args)
        {
            try
            {
                // Ask user for inputs
                Console.Write("Enter the current number of customers: ");
                int currentNumberOfCustomers = int.Parse(Console.ReadLine());

                Console.Write("Enter the monthly price per customer: ");
                decimal monthlyPricePerCustomer = decimal.Parse(Console.ReadLine());

                Console.Write("Enter the percentage price increase (e.g. 10 for 10%): ");
                decimal percentagePriceIncrease = decimal.Parse(Console.ReadLine());

                // Convert percentage to a decimal fraction (e.g. 10 => 0.10)
                decimal percentageIncreaseDecimal = percentagePriceIncrease / 100m;

                // Calculations
                decimal currentMonthlyRevenue = currentNumberOfCustomers * monthlyPricePerCustomer;
                decimal newPricePerCustomer = monthlyPricePerCustomer * (1 + percentageIncreaseDecimal);
                decimal projectedMonthlyRevenue = currentNumberOfCustomers * newPricePerCustomer;
                decimal projectedDollarIncrease = projectedMonthlyRevenue - currentMonthlyRevenue;

                // Display results with labels and two decimal places
                Console.WriteLine();
                Console.WriteLine($"Current monthly revenue: {currentMonthlyRevenue:F2}");
                Console.WriteLine($"New price per customer: {newPricePerCustomer:F2}");
                Console.WriteLine($"Projected monthly revenue: {projectedMonthlyRevenue:F2}");
                Console.WriteLine($"Projected dollar increase: {projectedDollarIncrease:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter whole number for customers and numeric values for price and percentage.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value too large: please enter smaller numeric values within the data type limits.");
            }
        }*/


        // Q2 Investment Doublilng Time
        /*static void Main(string[] args)
        {


            // Question 2 Investment Doubling Time

            Console.Write("Enter the annual return rate (as a percentage, e.g. 7.5): ");
            try
            {
                double annualReturnPercent = double.Parse(Console.ReadLine());

                if (annualReturnPercent <= 0)
                {
                    Console.WriteLine("Invalid rate: please enter a positive percentage greater than zero.");
                    return;
                }

                double annualReturnDecimal = annualReturnPercent / 100.0;
                double doublingTimeYears = Math.Log(2) / Math.Log(1 + annualReturnDecimal);

                // Round to two decimal places before displaying and classifying so
                // the classification always matches the displayed value.
                double roundedDoublingTimeYears = Math.Round(doublingTimeYears, 2);

                Console.WriteLine();
                Console.WriteLine($"Doubling time (years): {roundedDoublingTimeYears:F2}");

                string classification;
                if (roundedDoublingTimeYears < 10)
                {
                    classification = "Fast";
                }
                else if (roundedDoublingTimeYears <= 20)
                {
                    classification = "Moderate";
                }
                else
                {
                    classification = "Slow";
                }

                Console.WriteLine($"Classification: {classification}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter a numeric value for the annual return rate.");
            }
        }*/

        // Question 3 Delivery Region Triangle
        /*static void Main(string[] args)
        {

            // Question 3 Delivery Region Triangle
            Console.WriteLine();
            Console.WriteLine("Triangle area calculator for a delivery region:");
            Console.Write("Enter side a: ");
            try
            {
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Enter side b: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Enter side c: ");
                double sideC = double.Parse(Console.ReadLine());

                // Validate sides are greater than zero
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    Console.WriteLine("Invalid triangle: all side lengths must be greater than zero.");
                }
                // Validate triangle inequality: each pair must sum to more than the remaining side
                else if (sideA + sideB <= sideC)
                {
                    Console.WriteLine("Invalid triangle: side a + side b must be greater than side c.");
                }
                else if (sideA + sideC <= sideB)
                {
                    Console.WriteLine("Invalid triangle: side a + side c must be greater than side b.");
                }
                else if (sideB + sideC <= sideA)
                {
                    Console.WriteLine("Invalid triangle: side b + side c must be greater than side a.");
                }
                else
                {
                    // Valid triangle: compute area using Heron's formula
                    double semiperimeter = (sideA + sideB + sideC) / 2.0;
                    double area = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
                    Console.WriteLine($"Triangle area: {area:F2}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter numeric values for the three side lengths.");
            }



        }*/

        // Question 4 Cloud Usage Invoice
        /*static void Main(string[] args)
        {
            Console.WriteLine("Progressive tier pricing vs flat tier pricing:");
            Console.WriteLine("- Progressive tier pricing charges different rates for portions of usage across tiers (e.g., first X units at rate A, next Y units at rate B).");
            Console.WriteLine("- Flat tier pricing charges a single rate for all usage based on which tier the total usage falls into (i.e., all units billed at the final tier's rate).");
            Console.WriteLine();

            Console.Write("Enter the number of compute hours used: ");
            try
            {
                decimal computeHours = decimal.Parse(Console.ReadLine());

                if (computeHours < 0m)
                {
                    Console.WriteLine("Invalid input: number of hours cannot be negative.");
                    return;
                }

                // Progressive tier pricing:
                // first 100 hours at $0.12/hr
                // next 400 hours (101-500) at $0.09/hr
                // hours above 500 at $0.06/hr
                decimal usageCharge = 0m;

                if (computeHours <= 100m)
                {
                    usageCharge = computeHours * 0.12m;
                }
                else if (computeHours <= 500m)
                {
                    // charge first 100 at 0.12, remaining (up to 400) at 0.09
                    decimal hoursInSecondTier = computeHours - 100m;
                    usageCharge = (100m * 0.12m) + (hoursInSecondTier * 0.09m);
                }
                else
                {
                    // computeHours > 500: charge first 100 at 0.12, next 400 at 0.09, remaining at 0.06
                    decimal hoursAbove500 = computeHours - 500m;
                    usageCharge = (100m * 0.12m) + (400m * 0.09m) + (hoursAbove500 * 0.06m);
                }

                decimal serviceFee = usageCharge * 0.05m; // 5% service fee
                decimal totalInvoice = usageCharge + serviceFee;

                Console.WriteLine();
                Console.WriteLine($"Usage charge: {usageCharge:F2}");
                Console.WriteLine($"Service fee (5%): {serviceFee:F2}");
                Console.WriteLine($"Total invoice: {totalInvoice:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter a numeric value for compute hours.");
            }




        }*/

        //Question 5 Daily Sales Entry with a Sentinel
        /*static void Main(string[] args)
        {

            Console.WriteLine("Daily sales entry (enter -1 to finish):");

            int validSalesCount = 0;
            decimal totalSales = 0m;
            decimal saleAmount = 0m; // loop condition variable

            while (saleAmount != -1m)
            {
                Console.Write("Enter sale amount (-1 to finish): ");
                string input = Console.ReadLine();

                try
                {
                    decimal parsed = decimal.Parse(input);
                    saleAmount = parsed;

                    if (saleAmount == -1m)
                    {
                        // sentinel: do not include in totals
                        continue;
                    }

                    if (saleAmount < 0m)
                    {
                        Console.WriteLine("Invalid input: negative sale amounts are not allowed (use -1 to finish).");
                        continue;
                    }

                    // valid sale
                    validSalesCount++;
                    totalSales += saleAmount;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a numeric sale amount or -1 to finish.");
                    continue;
                }
            }

            Console.WriteLine();

            if (validSalesCount == 0)
            {
                Console.WriteLine("No valid sales were entered.");
            }
            else
            {
                decimal averageSale = totalSales / validSalesCount;
                Console.WriteLine($"Number of valid sales: {validSalesCount}");
                Console.WriteLine($"Total sales: {totalSales:F2}");
                Console.WriteLine($"Average sale: {averageSale:F2}");
            }
        }*/

        //Question 6 Investment Payback Simulator
        /*static void Main(string[] args)
        {
            Console.Write("Enter the initial investment amount: ");
            try
            {
                decimal initialInvestment = decimal.Parse(Console.ReadLine());

                Console.Write("Enter the expected monthly benefit: ");
                decimal monthlyBenefit = decimal.Parse(Console.ReadLine());

                if (initialInvestment <= 0m || monthlyBenefit <= 0m)
                {
                    Console.WriteLine("Invalid input: initial investment and monthly benefit must be greater than zero.");
                    return;
                }

                int month = 0;
                decimal cumulativeBenefits = 0m;
                const int maxMonths = 600;

                while (cumulativeBenefits < initialInvestment && month < maxMonths)
                {
                    month++;
                    cumulativeBenefits += monthlyBenefit;

                    decimal unrecovered = initialInvestment - cumulativeBenefits;
                    if (unrecovered < 0m)
                    {
                        // display 0.00 instead of negative
                        Console.WriteLine($"Month {month}: Unrecovered balance: {0.00m:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"Month {month}: Unrecovered balance: {unrecovered:F2}");
                    }
                }

                Console.WriteLine();

                if (cumulativeBenefits >= initialInvestment)
                {
                    Console.WriteLine($"Payback achieved in month {month}.");
                    Console.WriteLine($"Cumulative benefits at payback: {cumulativeBenefits:F2}");
                }
                else
                {
                    Console.WriteLine($"Payback not reached within {maxMonths} months.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter numeric values for the amounts.");
            }
        }*/

        //Question 7 Weekly Demand Bar Chart
        /*static void Main(string[] args)
        {
            // Weekly demand bar chart using arrays and loops only
            int[] dailyDemand = new int[7];

            for (int day = 0; day < dailyDemand.Length;)
            {
                Console.Write($"Enter demand for day {day + 1}: ");
                string input = Console.ReadLine();

                try
                {
                    int value = int.Parse(input);

                    if (value < 0)
                    {
                        Console.WriteLine("Invalid input: demand must be zero or greater. Please enter the value again.");
                        continue; // ask again for same day
                    }

                    dailyDemand[day] = value;
                    day++; // move to next day only after a valid entry
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a whole number (e.g., 0, 10, 25). Please try again.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input: number too large. Please enter a smaller whole number.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Weekly Demand Bar Chart:");

            for (int i = 0; i < dailyDemand.Length; i++)
            {
                int demand = dailyDemand[i];
                Console.Write($"Day {i + 1}: {demand} ");

                int asteriskCount = demand / 10; // one asterisk per 10 units
                for (int a = 0; a < asteriskCount; a++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }*/

        //Question 8 Customer Risk Score Method
        /*static int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive)
        {
            // Calculation only — no classification or I/O here
            return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ComputeRiskScore returns a numeric score; classification is done separately in Main.");

            try
            {
                Console.Write("Enter number of missed payments: ");
                int missedPayments = int.Parse(Console.ReadLine());

                Console.Write("Enter number of support tickets: ");
                int supportTickets = int.Parse(Console.ReadLine());

                Console.Write("Enter number of months inactive: ");
                int monthsInactive = int.Parse(Console.ReadLine());

                if (missedPayments < 0 || supportTickets < 0 || monthsInactive < 0)
                {
                    Console.WriteLine("Invalid input: values must be zero or greater.");
                    return;
                }

                int score = ComputeRiskScore(missedPayments, supportTickets, monthsInactive);

                string classification;
                if (score < 30)
                {
                    classification = "Low";
                }
                else if (score <= 59)
                {
                    classification = "Moderate";
                }
                else
                {
                    classification = "High";
                }

                Console.WriteLine();
                Console.WriteLine($"Risk score: {score}");
                Console.WriteLine($"Classification: {classification}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input: please enter whole numbers for the three values.");
            }
        }*/

        //Question 9 Transaction Anomaly Screening
        /*static void Main(string[] args)
        {
            Console.WriteLine("Transaction anomaly screening (first-pass)");

            int transactionCount = 0;
            while (true)
            {
                Console.Write("How many transaction amounts will be entered (3-20)? ");
                string countInput = Console.ReadLine();
                try
                {
                    transactionCount = int.Parse(countInput);
                    if (transactionCount >= 3 && transactionCount <= 20)
                    {
                        break;
                    }
                    Console.WriteLine("Please enter an integer between 3 and 20.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a whole number for the count.");
                }
            }

            decimal[] transactions = new decimal[transactionCount];

            for (int i = 0; i < transactionCount;)
            {
                Console.Write($"Enter amount for transaction {i + 1}: ");
                string amountInput = Console.ReadLine();
                try
                {
                    decimal amount = decimal.Parse(amountInput);
                    if (amount < 0m)
                    {
                        Console.WriteLine("Invalid input: transaction amount cannot be negative. Please enter again.");
                        continue; // retry same index
                    }

                    transactions[i] = amount;
                    i++; // advance only after valid entry
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a numeric amount (e.g., 12.34). Try again.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input: value too large. Please enter a smaller amount.");
                }
            }

            // Calculate total, min, max using loops
            decimal total = 0m;
            decimal min = transactions[0];
            decimal max = transactions[0];

            for (int i = 0; i < transactionCount; i++)
            {
                decimal value = transactions[i];
                total += value;
                if (value < min)
                {
                    min = value;
                }
                if (value > max)
                {
                    max = value;
                }
            }

            decimal mean = total / transactionCount;

            Console.WriteLine();
            Console.WriteLine($"Minimum: {min:F2}");
            Console.WriteLine($"Maximum: {max:F2}");
            Console.WriteLine($"Total: {total:F2}");
            Console.WriteLine($"Mean: {mean:F2}");
            Console.WriteLine();

            // Label each transaction
            for (int i = 0; i < transactionCount; i++)
            {
                decimal value = transactions[i];
                string label;
                if (value > mean * 1.5m)
                {
                    label = "Review";
                }
                else
                {
                    label = "Normal";
                }

                Console.WriteLine($"Transaction {i + 1}: {value:F2} - {label}");
            }
        }*/

        //Question 10 Seven Day Performance Summary
        /*static decimal[] ReadSevenDailySales()
        {
            decimal[] sales = new decimal[7];
            for (int i = 0; i < sales.Length;)
            {
                Console.Write($"Enter sales for day {i + 1}: ");
                // REVISED BY ME: changed string to string? to fix warning CS8600
                string? input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("No input received: please enter a numeric value for the sales amount.");
                    continue; // ask again for the same day
                }

                try
                {
                    decimal value = decimal.Parse(input);
                    if (value < 0m)
                    {
                        Console.WriteLine("Invalid input: sales must be zero or greater. Please try again.");
                        continue;
                    }

                    sales[i] = value;
                    i++; // advance after valid entry
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: please enter a numeric value (e.g., 123.45). Try again.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input: value too large. Please enter a smaller number.");
                }
            }

            return sales;
        }

        static decimal TotalSales(decimal[] sales)
        {
            decimal total = 0m;
            for (int i = 0; i < sales.Length; i++)
            {
                total += sales[i];
            }
            return total;
        }

        static decimal AverageSales(decimal[] sales)
        {
            decimal total = TotalSales(sales);
            return total / sales.Length;
        }

        static decimal HighestSales(decimal[] sales)
        {
            decimal max = sales[0];
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                }
            }
            return max;
        }

        static decimal LowestSales(decimal[] sales)
        {
            decimal min = sales[0];
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    min = sales[i];
                }
            }
            return min;
        }

        static int CountDaysAboveAverage(decimal[] sales, decimal average)
        {
            int count = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > average)
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            // Collect seven nonnegative decimal sales values
            decimal[] weeklySales = ReadSevenDailySales();

            // Display daily list
            Console.WriteLine();
            Console.WriteLine("Daily sales:");
            for (int i = 0; i < weeklySales.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: {weeklySales[i]:F2}");
            }

            // Compute summary measures via methods
            decimal total = TotalSales(weeklySales);
            decimal average = AverageSales(weeklySales);
            decimal highest = HighestSales(weeklySales);
            decimal lowest = LowestSales(weeklySales);
            int daysAboveAverage = CountDaysAboveAverage(weeklySales, average);

            Console.WriteLine();
            Console.WriteLine($"Total sales: {total:F2}");
            Console.WriteLine($"Average sales: {average:F2}");
            Console.WriteLine($"Highest sales: {highest:F2}");
            Console.WriteLine($"Lowest sales: {lowest:F2}");
            Console.WriteLine($"Days above average: {daysAboveAverage}");

            // Classification in Main
            string classification;
            if (daysAboveAverage >= 4)
            {
                classification = "Strong";
            }
            else if (daysAboveAverage >= 2)
            {
                classification = "Balanced";
            }
            else
            {
                classification = "Concentrated";
            }

            Console.WriteLine($"Week classification: {classification}");
        }*/


    }
}
