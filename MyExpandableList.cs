﻿namespace RefactoringExercise
{
    public class MyExpandableList
    {
        private object[] _elements = new object[10];
        private bool _readOnly;
        private int _size = 0;

        public void Add(object child)
        {
            if (!_readOnly)
            {
                if (ShouldGrow())
                {
                    object[] newElements = AddRows();

                    for (int i = 0; i < _size; i++)
                    {
                        newElements[i] = _elements[i];
                    }

                    _elements = newElements;
                }

                _elements[_size] = child;

                _size++;
            }
        }

        private bool ShouldGrow()
        {
            return _size + 1 > _elements.Length;
        }

        private object[] AddRows()
        {
            return new object[_elements.Length + 10];
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public int NumberOfElementsInList
        {
            get { return _size; }
        }

        public int Capacity
        {
            get { return _elements.Length; }
        }
    }
}