using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchMaxSumElement.Tests
{
    [TestClass]
    public class DocumentHelperTests
    {
        private readonly DocumentHelper _docHelper;        

        public DocumentHelperTests()
        {
            _docHelper = new DocumentHelper();
        }

        [TestMethod]         
        public void GetStringNonNumber_List_String()
        {
            //arrange
            List<ItemDoc> items = new List<ItemDoc>();
            ItemDoc item_1 = new ItemDoc("1,2,f,4,5", true, 0, 1);            
            ItemDoc item_2 = new ItemDoc("", true, 0, 2);            
            items.Add(item_1);
            items.Add(item_2);            

            //act            
            string result = _docHelper.GetStringNonNumber(items);

            //assert            
            Assert.AreEqual("1; 2; ", result);
        }       
    }
}
