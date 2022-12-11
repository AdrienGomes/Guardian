using System.Threading.Tasks;
using Vapolia.WheelPickerForms;
using Xamarin.Forms;

namespace GuardianProject.Common
{
    public static class DynamicMotion
    {
        #region Properties
        public const uint FADETIME = 1000;
        public const int READINGTIME = 1500;
        #endregion

        #region members

        #endregion

        #region Constructor

        static DynamicMotion()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Asynchronous method to fade a visual element
        /// </summary>
        /// <param name="label"> The visual element to apply the fade effect</param>
        /// <param name="time"> The duration of the effect (in miliseconds)</param>
        /// <param name="InOut"> If true, the label will appear, else it will disapear</param>
        /// /// <remarks>Every element has to have its opacity to 0 to make this method efficient</remarks>
        /// <returns></returns>
        public static async Task FadeVisualElementAsync(this VisualElement element, uint time = FADETIME, bool inOut = true)
        {
            if (inOut)
                await element.FadeTo(1, time);
            else
                await element.FadeTo(0, time);
        }

        /// <summary>
        /// Asynchronous method to fade all the label of a StackLayout
        /// </summary>
        /// <param name="time"> The duration of the effect (in miliseconds)</param>
        /// <param name="InOut"> If true, the label will appear, else it will disapear</param>
        /// /// <remarks>Every element has to have its opacity to 0 to make this method efficient</remarks>
        public static async Task FadeStackAsync(this StackLayout sl, uint time = FADETIME, bool inOut = true)
        {
            // Fading all the labels in the page
            foreach (VisualElement element in sl.Children)
            {
                if (element is StackLayout)
                {
                    await FadeStackAsync((StackLayout)element);
                    continue;
                }
                    
                await element.FadeVisualElementAsync(time, inOut);
            }

        }

        /// <summary>
        /// Trigers a fading screen element after element
        /// </summary>
        /// <param name="frame"></param>
        /// <remarks>Every element has to have its opacity to 0 to make this method efficient</remarks>
        public static async Task FadeFrameAsync(this Frame frame, uint time = FADETIME, bool inOut = true)
        {
            if (frame.Content.GetType() == typeof(Frame))
                await FadeFrameAsync((Frame)frame.Content);
            else if (frame.Content.GetType() == typeof(StackLayout))
                await FadeStackAsync((StackLayout)frame.Content);

            await FadeVisualElementAsync(frame);

        }
        #endregion

    }
}
