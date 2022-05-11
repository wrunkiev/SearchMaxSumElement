using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchMaxSumElement.Tests
{
    [TestClass]
    public class FileServiceTests
    {        
        private string filePath = @"test.txt";
        private string[] fileLines = {"12,3.4,f,4,5.7,123,45.678,d,6,90",
                                  "34,5.6,25.78,1.3,1,45,890,2.4,23",
                                  "45,23,5.6,1.567,x,6.78,12,67,3.5",
                                  "",
                                  "67,78,12.34,45.67,78,890,12,45.8",
                                  "3,9,5,7,23,56,889.345,12,45,67.5",
                                  "-23,-2.56,0,4,56"};

        [TestInitialize]
        public void TestInit()
        {            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }            

            File.WriteAllLines(filePath, fileLines);            
        }

        [TestMethod]
        public void GetFileContent_StringPath_StringArray()
        {
            //arrange
            FileService fs = new FileService();           

            //act            
            string[] result = fs.GetFileContent(filePath);

            //assert
            for (int i = 0; i < fileLines.Length; i++)
            {
                Assert.AreEqual(fileLines[i], result[i]);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Create(filePath).Close();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }        
    }
}
