using System.Collections;

namespace ColectiiDeDate
{
    class ObjArrayEnum : IEnumerator
    {
        private readonly ObjectArray array;
        private int position = -1;

        public ObjArrayEnum(ObjectArray array) : base()
        {
            this.array = array;
        }

        public object Current => array[position];

        public bool MoveNext()
        {
            position++;
            return position < array.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
