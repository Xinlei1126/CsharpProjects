Console.WriteLine("Enter product names. ");
Console.WriteLine("Entered product names should be in this format 'LETTERS - NUMBER', e.g., 'Apple - 200'.");
Console.WriteLine("Left side:Letters only (A-Z) and Right side:Numbers only (200 - 500)");
Console.WriteLine("Type 'exit' to finish");
Console.WriteLine("All products will be displayed after exiting.");

List<string> products = new List<string>();


while (true)
{
    Console.Write("Enter a product name: ");
    string? product = Console.ReadLine();

    // Check if the input is empty
    if (string.IsNullOrWhiteSpace(product))
    {
        Console.WriteLine("Input cannot be empty. Try a valid input again.");
        continue;
    }

    product = product.Trim();

    // Stop the loop when the user enters "exit"
    if (product.ToLower() == "exit")
    {
        break;
    }

    // Make sure the product contains a dash

    // Split the input into left and right parts based on the dash
    string[] parts = product.Split('-');
    if (parts.Length != 2)
    {
        Console.WriteLine("Product name must contain a dash (-).");
        Console.WriteLine("Please use the format 'LETTERS - NUMBER'.");
        continue;
    }
        
    string leftPart = parts[0].Trim();
    string rightPart = parts[1].Trim();

    // Check that the left side contains only A-Z or a-z
    bool IsEnglishLetter(char letter)
    {
        return (letter >= 'A' && letter <= 'Z') ||
               (letter >= 'a' && letter <= 'z');
    }
    if (!leftPart.All(IsEnglishLetter))
    {
        Console.WriteLine("The left side should contain letters only (A-Z or a-z).");
        continue;
    }

    // Check that the right side contains numbers only
    if (!int.TryParse(rightPart, out int number))
    {
        Console.WriteLine("The right side should contain numbers only.");
        continue;
    }

    // Check that the number is between 200 and 500
    if (number < 200 || number > 500)
    {
        Console.WriteLine("The right side number should be between 200 and 500.");
        continue;
    }

    // Store the product in a consistent format
    string letters = leftPart;
    product = letters + " - " + number;
    products.Add(product);

}

products.Sort();


// Display all valid products after sorting
Console.WriteLine("All entered products in sorted order: ");
int productIndex = 0;
foreach (var enteredProduct in products)
{
    productIndex++;
    Console.WriteLine($"Product {productIndex}: " + enteredProduct);
}

Console.WriteLine("\nPress any key to continue...");
Console.ReadKey();
