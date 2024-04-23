namespace IdValidation
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("start");

            Bill billAp = new Bill();

            Console.WriteLine("ENTER BILLID :");
            billAp.BillId = Console.ReadLine();


            Console.WriteLine("ENTER PAYMENTID :");
            billAp.PaymentId = Console.ReadLine();

            BillService service = new BillService();

            bool isvalid = service.Validate(billAp);
            Console.WriteLine($" billId or paymentid is {isvalid} ");


            Console.WriteLine("end");
        }
    }
}
