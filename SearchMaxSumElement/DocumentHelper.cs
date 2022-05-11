using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMaxSumElement
{
    public class DocumentHelper : IDocumentHelper
    {
        public string GetStringNonNumber(List<ItemDoc> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ItemDoc item in list)
            {
                sb.AppendFormat("{0}; ", item.lineNumber);
            }
            return sb.ToString();
        }
    }
}
