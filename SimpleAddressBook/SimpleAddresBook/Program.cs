using System;

class AddressBook
{
    static void Main()
    {
        // Define an array of contacts (name, phone number)
        string[,] addressBook = new string[,]
        {
            { "Sipho", "071-123-3456" },
            { "Nqobile", "084-987-6543" },
            { "Samantha", "062-678-9012" },
            { "Nkabi Yezwe", "081-789-0123" },
            { "Evan", "081-890-1234" }
        };

        // Convert 2D array to jagged array for sorting
        string[][] jaggedArray = ConvertToJaggedArray(addressBook);

        // Sort the jagged array by the name (first column)
        Array.Sort(jaggedArray, (x, y) => string.Compare(x[0], y[0]));

        Console.WriteLine("Address Book (sorted by name):");
        DisplayAddressBook(jaggedArray);

        // Search for a contact
        Console.WriteLine("\nEnter the name to search:");
        string searchName = Console.ReadLine();

        // Perform binary search for the contact
        int index = BinarySearch(jaggedArray, searchName);

        if (index != -1)
        {
            Console.WriteLine($"Contact found: {jaggedArray[index][0]} - {jaggedArray[index][1]}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }

    // Function to convert the 2D array to a jagged array (for sorting purposes)
    static string[][] ConvertToJaggedArray(string[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        string[][] jaggedArray = new string[rows][];
        
        for (int i = 0; i < rows; i++)
        {
            jaggedArray[i] = new string[cols];
            for (int j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = array[i, j];
            }
        }

        return jaggedArray;
    }

    // Function to display the address book
    static void DisplayAddressBook(string[][] addressBook)
    {
        for (int i = 0; i < addressBook.Length; i++)
        {
            Console.WriteLine($"{addressBook[i][0]}: {addressBook[i][1]}");
        }
    }

    // Binary Search function for searching the address book by name
    static int BinarySearch(string[][] addressBook, string searchName)
    {
        int low = 0;
        int high = addressBook.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int comparison = string.Compare(addressBook[mid][0], searchName);

            if (comparison == 0)
            {
                return mid; // Contact found
            }
            else if (comparison < 0)
            {
                low = mid + 1; // Search in the right half
            }
            else
            {
                high = mid - 1; // Search in the left half
            }
        }

        return -1; // Contact not found
    }
}
