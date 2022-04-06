﻿using NUnit.Framework;
using System.IO;


namespace Task1.Tests
{
    public class SobelXFilter
    {

        [Test]

        public void SobelX()
        {
            FileOperations image = new FileOperations();
            Filters filters = new Filters();
            BitmapFileHeader bitmapFile = new BitmapFileHeader();
            BitmapFileHeader bMPFH = new BitmapFileHeader();
            BitmapInfoHeader bMPIH = new BitmapInfoHeader();



            FileStream fsT = new FileStream(@"..\..\..\..\..\Block1\Task1.Test\TestFiles\sunSX_t.bmp", FileMode.Open);
            BinaryReader brT = new BinaryReader(fsT, System.Text.Encoding.Default);

            image.ReadFile(ref bMPFH, ref bMPIH, ref brT);

            Pixel[,] masT = new Pixel[bMPIH.Hight + 4, bMPIH.Width + 4];

            image.Rat(ref bMPFH, ref bMPIH, masT);

            image.ReadPixel(ref bMPFH, ref bMPIH, masT, ref brT);

            brT.Close();

            FileStream fS = new FileStream(@"..\..\..\..\..\Block1\Task1.Test\TestFiles\sun.bmp", FileMode.Open);
            BinaryReader bR = new BinaryReader(fS, System.Text.Encoding.Default);

            image.ReadFile(ref bMPFH, ref bMPIH, ref bR);

            Pixel[,] mas = new Pixel[bMPIH.Hight + 4, bMPIH.Width + 4];

            image.Rat(ref bMPFH, ref bMPIH, mas);

            image.ReadPixel(ref bMPFH, ref bMPIH, mas, ref bR);

            bR.Close();


            filters.SobelX(ref bMPFH, ref bMPIH, mas);

            FileStream fO = new FileStream(@"..\..\..\..\..\Block1\Task1.Test\TestFiles\sunSX_new.bmp", FileMode.Create);
            BinaryWriter bW = new BinaryWriter(fO, System.Text.Encoding.Default);

            image.Save(ref bMPFH, ref bMPIH, mas, ref bW);

            bW.Close();


            fS = new FileStream(@"..\..\..\..\..\Block1\Task1.Test\TestFiles\sunSX_new.bmp", FileMode.Open);
            bR = new BinaryReader(fS, System.Text.Encoding.Default);

            image.ReadFile(ref bMPFH, ref bMPIH, ref bR);

            mas = new Pixel[bMPIH.Hight + 4, bMPIH.Width + 4];

            image.Rat(ref bMPFH, ref bMPIH, mas);

            image.ReadPixel(ref bMPFH, ref bMPIH, mas, ref bR);

            bR.Close();

            Assert.AreEqual(mas, masT);
        }
    }
}
