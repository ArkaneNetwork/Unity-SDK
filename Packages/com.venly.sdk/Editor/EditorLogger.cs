using UnityEditor;

namespace ArkaneNetwork.VenlySDK.Editor
{
    [InitializeOnLoad]
    public class EditorLogger
    {
        // Static constructor that runs when Unity Editor starts
        static EditorLogger()
        {
            UnityEngine.Debug.Log("Venly SDK Editor initialized by Arkane Network!");
        }
    }
}
