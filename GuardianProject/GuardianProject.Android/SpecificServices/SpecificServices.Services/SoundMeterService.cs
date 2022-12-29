using Android;
using Android.Media;
using GuardianProject.Common;
using GuardianProject.Common.SpecificServices.Contract;
using Java.Lang;
using System.Collections.Generic;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(GuardianProject.Droid.SpecificServices.SpecificServices.Services.SoundMeterService))]
namespace GuardianProject.Droid.SpecificServices.SpecificServices.Services
{
    internal class SoundMeterService : BaseService, ISoundMeterService
    {
        private MediaRecorder mRecorder = null;

        protected override IEnumerable<string> DevicePermissions { get; set; } = new[] { Manifest.Permission.RecordAudio };

        /// <summary>
        /// Starts and creates a media recorder
        /// </summary>
        private void Start()
        {


            if (mRecorder == null)
            {
                mRecorder = new MediaRecorder(MainActivity.GetContext());
                mRecorder.SetAudioSource(AudioSource.Mic);
                mRecorder.SetOutputFormat(OutputFormat.ThreeGpp);
                mRecorder.SetAudioEncoder(AudioEncoder.AmrNb);
                mRecorder.SetAudioSamplingRate(8000);
                mRecorder.SetAudioEncodingBitRate(12200);
                mRecorder.SetOutputFile($"{MainActivity.GetContext().GetExternalFilesDir(null).AbsolutePath}/test.3gp");

                try
                {
                    mRecorder.Prepare();
                    Thread.Sleep(1000);
                    mRecorder.Start();
                    _ = mRecorder.MaxAmplitude;
                }
                catch (IllegalStateException e)
                {
                    ServiceFactory.logger.Error($"illegal state -> {e.Message}");
                }
                catch (IOException e)
                {
                    ServiceFactory.logger.Error($"io -> {e.Message}");
                }
                catch (Java.Lang.Exception e)
                {
                    ServiceFactory.logger.Error($"java.runtime -> {e.Message}");
                }

            }

        }


        /// <summary>
        /// Stops and destroy media recorder
        /// </summary>
        private void Stop()
        {

            if (mRecorder != null)
            {
                try
                {
                    mRecorder.Stop();
                    mRecorder.Release();
                    mRecorder = null;
                }
                catch (IllegalStateException e)
                {
                    ServiceFactory.logger.Error($"illegal state -> {e.Message}");
                }
                catch (IOException e)
                {
                    ServiceFactory.logger.Error($"io -> {e.Message}");
                }
                catch (Java.Lang.Exception e)
                {
                    ServiceFactory.logger.Error($"java.runtime -> {e.Message}");
                }
            }
        }

        /// <summary>
        /// Retrun the amplitude of the sound recorded
        /// </summary>
        /// <returns>The amplitude value (peak to peak)</returns>
        private int GetAmplitude()
        {

            int amp = 0;
            while (amp == 0 && mRecorder != null)
            {
                amp = mRecorder.MaxAmplitude;
            }

            return amp;

        }

        /// <inheritdoc/>
        public double GetSoundAmplitude()
        {

            try
            {
                // Start recording
                Start();

                // Collecting the amplitude
                int amp = GetAmplitude();

                // Stoping recording
                Stop();

                // Returning amplitude as a double
                return amp != 0 ? Math.Round(20 * Math.Log10(amp)) : 0;
            }
            catch
            {
                mRecorder.Release();
                mRecorder = null;
                return 0;
            }




        }

    }
}