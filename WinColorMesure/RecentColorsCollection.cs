using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WinColorMesure
{
    using Color = System.Drawing.Color;

    class RecentColorsCollection  : Collection<Color>
    {
        int _maxElements;

        public int MaxElements
        {
            get => _maxElements;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Must be a positive, non-zero value");
                }
                _maxElements = value;
            }
        }

        public RecentColorsCollection() : this(10)
        { }


        public RecentColorsCollection(IList<Color> list) : base(list)
        {
            MaxElements = list.Count;
        }

        public RecentColorsCollection(int maxElements) : base(new List<Color>(maxElements))
        {
            MaxElements = maxElements;
        }


        protected override void InsertItem(int index, Color item)
        {
            if (Contains(item))
            {
                var oldIndex = IndexOf(item);
                Color movedItem = this[oldIndex];

                base.RemoveItem(oldIndex);
                base.InsertItem(0, movedItem);
                return;
            }

            if (index == MaxElements)
            {
                base.RemoveItem(MaxElements - 1);
            }

            base.InsertItem(0, item);
        }


    }
}
