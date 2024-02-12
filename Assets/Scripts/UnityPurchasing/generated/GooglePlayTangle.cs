// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("o7DYnMoqo7y2ccnl5HQhP3XPsP05Lhtq31aDL2AQB3b7vVTFoc7OMMFz8NPB/Pf423e5dwb88PDw9PHybrOYZapUHoXCbW7ZPsdz3BB7dLtrvs1JziGn57CUx08eyk3g+v7WwOehQGXugw1SZ9iAdqe6ub/Dg8cVTDU4NFP0/lgI80CKpIdtGRLucNpz8P7xwXPw+/Nz8PDxcxMAieqrNFgK/TboXjSjFvrNb3pn6/MD2KxWM2GuhFtilSYwLasnRLFbxqTdsOQTF+VNag2DKmxBmG+Az/yuhymlyqiTnMAJNqm6MHDyuM6gnaQD2kxrK/1FHnTfb3R7i8y8bbESi8+vO06t09LPHQjBwN6WVUoh0q+sc7swwWHmkbiI6Pj/2vPy8PHw");
        private static int[] order = new int[] { 12,4,12,6,12,6,6,12,13,13,13,12,12,13,14 };
        private static int key = 241;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
