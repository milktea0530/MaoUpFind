﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Finding02_Query
    {
        public VM_Finding02_Query()
        {
            this.sortType = 0;
        }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int sortType { get; set; }
    }
}