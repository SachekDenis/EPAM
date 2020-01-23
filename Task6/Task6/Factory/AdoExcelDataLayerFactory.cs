﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Connections;

namespace Task6.Factory
{
    public class AdoExcelDataLayerFactory : ExcelDataLayerFactory
    {
        public AdoExcelDataLayerFactory(ExcelConnection connection) : base(connection)
        {}

        public override IExcelDataLayer<T> GetExcelDataLayer<T>()
        {
            return new ExcelDataLayer<T>(_connection);
        }
    }
}
