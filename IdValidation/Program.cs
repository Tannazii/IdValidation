namespace IdValidation
{
    class Program
    {
        public static void Main(String[] args)
        {
            bool isValid = false;
            do
            {
                Console.WriteLine("start");

                Bill billAp = new Bill();

                Console.WriteLine("ENTER BILLID :");
                billAp.BillId = Console.ReadLine();


                Console.WriteLine("ENTER PAYMENTID :");
                billAp.PaymentId = Console.ReadLine();

                BillService service = new BillService();

                isValid = service.Validate(billAp);
                Console.WriteLine($" billId or paymentid is {isValid} ");


                Console.WriteLine("end");
            }
            while(isValid == false);
        }
    }
}
