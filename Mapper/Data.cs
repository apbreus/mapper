using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
 

namespace Mapper
{

    //область
    public class AreaListItem : IComparable<AreaListItem>
    {
        public int i;
        public string id;
        public string title;
        public string alt;
        public string coords;
        public bool linked;             //область связана с горячей точкой
        public int hotspotI;            //индекс горячей точки, с которой связана область
        public bool selected;           //область выбрана (активна)
        public int x, y, w, h;
        public Rectangle rect;
        public AreaListItem()
        {
            rect = new Rectangle();
        }
        public int CompareTo(AreaListItem item)
        {
            return this.title.CompareTo(item.title);
        }
    }

    //горячая точка
    public class HotspotListItem : IComparable<HotspotListItem>
    {
        public int i;
        public string id;
        public string title;
        public bool linked;             //горячая точка связана с одной или несколькими областями
        public List<int> areaI;         //список индексов областей, с которыми связана горячая точка
        public HotspotListItem()
        {
            areaI = new List<int>();
        }
        public int CompareTo(HotspotListItem item)
        {
            return this.title.CompareTo(item.title);
        }
    }

    public enum LinkedType
    {
        none = 0,
        unlinked = 1,
        linked = 2
    }

    public enum MouseMode
    {
        select = 0,
        rect = 1
    }
}
