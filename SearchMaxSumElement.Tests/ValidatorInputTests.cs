using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchMaxSumElement.Tests
{
    [TestClass]
    public class ValidatorInputTests
    {
        [TestMethod]
        public void ValidateFilePath_StringNull_StringError()
        {
            //arrange
            string stringPath = "";

            ValidatorInput vi = new ValidatorInput();

            string expected = "Input path empty or null";

            //act            
            string result = vi.ValidateFilePath(stringPath);

            //assert
            
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void ValidateFilePath_StringFailedPath_StringError()
        {
            //arrange
            string stringPath = @"C:\Soft\Sources for Projects\test.txt";

            ValidatorInput vi = new ValidatorInput();

            string expected = "File wasn't found";

            //act            
            string result = vi.ValidateFilePath(stringPath);

            //assert

            Assert.AreEqual(expected, result);
        }        

        [TestMethod]
        public void ValidateFilePath_StringPath_String()
        {
            //arrange
            string filePath = @"test.txt";
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.Create(filePath).Close();

            ValidatorInput vi = new ValidatorInput();

            string expected = filePath;

            //act            
            string result = vi.ValidateFilePath(filePath);

            //assert
            Assert.AreEqual(expected, result);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }        
    }
}
