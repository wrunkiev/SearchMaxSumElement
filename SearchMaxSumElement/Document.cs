using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SearchMaxSumElement
{
    public class Document : IDocument
    {
        private List<ItemDoc> _items;        

        public Document()
        { 
        
        }
        public Document(List<ItemDoc> items)
        {
            _items = items;
        }

        public List<ItemDoc> GetDocument()
        {            
            return _items;            
        }

        public void Init(string[] fileLines)
        {
            _items = new List<ItemDoc>();           
            int count = 1;
            float summ;
            foreach (string line in fileLines)
            {
                ItemDoc itemDoc = new ItemDoc();
                summ = 0;
                itemDoc.Item = line;
                itemDoc.DefectiveFlag = false;
                itemDoc.lineNumber = count++;
                string[] itemsLine = line.Split(',');

                SetItemDoc(itemsLine, itemDoc, summ);

                _items.Add(itemDoc);
            }                
        }       

        public ItemDoc GetDocumentMaxValue()
        {
            List<ItemDoc> itemsNumber = new List<ItemDoc>();
            itemsNumber = _items.Where(i => i.DefectiveFlag == false).ToList();
            var maxValue = itemsNumber.Max(i => i.Summ);
            ItemDoc itemMax = itemsNumber.FirstOrDefault(i => i.Summ >= maxValue && i.DefectiveFlag == false);            
            return itemMax;
        }

        public List<ItemDoc> GetDocumentNonNumber()
        {
            List<ItemDoc> itemsNonNumber = new List<ItemDoc>();
            itemsNonNumber = _items.Where(i => i.DefectiveFlag == true).ToList();            
            return itemsNonNumber; 
        }

        private void SetItemDoc(string[] items, ItemDoc itemDoc, float summ)
        {
            NumberStyles styles = NumberStyles.AllowDecimalPoint | NumberStyles.Integer;
            CultureInfo provider = CultureInfo.InvariantCulture;

            foreach (string item in items)
            {
                var itemWithoutSpice = item.Trim();
                if (float.TryParse(itemWithoutSpice, styles, provider, out float value))
                {
                    summ += value;
                    continue;
                }

                itemDoc.DefectiveFlag = true;
                summ = 0;
                break;                
            }
            itemDoc.Summ = summ;
        }
    }
}
