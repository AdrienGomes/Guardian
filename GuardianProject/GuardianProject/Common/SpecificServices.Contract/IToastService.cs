namespace GuardianProject.Common.SpecificServices.Contract
{
    /// <summary>
    /// An interface to lunch toast messages on native plateforms
    /// </summary>
    public interface IToasytService : IBaseService
    {
        /// <summary>
        /// Show a toas type message
        /// </summary>
        /// <param name="message"> The message</param>
        /// <param name="isLongToast">If the message should last or not</param>
        /// /// <remarks> It is recommended to use that method through the <see cref="IBaseService.Call(System.Func{object})"/> method for optimal behavior</remarks>
        void ShowToast(string message, bool isLongToast = false);
    }
}