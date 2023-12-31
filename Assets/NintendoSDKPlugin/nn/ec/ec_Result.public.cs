﻿/*--------------------------------------------------------------------------------*
  Copyright (C)Nintendo All rights reserved.

  These coded instructions, statements, and computer programs contain proprietary
  information of Nintendo and/or its licensed developers and are protected by
  national and international copyright laws. They may not be disclosed to third
  parties or copied or duplicated in any form, in whole or in part, without the
  prior written consent of Nintendo.

  The content herein is highly confidential and should be handled accordingly.
 *--------------------------------------------------------------------------------*/

#if (UNITY_SWITCH || UNITY_EDITOR || NN_PLUGIN_ENABLE) && NN_EC_SHOP_SERVICE_ENABLE
namespace nn.ec
{
    public partial class ShopServiceAccessor
    {
        public static ErrorRange ResultCanceled { get { return new ErrorRange(164, 30, 31); } }
        public static ErrorRange ResultInternetRequestNotAccepted { get { return new ErrorRange(164, 56, 57); } }
        public static ErrorRange ResultInsufficientWorkMemory { get { return new ErrorRange(164, 90, 91); } }
        public static ErrorRange ResultInsufficientBuffer { get { return new ErrorRange(164, 91, 92); } }
    }

    public static partial class ConsumableServiceItem
    {
        public static ErrorRange ResultCanceled { get { return new ErrorRange(164, 30, 31); } }
        public static ErrorRange ResultInternetRequestNotAccepted { get { return new ErrorRange(164, 56, 57); } }
        public static ErrorRange ResultInsufficientWorkMemory { get { return new ErrorRange(164, 90, 91); } }
        public static ErrorRange ResultInsufficientBuffer { get { return new ErrorRange(164, 91, 92); } }
    }
}
#endif
