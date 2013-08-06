private static int GetHexLength(string number)
{
    int length = 0;
    if (number.Length % 4 != 0)
    {
        length = (number.Length / 4) + 1;
    }
    else
    {
        length = number.Length / 4;
    }
 
    return length;
}


private static char ConvertToHex(StringBuilder current)
{
    string result = current.ToString();
    string reduced = result.TrimStart('0');
    switch (reduced)
    {
        case "1": return '1';
        case "10": return '2';
        case "11": return '3';
        case "100": return '4';
        case "101": return '5';
        case "110": return '6';
        case "111": return '7';
        case "1000": return '8';
        case "1001": return '9';
        case "1010": return 'A';
        case "1011": return 'B';
        case "1100": return 'C';
        case "1101": return 'D';
        case "1110": return 'E';
        case "1111": return 'F';
        default: return '0';
    }
}


private static void Main()
{
    Console.Write("Please enter binary number: ");
    string binaryNumber = Console.ReadLine();
    StringBuilder number = new StringBuilder();
    number.Append(binaryNumber); 
    StringBuilder currentBinary = new StringBuilder();
    int hexIndex = GetHexLength(binaryNumber);
    char[] hexNumber = new char[hexIndex];
    while (number.Length > 3)
    {
        hexIndex--;
        currentBinary.Clear();
        for (int index = number.Length - 4; index < number.Length; index++)
        {
            currentBinary.Append(number[index]);
        }
 
        hexNumber[hexIndex] = ConvertToHex(currentBinary);
        number.Remove(number.Length - 4, 4);
    }
 
    if (number.Length > 0)
    {
        hexIndex--;
        hexNumber[hexIndex] = ConvertToHex(number);
    }
 
    for (int index = 0; index < hexNumber.Length; index++)
    {
        Console.Write(hexNumber[index]);
    }
 
    Console.WriteLine();
}
