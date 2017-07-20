using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Gloabl
{
    /// <summary>
    /// 地图marker配置
    /// </summary>
    public class MapMarkerConfig
    {
        public static readonly string PERSON_MARKER = System.Environment.CurrentDirectory + "\\resources\\images\\人物.png";

        public static readonly string EVENT_MARKER = System.Environment.CurrentDirectory + "\\resources\\images\\事件.png";

        public static readonly int PERSON_MARKER_SIZE = 24;

        public static readonly int EVENT_MARKER_SIZE = 24;

        public static readonly double PERSOM_MARKER_OPACITY = 0.5;

        public static readonly double EVENT_MARKER_OPACITY = 0.5;

    }
}
