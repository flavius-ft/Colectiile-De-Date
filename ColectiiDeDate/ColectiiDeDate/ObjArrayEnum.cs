using System;
using System.Collections;

namespace ColectiiDeDate
{
    class ObjArrayEnum : IEnumerator
    {
        private readonly object[] array;
        int position = -1;

        public ObjArrayEnum(object[] array)
        {
            this.array = array;
        }

        public object Current => array[position];

        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
