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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TX.Framework.WindowUI.Controls
{
    public class TemplateColumnHeaderCollection : CollectionBase
    {
        public delegate void InvalidateEventHandler();
        public event InvalidateEventHandler Invalidate;

        protected virtual void OnInvalidate()
        {
            if (this.Invalidate != null)
            {
                this.Invalidate();
            }
        }

        public TemplateColumnHeader this[int index]
        {
            get
            {
                try
                {
                    if (List.Count >= 1)
                    {
                        return (TemplateColumnHeader)List[index];
                    }
                    return null;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("Index", index, "There is no such index value in this collection.");
                }
            }
        }

        public void Add(string template)
        {
            TemplateColumnHeader header = new TemplateColumnHeader();
            header.Text = template;
            header.Template = template;
            List.Add(header);
        }

        public void Add(string template, int width)
        {
            TemplateColumnHeader header = new TemplateColumnHeader();
            header.Text = template;
            header.Template = template;
            header.Width = width;
            List.Add(header);
        }

        public void Add(string text, string template)
        {
            TemplateColumnHeader col = new TemplateColumnHeader();
            col.Text = text;
            col.Template = template;
            List.Add(col);
        }

        public void Add(string text, string template, int width)
        {
            TemplateColumnHeader col = new TemplateColumnHeader();
            col.Text = text;
            col.Template = template;
            col.Width = width;
            List.Add(col);
        }

        public void Add(TemplateColumnHeader Item)
        {
            List.Add(Item);
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            this.OnInvalidate();
        }

        protected override void OnInsertComplete(int index, object value)
        {
            this.OnInvalidate();
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            this.OnInvalidate();
        }

        protected override void OnClearComplete()
        {
            this.OnInvalidate();
        }
    }
}