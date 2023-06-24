using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }


}
