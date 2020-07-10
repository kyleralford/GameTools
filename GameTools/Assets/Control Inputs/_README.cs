/*
 *
 *  These Control Input scripts use scriptable object variables as buttons and joysticks with Monobehavior components to drive them.
 *
 *  This allows these buttons and joysticks to...
 *      - be easily accessed from any script.
 *      - be renamed without public references breaking.
 *      - work with keystrokes, HID joysticks, and UnityEngine.UI buttons (unlike Unity's built in input system).
 *          - Multiple input systems can easily be used together and can be consolidated to one script / scriptable object pair.
 *          - Ex: a mobile user could use on screen UI buttons and / or a keyboard and mouse as inputs.
 *      - include methods within the scriptable object that allow developers to "press" the button from within code.
 *          - The methods are: VirtualPress(), VirtualTimer(), and VirtualHoldStart() / VirtualHoldEnd().
 *          - There are comments within ButtonInput.cs to explain further, if needed.
 *      - be attached to empty GameObjects, which is useful when creating controls for multiple platforms.
 *          - At build time, GameObjects with control schemes that are not used can easily be disabled.
 *      - be organized within the scene.
 *          - I recommend having one "Control Inputs" game object with children that hold controls for each build platform.
 *              - Mobile build platforms can have a canvas with all the user input UI elements inside.
 * 
 */
