using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMaxSumElement
{
    public class ItemDoc
    {
        public string Item { get; set; }
        public bool DefectiveFlag { get; set; }
        public float Summ { get; set; }    
        public int lineNumber { get; set; }

        public ItemDoc()
        { }

        public ItemDoc(string str, bool flg, float summ, int number)
        {
            Item = str;
            DefectiveFlag = flg;
            Summ = summ;
            lineNumber = number;
        }
    }
}
