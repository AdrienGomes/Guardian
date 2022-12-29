namespace GuardianProject.Common.SpecificServices.Contract
{
    /// <summary>
    /// Analisys services to get intel from microphone records (native)
    /// </summary>
    public interface ISoundMeterService : IBaseService
    {
        /// <summary>
        /// Get the amplitude of the sound recorded from the microphone
        /// </summary>
        /// <returns>The absolute amplitude of the sound recorded</returns>
        /// <remarks> It is recommended to use that method through the <see cref="IBaseService.Call(System.Func{object})"/> method for optimal behavior</remarks>
        double GetSoundAmplitude();
    }
}
