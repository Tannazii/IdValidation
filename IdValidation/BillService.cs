public class BillService
{
    private bool ValidateBillId(string billId)
    {
        //check length & the 0's on the left

        if (billId.Length < 6 || billId.Length > 13)
            return false;


        bool result = ValidateCheckDigit(billId);

        return result ;

    }

    private bool ValidatePaymentId(string paymentId, string billId)
    {
        //check length
        if (paymentId.Length < 6 || paymentId.Length > 13)
            return false;


        bool result = ValidateCheckDigit(billId + paymentId);
        bool firstChkDigit = ValidateCheckDigit(paymentId.Substring(0, paymentId.Length - 1));

        return result && firstChkDigit;
    }


    public bool ValidateCheckDigit(string variable)
    {

        //check checkDigit
        int checkDigit = Convert.ToInt32(variable.Substring(variable.Length - 1, 1));
        string billWithoutCheckDigit = variable.Substring(0, variable.Length - 1);

        string reversedText = new string(billWithoutCheckDigit.Reverse().ToArray());

        int sum = 0;
        int mulNumber = 2;

        for (int i = 0; i <= reversedText.Length - 1; i++)
        {
            sum += Convert.ToInt32(reversedText[i].ToString()) * mulNumber;

            if (mulNumber == 7)
            {
                mulNumber = 2;
                continue;
            }

            mulNumber++;
        }

        int residual = sum % 11;
        int res = 0;

        if (residual > 1)
        {

            res = Math.Abs(residual - 11);
            return res.Equals(checkDigit);
        }
        else
        {
            return res.Equals(checkDigit);
        }
    }


    public bool Validate(Bill bill)
    {
        if (ValidateBillId(bill.BillId) == true && ValidatePaymentId(bill.PaymentId, bill.BillId) == true)
            return true;
        else
            return false;
    }









}