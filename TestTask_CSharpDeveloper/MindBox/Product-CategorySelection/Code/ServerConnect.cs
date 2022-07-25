namespace Product_CategorySelection.Code
{
    public sealed class ServerConnect
    {
        private String connectionString = string.Empty;
        private static DirectoryInfo rootDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        public String GetConnection()
        {
            if (!rootDir.Exists) throw new DirectoryNotFoundException("Directory doesnt exist");
            if (!rootDir.Parent.Exists) throw new DirectoryNotFoundException("Directory doesnt exist");
            rootDir = rootDir.Parent;
            if (!rootDir.Parent.Exists) throw new DirectoryNotFoundException("Directory doesnt exist");
            rootDir = rootDir.Parent;
            if (!rootDir.Parent.Exists) throw new DirectoryNotFoundException("Directory doesnt exist");
            rootDir = rootDir.Parent;
            rootDir = new DirectoryInfo(Path.Combine(rootDir.FullName, @"root"));
            if (!rootDir.Exists) throw new DirectoryNotFoundException("Directory doesnt exist");

            var filePath = Path.Combine(rootDir.FullName, "appconfig.txt");
            if (!File.Exists(filePath)) throw new FileNotFoundException("File doesnt exist");

            return connectionString = File.ReadAllText(filePath);
        }
    }
}
