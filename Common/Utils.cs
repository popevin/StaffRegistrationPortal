namespace StaffRegistrationPortal.Common
{
    public class Utils
    {
        public static string ErrorBuilder(List<string> error)
        {
            string? validationMessage = string.Empty;
            int loop = 0;
            int counter = 0;

            error.ForEach(x =>
            {
                if (loop == error.Count - 1)
                {

                    counter++;
                    validationMessage += $"{counter}. " + x;
                }
                else
                {
                    counter++;
                    if (loop == 0)
                        validationMessage += $"{counter}. " + x + " | ";
                    else
                    {
                        validationMessage += $"{counter}. " + x + " | ";
                    }
                    loop++;
                }
            });
            return validationMessage;
        }
    }
}
