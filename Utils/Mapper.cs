using RectangularSheet.Models;
using System;
using System.Collections.Generic;

namespace RectangularSheet.Utils
{
    public static class Mapper
    {
        public static List<Detail> Map(this List<DetailDto> source)
        {
            var result = new List<Detail>();
            foreach (var d in source)
            {
                if(d.Height == null || d.Width == null || d.Count == null)
                {
                    continue;
                }
                result.Add(new Detail
                {
                    Width = Convert.ToInt32(d.Width),
                    Height = Convert.ToInt32(d.Height),
                    Count = Convert.ToInt32(d.Count),
                }); 
            }

            return result;
        }
    }
}
