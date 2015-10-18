namespace AirlineApp.BLL
{
    public static class AirlineConstants
    {
        public const string Route = "route";
        public const string Aircraft = "aircraft";
        public const string General = "general";
        public const string Airline = "airline";
        public const string Loyalty = "loyalty";
        public const string Input = "Input";
        public const string Output = "Output";
        public const string InvalidPathErrorMessage = "Invalid output Path, Please check \"DataFolders\" section in app.config! \n";
        public const string InvalidOutputPathErrorMessage = "Output: \"{0}\" \n" + InvalidPathErrorMessage;
        public const string SuccessMessage = "Output: \"{0}\" \n stored in {1} \n";

        public const string FileNotFoundErrorMessage = "File not found ! {0} \n";

        public const string InvalidData = "Invalid data in {0} ! \n";

        public const string InvalidSourcePath = "Invalid input Path, Please check \"DataFolders\" section in app.config! \n";
    }
}
