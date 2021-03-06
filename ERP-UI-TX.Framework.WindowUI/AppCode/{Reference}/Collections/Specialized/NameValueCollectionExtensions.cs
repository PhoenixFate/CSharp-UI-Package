#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Specialized
{
    public static class NameValueCollectionExtensions
    {
        public static bool ContainsKey(this NameValueCollection list, string key)
        {
            return list.AllKeys.Any(k => k.ToLower() == key.ToLower());
        }

        public static bool ContainsValue(this NameValueCollection list, string value)
        {
            string[] values = new string[list.Count];
            list.CopyTo(values, 0);
            return values.Any(v => v.ToLower() == value.ToLower());
        }

        public static string[] Values(this NameValueCollection list)
        {
            string[] values = new string[list.Count];
            list.CopyTo(values, 0);
            return values;
        }
    }
}
