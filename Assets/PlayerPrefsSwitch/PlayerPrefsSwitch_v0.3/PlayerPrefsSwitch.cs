#if UNITY_SWITCH

using System.Runtime.InteropServices;
 

namespace PlayerPrefsSwitch {

    public static class PlayerPrefsSwitch {

        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "PlayerPrefsSwitch_Init")]
        public static extern void Init();

        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "PlayerPrefsSwitch_Term")]
        public static extern void Term();

        [DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "PlayerPrefsSwitch_GetUserHandle")]
        public static extern void GetUserHandle(ref nn.account.UserHandle userHandle);

    }

}

#endif
