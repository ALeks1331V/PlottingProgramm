using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlottingProgramm.Model;

namespace PlottingProgramm.ViewModel
{
    internal class VM
    {
        static private string _tableName;
        static private string _columnName;
        static private string _columnName2;
        static private string _columnName3;
        static private int _columnSize;
        
        public VM(string tableName, string columnName, int ColumnSize)
        {
            _tableName = tableName;
            _columnName = columnName;
            _columnSize = ColumnSize;
        }

        public VM(string tableName, string columnName, string columnName2, int ColumnSize)
        {
            _tableName= tableName;
            _columnName = columnName;
            _columnName2 = columnName2;
            _columnSize = ColumnSize;
        }
        public VM(string tableName, string columnName, string columnName2, string columnName3, int ColumnSize)
        {
            _tableName = tableName;
            _columnName = columnName;
            _columnName2 = columnName2;
            _columnName3 = columnName3;
            _columnSize = ColumnSize;
        }

        private WorkWithDataBase search1 = new WorkWithDataBase();
        public double[] array => search1.selectDataFromDB(_columnName, _tableName, _columnSize);

        private WorkWithDataBase search2 = new WorkWithDataBase();
        public double[] array2 => search2.selectDataFromDB(_columnName2, _tableName, _columnSize);

        private WorkWithDataBase strSearch = new WorkWithDataBase();
        public string[] arrayStr => strSearch.selectSTRDataFromDB(_columnName2, _tableName, _columnSize);

        private WorkWithDataBase strSearch2 = new WorkWithDataBase();
        public string[] arrayStr2 => strSearch2.selectSTRDataFromDB(_columnName3, _tableName, _columnSize);

    }
}
