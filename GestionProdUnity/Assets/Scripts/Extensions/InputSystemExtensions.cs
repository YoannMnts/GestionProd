using UnityEngine.InputSystem;

namespace Extensions
{
    public static class InputSystemExtensions
    {
        public static void SetActionMaps(this InputActionAsset asset, params string[] names)
        {
            for (int i = 0; i < asset.actionMaps.Count; i++)
            {
                var actionMap = asset.actionMaps[i];
                
                bool active = false;
                for (int j = 0; j < names.Length; j++)
                {
                    if (names[j] == actionMap.name)
                    {
                        active = true;
                        break;
                    }
                }
                
                if (active)
                    actionMap.Enable();
                else
                    actionMap.Disable();
            }
        }
    }
}