namespace GuardianProject.Common.SpecificServices.Contract
{
    public interface IToasytService
    {
        /// <summary>
        /// Show a toas type message
        /// </summary>
        /// <param name="message"> The message</param>
        /// <param name="isLongToast">If the message should last or not</param>
        void ShowToast(string message, bool isLongToast = false);
    }
}