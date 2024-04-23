public class BillService
{
    private bool ValidateBillId(string billId)
    {

        bool result = true;

        //check length & the 0's on the left
        char firstDigit = billId[0];

        if (billId.Length > 13 || firstDigit == '0')
        {
            return false;
        }

        result = ValidateCheckDigit(billId);

        return result;
    }

    private bool ValidatePaymentId(string paymentId, string billId)
    {

        bool result = true;

        //check length
        if (paymentId.Length < 6 || paymentId.Length > 13)
        {
            return false;
        }

        result = ValidateCheckDigit(billId + paymentId);

        return result;
    }


    public bool ValidateCheckDigit(string variable)
    {

        bool result = true;

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
            result = res.Equals(checkDigit);
        }
        else
        {
            result = res.Equals(checkDigit);
        }

        return result;
    }


    public bool Validate(Bill bill)
    {

        bool result = false;

        if (ValidateBillId(bill.BillId) == true && ValidatePaymentId(bill.PaymentId, bill.BillId) == true)

        {
            result = true;
        }
        return result;
    }









}