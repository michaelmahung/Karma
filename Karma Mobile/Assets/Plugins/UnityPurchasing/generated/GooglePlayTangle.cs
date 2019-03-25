#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("SbHOwXksTWp2hnauX0TCv6KIh3vFRkhHd8VGTUXFRkZH7qX8BktqBTd/Lm/3345RMkZbFjYwarkxCv7oTWZZQT++b7wvSBWbMkO0h0zHKLAUD2rq2oP3Zqg2wzKgXVBhhAxGKwAwh9NDo3xpfZDdCPVwkpdYY4aSYA0grwa098gPP+bRsZ55baWdls00vaIk3b+J6GCSs8nK++V8jP2KX75eXk3qyO2Hdyc/zMT1SRJHPusi2gWzQUdZJ7QqIWVK/Nce1oRpKVlpgR0GviAfkjQJEuAPzkZZOFX2T6DeN9aGLoCKWekWLA56NcVStteMd8VGZXdKQU5twQ/BsEpGRkZCR0TsKQEThH4BtwdQNPrlgDD/MAJXwWlxVglBrE5/3EVERkdG");
        private static int[] order = new int[] { 7,1,8,9,4,9,10,11,8,13,13,12,12,13,14 };
        private static int key = 71;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
