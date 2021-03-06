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

namespace System.Office.Excel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FromRangeAttribute : Attribute
    {
        private Category _Category = Category.Formatted;
        public Category Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private string _StartCellAddress;
        public string StartCellAddress
        {
            get { return _StartCellAddress; }
        }

        private string _EndCellAddress;
        public string EndCellAddress
        {
            get { return _EndCellAddress; }
        }

        public FromRangeAttribute(string startCellAddress, string endCellAddress)
        {
            _StartCellAddress = startCellAddress;
            _EndCellAddress = endCellAddress;
        }

        public FromRangeAttribute(string startCellAddress, string endCellAddress, Category category)
        {
            _StartCellAddress = startCellAddress;
            _EndCellAddress = endCellAddress;
            _Category = category;
        }
    }
}
