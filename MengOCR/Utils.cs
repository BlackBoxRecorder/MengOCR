using ImageMagick;
using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MengOCR
{
    internal static class Utils
    {


        public static bool IsImageFile(string file)
        {
            try
            {
                string ext = new FileInfo(file).Extension.ToLower();
                switch (ext)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".bitmap":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// 根据图片路径获取字节
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] GetImageByteByPath(string filePath)
        {
            byte[] buffer = null;
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();
                    return buffer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            return buffer;
        }



        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用
        }

        public static Image GetImageByPath(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch (Exception)
            {

            }

            return null;
        }


        public static string Structure2String(OCRStructureResult structureResult, bool spaceSeparate = false)
        {
            try
            {
                var rows = structureResult.Cells.GroupBy(r => r.Row);
                if (!rows.Any())
                {
                    return null;
                }
                var lines = new List<string>();
                foreach (var row in rows)
                {
                    var line = "";
                    foreach (var item in row)
                    {
                        if (string.IsNullOrEmpty(item.Text))
                        {
                            line += " ";
                        }
                        else
                        {
                            if (spaceSeparate)
                            {
                                line += item.Text + '\t';
                            }
                            else
                            {
                                line += item.Text;
                            }
                        }
                    }
                    lines.Add(line);
                }

                Console.WriteLine(lines);

                return string.Join("\n", lines.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }


        public static void ImgTest()
        {
            try
            {
                string imgtest = @"C:\Users\imyin\Pictures\MengOCR\默认工作区\2023-6-23 17.47.34.png";
                string imgwall = @"C:\yin-data\images\ImageOnline\1920×1080\0c47d355621d442d9c66c6f0232b0f81.jpg";

                var img = new MagickImage(imgtest);

                //img.BackgroundColor = MagickColor.FromRgb(0, 0xff, 0);
                var tiles = img.CropToTiles(198, 108);//切片
                img.Trim();
                //获取boundbox，计算边缘颜色

                img.Write("test.jpg");
                int idx = 0;
                foreach (var tile in tiles)
                {
                    idx++;
                    //tile.Write($"test{idx}.jpg");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }


}
