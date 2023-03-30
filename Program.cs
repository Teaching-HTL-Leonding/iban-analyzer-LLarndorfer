//*Iban analyzer
//*Lukas Larndorfer
Boolean isValid = true;
string iban = "";
string bankcode = args[0];
string accountnumber = args[1];


if (!OnlyContainsDigits(bankcode) || !OnlyContainsDigits(accountnumber))
{
    System.Console.WriteLine("Invalid Input - Only Numbers!");
}

if (args[0].Length != 4 || args[1].Length != 6)
{
    System.Console.WriteLine("Invalid length of arguments!");
    isValid = false;
}
if (args.Length != 2)
{
    System.Console.WriteLine("Wrong number of arguments");
    isValid = false;
}





string BuildIban(string bankcode, string accountnumber, string iban)
{
    iban = ($"NO00{bankcode}{accountnumber}7");
    System.Console.WriteLine(iban);
    return iban;
}
if (isValid)
{
    BuildIban(bankcode, accountnumber, iban);
}

bool OnlyContainsDigits(string text)
{
    for (int i = 0; i < text.Length; i++)
    {
        if (!char.IsDigit(text[i]))
        {
            isValid = false;
            return false;
        }
    }
    return true;
}
