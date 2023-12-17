class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the directory path:");
        string directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            OrganizeFiles(directoryPath);
            Console.WriteLine("Files organized successfully!");
        }
        else
        {
            Console.WriteLine("Directory not found. Please provide a valid directory path.");
        }

        Console.ReadLine(); // Keep the console window open
    }

    static void OrganizeFiles(string directoryPath)
    {
        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            string extension = Path.GetExtension(filePath);
            string destinationFolder = Path.Combine(directoryPath, extension.TrimStart('.'));

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(filePath));

            File.Move(filePath, destinationPath);
        }
    }
}
