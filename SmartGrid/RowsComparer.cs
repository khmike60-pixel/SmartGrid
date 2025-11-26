using C1.Win.FlexGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrid
{
    public class RowsComparer : IComparer
    {
        private int colIndex;
        private string colName;
        private int sortingModifire;

        public SortingType Type { get; set; }

        public RowsComparer(SortingType _type, string _colName)
        {
            colName = _colName;
            Type = _type;
            if (_type == SortingType.Descending)
                sortingModifire = -1;
            else if (_type == SortingType.Ascending)
                sortingModifire = 1;
        }

        public RowsComparer(SortingType _type, int _colIndex = 0)
        {
            colIndex = _colIndex;
            Type = _type;
            if (_type == SortingType.Descending)
                sortingModifire = 1;
            else if (_type == SortingType.Ascending)
                sortingModifire = -1;
        }

        int IComparer.Compare(object x, object y)
        {
            Row row1 = (Row)x;
            Row row2 = (Row)y;

            int compareResult = 0;

            if (row1.Node.Data.ToString() == "}"
                || row2.Node.Data.ToString() == "}"
                || row1.Node.Data.ToString() == "]"
                || row2.Node.Data.ToString() == "]")
                compareResult = 0;
            else
            {
                if (colName != null)
                {
                    compareResult = String.Compare(
                    row1[colName].ToString(),
                    row2[colName].ToString());
                }
                else
                {
                    compareResult = String.Compare(
                    row1[colIndex].ToString(),
                    row2[colIndex].ToString());
                }
            }

            return compareResult * sortingModifire;
        }
    }
    public enum SortingType
    {
        Descending,
        Ascending
    }
}