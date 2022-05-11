using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SearchMaxSumElement.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private readonly Document _doc;

        public DocumentTests()
        {
            _doc = new Document();
        }

        [DataRow("1,2,f,4,5", true, 0, 1)]
        [DataRow("1,2,3.1,4,5", false, (float)15.1, 1)]
        [DataRow("", true, 0, 1)]
        [DataRow("1,2,3,4,5", false, 15, 1)]
        [DataRow(",,,,", true, 0, 1)]
        [TestMethod]
        public void Init_StringArray_List(string line, bool flag, float sum, int number)
        {
            //arrange
            string [] array =  {line};                      

            //act            
            _doc.Init(array);

            //assert           
            Assert.AreEqual(line, _doc.GetDocument().FirstOrDefault().Item);
            Assert.AreEqual(flag, _doc.GetDocument().FirstOrDefault().DefectiveFlag);
            Assert.AreEqual(sum, _doc.GetDocument().FirstOrDefault().Summ);
            Assert.AreEqual(number, _doc.GetDocument().FirstOrDefault().lineNumber);                     
        }

        [TestMethod]
        public void GetDocumentMaxValue_ListItemDoc_ItemDoc()
        {
            //arrange
            List<ItemDoc> items = new List<ItemDoc>();
            ItemDoc item_1 = new ItemDoc("1,2,f,4,5", true, 0, 1);
            ItemDoc item_2 = new ItemDoc("1,2,3.1,4,5", false, (float)15.1, 2);
            ItemDoc item_3 = new ItemDoc("", true, 0, 3);
            ItemDoc item_4 = new ItemDoc("1,2,3,4,5", false, 15, 4);
            items.Add(item_1);
            items.Add(item_2);
            items.Add(item_3);
            items.Add(item_4);

            Document doc = new Document(items);            

            //act            
            ItemDoc itemDoc = doc.GetDocumentMaxValue();

            //assert            
            Assert.AreEqual(itemDoc.Item, item_2.Item);
            Assert.AreEqual(itemDoc.DefectiveFlag, item_2.DefectiveFlag);
            Assert.AreEqual(itemDoc.lineNumber, item_2.lineNumber);
            Assert.AreEqual(itemDoc.Summ, item_2.Summ);            
        }

        [TestMethod]
        [DataRow("1,2,f,4,5", true, 0, 1)]
        [DataRow("", true, 0, 1)]
        [DataRow(",,,,", true, 0, 1)]
        public void GetDocumentNonNumber_ListItemDoc_ListItemDocNonNumber(string line, bool flag, float sum, int number)
        {
            //arrange
            string[] array = {line};                      

            //act  
            _doc.Init(array);
            List<ItemDoc> itemsNonNumber = _doc.GetDocumentNonNumber();

            //assert    
            Assert.AreEqual(line, itemsNonNumber.FirstOrDefault().Item);
            Assert.AreEqual(flag, itemsNonNumber.FirstOrDefault().DefectiveFlag);
            Assert.AreEqual(sum, itemsNonNumber.FirstOrDefault().Summ);
            Assert.AreEqual(number, itemsNonNumber.FirstOrDefault().lineNumber);
        }
    }
}
