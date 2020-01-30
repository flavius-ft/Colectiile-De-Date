﻿using System;

namespace ColectiiDeDate
{
    class IntArray
    {
        private int[] array;

        public IntArray()
        {
            // construiește noul șir
        }

        public void Add(int element)
        {
            // adaugă un nou element la sfârșitul șirului
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
        }

        public int Count()
        {
            // întorce numărul de elemente din șir
            return array.Length;
        }

        public int Element(int index)
        {
            // întoarce elementul de la indexul dat
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            // modifică valoarea elementului de la indexul dat
            array[index] = element;
        }

        public bool Contains(int element)
        {
            // întoarce true dacă elementul dat există în șir
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            // întoarce indexul elementului sau -1 dacă elementul nu se
            // regăsește în șir
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            // adaugă un nou element pe poziția dată
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
        }

        public void Clear()
        {
            // șterge toate elementele din șir
           for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public void Remove(int element)
        {
            // șterge prima apariție a elementului din șir
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    array[i] = 0;
                }
            }
        }

        public void RemoveAt(int index)
        {
            // șterge elementul de pe poziția dată
            array[index] = 0;
        }
    }
}
