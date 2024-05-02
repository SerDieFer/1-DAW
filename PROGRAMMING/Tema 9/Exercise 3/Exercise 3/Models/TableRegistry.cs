using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public abstract class TableRegistry
    {
        private TablesEnum tableValue;

        // ENUM OF DIFFERENT POSSIBLE TABLES TO INTERACT
        public enum TablesEnum
        {
            Users = 0,
            Characters = 1
        }

        public TablesEnum TableEnum
        {
            get => tableValue;
        }

        public TableRegistry(int selectedTable)
        {
            tableValue = (TablesEnum)selectedTable;
        }
    }
}
