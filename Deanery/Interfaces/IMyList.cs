﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Deanery.Interfaces
{
    interface IMyList<T>
    {
        List<T> Value { get; }

        void Add(T item);
        bool Remove(T item);
        bool RemoveAt(int index);
        T Find(T item);
        int FindIndex(T item);

        void OpenConnection(string connectionString);
        void CloseConnection();
        void Fill();
        bool Update();
    }
}