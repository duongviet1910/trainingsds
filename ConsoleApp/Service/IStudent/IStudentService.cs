﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Service.IStudent
{
    interface IStudentService
    {
        public void ListAllStudent();

        public void AddNewStudent();

        public void UpdateStudent();

        public void DeleteStudent();

        public void SortData();

        public void FindStudentById();
    }
}
