﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Deanery.Interfaces
{
    interface IMyList<T>
    {
        List<T> Value { get; }

        void Add(T item);
        bool Remove(T item);
        T Find(T item);
        int FindIndex(T item);
        void Replace(int id, T item);

        void Fill();
        void Update();
    }
}
