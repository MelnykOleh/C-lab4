using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Csharp
{
    class StudentListHandlerEventArgs : System.EventArgs
    {
        public string _nameCollection;
        public TypeChange _typeChanges;
        public int _position;


        public StudentListHandlerEventArgs(string nameCollection, TypeChange typeChanges, int position)
        {
            _nameCollection = nameCollection;
            _typeChanges = typeChanges;
            _position = position;
        }

        public string NameCollection
        {
            get
            {
                return _nameCollection;
            }

            init
            {
                _nameCollection = value;
            }
        }

        public TypeChange TypeChanges
        {
            get
            {
                return _typeChanges;
            }

            init
            {
                _typeChanges = value;
            }
        }

        public int Position
        {
            get
            {
                return _position;
            }

            init
            {
                _position = value;
            }
        }

        public override string ToString()
        {
            return $"Info about changes:\nName collection: {NameCollection}\nType changes: {TypeChanges}\nChnged student: {Position}\n";
        }
    }
}
