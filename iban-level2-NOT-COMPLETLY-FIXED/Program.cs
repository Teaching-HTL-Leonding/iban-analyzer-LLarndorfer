//*Iban analyzer
//*Lukas Larndorfer
Boolean isValid = true;
string iban = "";
string bankcode = "";
string accountnumber = "";
string command = "";
string country = "";
string nationalcheckdigit = "";
if (args.Length >= 1)
{
    command = args[0];
}
if (args.Length != 3 && command == "build")
{
    System.Console.WriteLine("Wrong number of arguments");
    isValid = false;
    return;
}

else if (args.Length != 2 && command == "analyze")
{
    System.Console.WriteLine("Wrong number of arguments");
    isValid = false;
    return;
}

if (command != "analyze" && command != "build")
{
    System.Console.WriteLine("Wrong or missing command.");
    isValid = false;
    return;
}

void Build(string bankcode, string accountnumber, string iban)
{
    if (args.Length != 3)
    {
        System.Console.WriteLine("Wrong number of arguments");
        isValid = false;
        return;
    }
    bankcode = args[1];
    accountnumber = args[2];
    if (!OnlyContainsDigits(bankcode) || !OnlyContainsDigits(accountnumber))
    {
        System.Console.WriteLine("Invalid Input - Only Numbers!");
    }


    if (args[1].Length != 4 || args[2].Length != 6)
    {
        System.Console.WriteLine("Invalid length of arguments!");
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
}

if (command == "build")
{ Build(bankcode, accountnumber, iban); }
else if (command == "analyze")
{
    Console.WriteLine(AnalyzeIban(bankcode, accountnumber, iban, country, nationalcheckdigit));
}

string AnalyzeIban(string bankcode, string accountnumber, string iban, string country, string nationalcheckdigit)
{

    country = args[1].Substring(0, 2);
    bankcode = args[1].Substring(4, 4);
    accountnumber = args[1].Substring(8, 6);
    iban = $"{country}00{bankcode}{accountnumber}{nationalcheckdigit}";
    nationalcheckdigit = args[1].Substring(14, 1);
    if (country != "NO")
    {
        isValid = false;
        return ("Wrong country code, we currently only support NO");
    }
    else if (nationalcheckdigit != "7")
    {
        isValid = false;
        return ("Wrong national check digit, we currently only support 7");

    }
    else if (iban.Length != 15)
    {
        isValid = false;
        return ("Wrong length of IBAN");

    }
    if (isValid)
    {
        return ($"Bank code is {bankcode} \nAccount number is {accountnumber}");
    }
    return ($"Error 404");
}

