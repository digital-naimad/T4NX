
namespace T4NX
{
    public interface IGamepadEventsListener
    {
        /// <summary>
        /// Callback on direction button UP PRESSED
        /// </summary>
        void OnUpPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad direction button UP RELEASED
        /// </summary>
        void OnUpReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad direction button DOWN PRESSED
        /// </summary>
        void OnDownPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad direction button DOWN RELEASED
        /// </summary>
        void OnDownReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad direction button LEFT PRESSED
        /// </summary>
        void OnLeftPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad direction button LEFT RELEASED
        /// </summary>
        void OnLeftReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad direction button RIGHT PRESSED
        /// </summary>
        void OnRightPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad direction button RIGHT RELEASED
        /// </summary>
        void OnRightReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad button SELECT PRESSED
        /// </summary>
        void OnSelectPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad button SELECT RELEASED
        /// </summary>
        void OnSelectReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad button START PRESSED
        /// </summary>
        void OnStartPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad button START RELEASED
        /// </summary>
        void OnStartReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad action button B PRESSED
        /// </summary>
        void OnBPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad action button B RELEASED
        /// </summary>
        void OnBReleased(params int[] data);

        /// <summary>
        /// Callback on gamepad action button A PRESSED
        /// </summary>
        void OnAPressed(params int[] data);
        /// <summary>
        /// Callback on gamepad action button A RELEASED
        /// </summary>
        void OnAReleased(params int[] data);




    }
}
