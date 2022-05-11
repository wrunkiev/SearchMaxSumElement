using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMaxSumElement
{
    interface IDocument
    {
        void Init(string [] fileLines);
        public ItemDoc GetDocumentMaxValue();
        public List<ItemDoc> GetDocumentNonNumber(); 
    }
}
