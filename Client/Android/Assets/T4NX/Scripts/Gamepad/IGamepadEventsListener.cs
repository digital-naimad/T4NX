
namespace T4NX
{
    public interface IGamepadEventsListener
    {
        /// <summary>
        /// Callback on direction button UP PRESSED
        /// </summary>
        void OnUpPressed(short data);
        /// <summary>
        /// Callback on gamepad direction button UP RELEASED
        /// </summary>
        void OnUpReleased(short data);

        /// <summary>
        /// Callback on gamepad direction button DOWN PRESSED
        /// </summary>
        void OnDownPressed(short data);
        /// <summary>
        /// Callback on gamepad direction button DOWN RELEASED
        /// </summary>
        void OnDownReleased(short data);

        /// <summary>
        /// Callback on gamepad direction button LEFT PRESSED
        /// </summary>
        void OnLeftPressed(short data);
        /// <summary>
        /// Callback on gamepad direction button LEFT RELEASED
        /// </summary>
        void OnLeftReleased(short data);

        /// <summary>
        /// Callback on gamepad direction button RIGHT PRESSED
        /// </summary>
        void OnRightPressed(short data);
        /// <summary>
        /// Callback on gamepad direction button RIGHT RELEASED
        /// </summary>
        void OnRightReleased(short data);

        /// <summary>
        /// Callback on gamepad button SELECT PRESSED
        /// </summary>
        void OnSelectPressed(short data);
        /// <summary>
        /// Callback on gamepad button SELECT RELEASED
        /// </summary>
        void OnSelectReleased(short data);

        /// <summary>
        /// Callback on gamepad button START PRESSED
        /// </summary>
        void OnStartPressed(short data);
        /// <summary>
        /// Callback on gamepad button START RELEASED
        /// </summary>
        void OnStartReleased(short data);

        /// <summary>
        /// Callback on gamepad action button B PRESSED
        /// </summary>
        void OnBPressed(short data);
        /// <summary>
        /// Callback on gamepad action button B RELEASED
        /// </summary>
        void OnBReleased(short data);

        /// <summary>
        /// Callback on gamepad action button A PRESSED
        /// </summary>
        void OnAPressed(short data);
        /// <summary>
        /// Callback on gamepad action button A RELEASED
        /// </summary>
        void OnAReleased(short data);




    }
}
