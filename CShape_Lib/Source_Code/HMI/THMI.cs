using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using EFC.Tool;
using EFC.PLC;

using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;


namespace EFC.HMI
{
    public enum emDEVICE_TYPE { TYPE_BYTE, TYPE_WOR, TYPE_BIT, TYPE_CHAR }
    public enum emDEVICE_BUTTON_TYPE { emBT_M, emBT_Set, emBT_Reset, emBT_Inv }
    public enum emDEVICE_LOCK_TYPE { emBit_On, emBit_Off }
    public enum emDEVICE_LABEL_TYPE { emLT_16, emLT_32 }
    public enum emHMI_Bonder_Shape { Rect, Round, Ellipse, Image }
    public enum emHMI_Text_Align
    {
        None, Top_Left, Top_Center, Top_Right, Middle_Left, Middle_Center, Middle_Right,
        Bottom_Left, Bottom_Center, Bottom_Right
    }

    public delegate void UpdateUICallBack(Control ctl);
    public static class HMI_Tool
    {
        static public string Get_Font_String(Font in_font)
        {
            string result = "";
            result = string.Format("{0:s},{1:s},{2:f1}", in_font.Name, Get_Font_Style(in_font), in_font.Size);
            return result;
        }
        static public string Get_Font_Style(Font in_font)
        {
            string result = "";

            if (in_font.Bold && !in_font.Italic) result = "粗體";
            if (!in_font.Bold && in_font.Italic) result = "傾斜";
            if (in_font.Bold && in_font.Italic) result = "粗體 傾斜";
            if (!in_font.Bold && in_font.Italic) result = "標準";
            return result;
        }
        static public string Get_Number_Format(int dot_num)
        {
            string result = "";

            if (dot_num > 0)
            {
                result = "{0:f" + dot_num.ToString() + "}";
            }
            else result = "{0:f0}";

            return result;
        }
        static public string Get_Number_Text(int value, int dot_num)
        {
            string result = "";
            double tmp_value = value / Math.Pow(10, dot_num);

            result = string.Format(Get_Number_Format(dot_num), tmp_value);
            return result;
        }
        static public string Get_Number_Text(double value, int dot_num)
        {
            string result = "";

            result = string.Format(Get_Number_Format(dot_num), value);
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_Button info)
        {
            bool result = false;
            TForm_HMI_Button form = new TForm_HMI_Button(info);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_Lamp info)
        {
            bool result = false;
            TForm_HMI_Lamp form = new TForm_HMI_Lamp(info);
 
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_Edit info)
        {
            bool result = false;
            TForm_HMI_Edit form = new TForm_HMI_Edit(info);
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_Alarm info)
        {
            bool result = false;
            TForm_HMI_Alarm form = new TForm_HMI_Alarm(info);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_Message info)
        {
            bool result = false;
            TForm_HMI_Message form = new TForm_HMI_Message(info);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref ImageList info)
        {
            bool result = false;
            TForm_Image_List_Edit form = new TForm_Image_List_Edit(info);

            if (form.ShowDialog() == DialogResult.OK)//畫面彈跳方式
            {
                HMI_Tool.Copy_ImageList(form.Param, ref info);
                result = true;
            }
            return result;
        }
        static public bool Edit_HMI_Info(ref THMI_Info_ImageList info)
        {
            bool result = false;
            THMI_Image_Box_List obj = info.Image_Boxs;
            TForm_HMI_ImageList form = new TForm_HMI_ImageList(obj);

            if (form.ShowDialog() == DialogResult.OK)//畫面彈跳方式
            {
                form.Param.Copy(ref obj);
                result = true;
            }
            return result;
        }

        static public bool Get_Image_Boxs_Name(THMI_Image_Box_List boxs, ref string name)
        {
            bool result = false;

            if (boxs != null)
            {
                TForm_HMI_ImageList form = new TForm_HMI_ImageList(boxs);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    name = form.Select_Name;
                    result = true;
                }
            }
            return result;
        }
        static public bool Get_Image_Box_Index(THMI_Image_Box box, ref int index)
        {
            bool result = false;

            if (box != null) result = Get_ImageList_Index(box.ImageList, ref index);
            return result;
        }
        static public bool Get_ImageList_Index(ImageList list, ref int index)
        {
            bool result = false;

            if (list != null)
            {
                TForm_Image_List_Get form = new TForm_Image_List_Get(list);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    index = form.Select_Index;
                    result = true;
                }
            }
            return result;
        }
     
        static public void Copy_ImageList(ImageList sor, ref ImageList dis)
        {
            dis.ImageSize = sor.ImageSize;
            dis.ColorDepth = sor.ColorDepth;
            dis.TransparentColor = sor.TransparentColor;
            dis.Tag = sor.Tag;

            dis.Images.Clear();
            for (int i = 0; i < sor.Images.Count; i++)
            {
                dis.Images.Add(sor.Images.Keys[i], sor.Images[i]);
            }
        }
        static public ImageList Copy_ImageList(ImageList sor)
        {
            ImageList result = new ImageList();
            Copy_ImageList(sor, ref result);
            return result;
        }
        static public StringFormat Get_StringFormat(emHMI_Text_Align align)
        {
            StringFormat result = new StringFormat();
            switch (align)
            {
                case emHMI_Text_Align.Top_Left:
                case emHMI_Text_Align.Middle_Left:
                case emHMI_Text_Align.Bottom_Left:
                    result.Alignment = StringAlignment.Near;
                    break;

                case emHMI_Text_Align.Top_Center:
                case emHMI_Text_Align.Middle_Center:
                case emHMI_Text_Align.Bottom_Center:
                    result.Alignment = StringAlignment.Center;
                    break;

                case emHMI_Text_Align.Top_Right:
                case emHMI_Text_Align.Middle_Right:
                case emHMI_Text_Align.Bottom_Right:
                    result.Alignment = StringAlignment.Far;
                    break;
            }

            switch (align)
            {
                case emHMI_Text_Align.Top_Left:
                case emHMI_Text_Align.Top_Center:
                case emHMI_Text_Align.Top_Right:
                    result.LineAlignment = StringAlignment.Near;
                    break;

                case emHMI_Text_Align.Middle_Left:
                case emHMI_Text_Align.Middle_Center:
                case emHMI_Text_Align.Middle_Right:
                    result.LineAlignment = StringAlignment.Center;
                    break;

                case emHMI_Text_Align.Bottom_Left:
                case emHMI_Text_Align.Bottom_Center:
                case emHMI_Text_Align.Bottom_Right:
                    result.LineAlignment = StringAlignment.Far;
                    break;
            }

            return result;
        }

        static public System.Drawing.Size Size_Ofs(System.Drawing.Size size, int ofs)
        {
            System.Drawing.Size result = new Size(size.Width + ofs, size.Height + ofs);
            return result;
        }
    }
    static public class GraphicsPath_Tool
    {
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Rectangle(System.Drawing.Size size)
        {
            System.Drawing.Drawing2D.GraphicsPath result = new System.Drawing.Drawing2D.GraphicsPath();
            result.AddRectangle(new Rectangle(0, 0, size.Width, size.Height));
            return result;
        }
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Round(System.Drawing.Size size, int rad = -1)
        {
            System.Drawing.Drawing2D.GraphicsPath result = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
            double tmp_rad = 5.0;
            if (rad == -1) tmp_rad = (int)(size.Width * 0.2);
            else
                tmp_rad = 2 * rad;

            int d = (int)Math.Round(tmp_rad, 0);
            result.AddArc(rect.X, rect.Y, d, d, 180, 90);
            result.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
            result.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
            result.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
            result.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);

            return result;
        }
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Ellipse(System.Drawing.Size size)
        {
            System.Drawing.Drawing2D.GraphicsPath result = new System.Drawing.Drawing2D.GraphicsPath();
            result.AddEllipse(new Rectangle(0, 0, size.Width, size.Height));
            return result;
        }
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Ofs(System.Drawing.Drawing2D.GraphicsPath path, int ofs)
        {
            System.Drawing.Drawing2D.GraphicsPath result = (System.Drawing.Drawing2D.GraphicsPath)path.Clone();
            RectangleF rect = path.GetBounds();
            System.Drawing.Drawing2D.Matrix trans = new System.Drawing.Drawing2D.Matrix();


            double scale = 1 - ofs / rect.Width;
            double ofs_x = rect.Width * (1 - scale) / 2;
            double ofs_y = rect.Height * (1 - scale) / 2;

            trans.Scale((float)scale, (float)scale);
            trans.Translate((float)ofs_x, (float)ofs_y);
            result.Transform(trans);
            return result;
        }
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Bitmap(Bitmap bitmap)
        {
            return Get_Path_Bitmap(bitmap, bitmap.GetPixel(0, 0));
        }
        static public System.Drawing.Drawing2D.GraphicsPath Get_Path_Bitmap(Bitmap bitmap, Color border_color)
        {
            System.Drawing.Drawing2D.GraphicsPath result = null;
            bool flag = false;
            int col1 = 0, col2 = 0;

            if (border_color == Color.Transparent)
            {
                border_color = Color.FromArgb(0, 0, 0, 0);
                //transparent = bitmap.GetPixel(0, 0);
            }
            if (bitmap != null)
            {
                result = new System.Drawing.Drawing2D.GraphicsPath();
                for (int pixel_row = 0; pixel_row < bitmap.Height; pixel_row++)
                {
                    for (int pixel_col = 0; pixel_col < bitmap.Width; pixel_col++)
                    {
                        if (!flag)
                        {
                            if (bitmap.GetPixel(pixel_col, pixel_row) != border_color)
                            {
                                flag = true;
                                col1 = pixel_col;
                            }
                        }
                        else
                        {
                            if (bitmap.GetPixel(pixel_col, pixel_row) == border_color)
                            {
                                col2 = pixel_col;
                                result.AddRectangle(new Rectangle(col1, pixel_row, col2 - col1, 1));
                                flag = false;
                            }
                        }
                    }
                    if (flag)
                    {
                        col2 = bitmap.Width;
                        result.AddRectangle(new Rectangle(col1, pixel_row, col2 - col1, 1));
                        flag = false;
                    }
                }
            }
            return result;
        }
    }
    static public class JJS_Image_Tool
    {
        static public bool Equals(Color c1, Color c2)
        {
            bool result = false;
            if (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B && c1.A == c2.A) result = true;
            return result;
        }
        static public bool Check_Pixel(Bitmap sor, int x, int y, Color check_color)
        {
            bool result = false;
            if (x >= 0 && x < sor.Width && y >= 0 && y < sor.Height &&
                Equals(check_color, sor.GetPixel(x, y))) result = true;
            return result;
        }

        static public string Color_To_String(Color color)
        {
            string result = "";
            string tmp_str = color.ToString();
            int pos1 = tmp_str.IndexOf("[");
            int pos2 = tmp_str.IndexOf("]");
            if (pos1 >= 0 && pos1 >= 0)
            {
                result = tmp_str.Substring(pos1, pos2 - pos1);
            }
            return result;
        }
        static public Color String_To_Color(string color_str)
        {
            Color result = Color.Transparent;

            switch (color_str)
            {
                case "AliceBlue": result = Color.AliceBlue; break;
                case "AntiqueWhite": result = Color.AntiqueWhite; break;
                case "Aqua": result = Color.Aqua; break;
                case "Aquamarine": result = Color.Aquamarine; break;
                case "Azure": result = Color.Azure; break;

                case "Beige": result = Color.Beige; break;
                case "Bisque": result = Color.Bisque; break;
                case "Black": result = Color.Black; break;
                case "BlanchedAlmond": result = Color.BlanchedAlmond; break;
                case "Blue": result = Color.Blue; break;
                case "BlueViolet": result = Color.BlueViolet; break;
                case "Brown": result = Color.Brown; break;
                case "BurlyWood": result = Color.BurlyWood; break;

                case "CadetBlue": result = Color.CadetBlue; break;
                case "Chartreuse": result = Color.Chartreuse; break;
                case "Chocolate": result = Color.Chocolate; break;
                case "Coral": result = Color.Coral; break;
                case "CornflowerBlue": result = Color.CornflowerBlue; break;
                case "Cornsilk": result = Color.Cornsilk; break;
                case "Crimson": result = Color.Crimson; break;
                case "Cyan": result = Color.Cyan; break;

                case "DarkBlue": result = Color.DarkBlue; break;
                case "DarkCyan": result = Color.DarkCyan; break;
                case "DarkGoldenrod": result = Color.DarkGoldenrod; break;
                case "DarkGray": result = Color.DarkGray; break;
                case "DarkGreen": result = Color.DarkGreen; break;
                case "DarkKhaki": result = Color.DarkKhaki; break;
                case "DarkMagenta": result = Color.DarkMagenta; break;
                case "DarkOliveGreen": result = Color.DarkOliveGreen; break;
                case "DarkOrange": result = Color.DarkOrange; break;
                case "DarkOrchid": result = Color.DarkOrchid; break;
                case "DarkRed": result = Color.DarkRed; break;
                case "DarkSalmon": result = Color.DarkSalmon; break;
                case "DarkSeaGreen": result = Color.DarkSeaGreen; break;
                case "DarkSlateBlue": result = Color.DarkSlateBlue; break;
                case "DarkSlateGray": result = Color.DarkSlateGray; break;
                case "DarkTurquoise": result = Color.DarkTurquoise; break;
                case "DarkViolet": result = Color.DarkViolet; break;
                case "DeepPink": result = Color.DeepPink; break;
                case "DeepSkyBlue": result = Color.DeepSkyBlue; break;
                case "DimGray": result = Color.DimGray; break;
                case "DodgerBlue": result = Color.DodgerBlue; break;

                case "Firebrick": result = Color.Firebrick; break;
                case "FloralWhite": result = Color.FloralWhite; break;
                case "ForestGreen": result = Color.ForestGreen; break;
                case "Fuchsia": result = Color.Fuchsia; break;

                case "Gainsboro": result = Color.Gainsboro; break;
                case "GhostWhite": result = Color.GhostWhite; break;
                case "Gold": result = Color.Gold; break;
                case "Goldenrod": result = Color.Goldenrod; break;
                case "Gray": result = Color.Gray; break;
                case "Green": result = Color.Green; break;
                case "GreenYellow": result = Color.GreenYellow; break;

                case "Honeydew": result = Color.Honeydew; break;
                case "HotPink": result = Color.HotPink; break;

                case "IndianRed": result = Color.IndianRed; break;
                case "Indigo": result = Color.Indigo; break;
                case "Ivory": result = Color.Ivory; break;

                case "Khaki": result = Color.Khaki; break;

                case "Lavender": result = Color.Lavender; break;
                case "LavenderBlush": result = Color.LavenderBlush; break;
                case "LawnGreen": result = Color.LawnGreen; break;
                case "LemonChiffon": result = Color.LemonChiffon; break;
                case "LightBlue": result = Color.LightBlue; break;
                case "LightCoral": result = Color.LightCoral; break;
                case "LightCyan": result = Color.LightCyan; break;
                case "LightGoldenrodYellow": result = Color.LightGoldenrodYellow; break;
                case "LightGray": result = Color.LightGray; break;
                case "LightGreen": result = Color.LightGreen; break;
                case "LightPink": result = Color.LightPink; break;
                case "LightSalmon": result = Color.LightSalmon; break;
                case "LightSeaGreen": result = Color.LightSeaGreen; break;
                case "LightSkyBlue": result = Color.LightSkyBlue; break;
                case "LightSlateGray": result = Color.LightSlateGray; break;
                case "LightSteelBlue": result = Color.LightSteelBlue; break;
                case "LightYellow": result = Color.LightYellow; break;
                case "Lime": result = Color.Lime; break;
                case "LimeGreen": result = Color.LimeGreen; break;
                case "Linen": result = Color.Linen; break;

                case "Magenta": result = Color.Magenta; break;
                case "Maroon": result = Color.Maroon; break;
                case "MediumAquamarine": result = Color.MediumAquamarine; break;
                case "MediumBlue": result = Color.MediumBlue; break;
                case "MediumOrchid": result = Color.MediumOrchid; break;
                case "MediumPurple": result = Color.MediumPurple; break;
                case "MediumSeaGreen": result = Color.MediumSeaGreen; break;
                case "MediumSlateBlue": result = Color.MediumSlateBlue; break;
                case "MediumSpringGreen": result = Color.MediumSpringGreen; break;
                case "MediumTurquoise": result = Color.MediumTurquoise; break;
                case "MediumVioletRed": result = Color.MediumVioletRed; break;
                case "MidnightBlue": result = Color.MidnightBlue; break;
                case "MintCream": result = Color.MintCream; break;
                case "MistyRose": result = Color.MistyRose; break;
                case "Moccasin": result = Color.Moccasin; break;

                case "NavajoWhite": result = Color.NavajoWhite; break;
                case "Navy": result = Color.Navy; break;

                case "OldLace": result = Color.OldLace; break;
                case "Olive": result = Color.Olive; break;
                case "OliveDrab": result = Color.OliveDrab; break;
                case "Orange": result = Color.Orange; break;
                case "OrangeRed": result = Color.OrangeRed; break;
                case "Orchid": result = Color.Orchid; break;

                case "PaleGoldenrod": result = Color.PaleGoldenrod; break;
                case "PaleGreen": result = Color.PaleGreen; break;
                case "PaleTurquoise": result = Color.PaleTurquoise; break;
                case "PaleVioletRed": result = Color.PaleVioletRed; break;
                case "PapayaWhip": result = Color.PapayaWhip; break;
                case "PeachPuff": result = Color.PeachPuff; break;
                case "Peru": result = Color.Peru; break;
                case "Pink": result = Color.Pink; break;
                case "Plum": result = Color.Plum; break;
                case "PowderBlue": result = Color.PowderBlue; break;
                case "Purple": result = Color.Purple; break;

                case "Red": result = Color.Red; break;
                case "RosyBrown": result = Color.RosyBrown; break;
                case "RoyalBlue": result = Color.RoyalBlue; break;
                case "SaddleBrown": result = Color.SaddleBrown; break;
                case "Salmon": result = Color.Salmon; break;
                case "SandyBrown": result = Color.SandyBrown; break;
                case "SeaGreen": result = Color.SeaGreen; break;
                case "SeaShell": result = Color.SeaShell; break;
                case "Sienna": result = Color.Sienna; break;
                case "Silver": result = Color.Silver; break;
                case "SkyBlue": result = Color.SkyBlue; break;
                case "SlateBlue": result = Color.SlateBlue; break;
                case "SlateGray": result = Color.SlateGray; break;
                case "Snow": result = Color.Snow; break;
                case "SpringGreen": result = Color.SpringGreen; break;
                case "SteelBlue": result = Color.SteelBlue; break;

                case "Tan": result = Color.Tan; break;
                case "Teal": result = Color.Teal; break;
                case "Thistle": result = Color.Thistle; break;
                case "Tomato": result = Color.Tomato; break;
                case "Transparent": result = Color.Transparent; break;
                case "Turquoise": result = Color.Turquoise; break;
                case "Violet": result = Color.Violet; break;
                case "Wheat": result = Color.Wheat; break;
                case "White": result = Color.White; break;
                case "WhiteSmoke": result = Color.WhiteSmoke; break;
                case "Yellow": result = Color.Yellow; break;
                case "YellowGreen": result = Color.YellowGreen; break;
            }
            return result;
        }
        
        static public Color GetColor(Bitmap sor, int x, int y)
        {
            Color result = Color.White;
            if (x >= 0 && x < sor.Width && y >= 0 && y < sor.Height) result = sor.GetPixel(x, y);
            return result;
        }
        static public Bitmap Get_Image_Color(Bitmap sor, int pos_x, int pos_y)
        {
            Bitmap result = new Bitmap(sor.Width, sor.Height);
            Color check_color = sor.GetPixel(pos_x, pos_y);
            Color set_color = check_color;

            if (set_color.A == 0) set_color = Color.White;

            for (int y = 0; y < sor.Height; y++)
            {
                for (int x = 0; x < sor.Width; x++)
                {
                    if (Equals(check_color, sor.GetPixel(x, y)))
                        result.SetPixel(x, y, set_color);
                }
            }
            return result;
        }
        static public Bitmap Get_Image_Loop(Bitmap sor, int pos_x, int pos_y)
        {
            Bitmap result = new Bitmap(sor.Width, sor.Height);
            ArrayList list = new ArrayList();
            bool[,] Check_Flag = new bool[sor.Width, sor.Height];
            Color check_color = sor.GetPixel(pos_x, pos_y);
            Color set_color = check_color;

            if (set_color.A == 0) set_color = Color.White;
            Add_List(ref list, sor, Check_Flag, pos_x, pos_y);
            while (list.Count > 0)
            {
                stPos pos = (stPos)list[0];
                list.RemoveAt(0);
                bool tt = Check_Flag[pos.X, pos.Y];
                if (!Check_Flag[pos.X, pos.Y])
                    Get_Border_Loop(ref result, ref sor, ref list, ref Check_Flag, pos, check_color, set_color);
            }
            return result;
        }


        static private void Add_List(ref ArrayList list, Bitmap sor, bool[,] check_flag, int x, int y)
        {
            if (x >= 0 && x < sor.Width && y >= 0 && y < sor.Height && !check_flag[x, y])
            {
                list.Add(new stPos(x, y));
            }
        }
        static private void Get_Border_Loop(ref Bitmap dis, ref Bitmap sor, ref ArrayList list, ref bool[,] check_flag, stPos pos, Color check_color, Color set_color)
        {
            if (pos.X == 64 && pos.Y == 64)
            {
                int a = 1;
            }

            check_flag[pos.X, pos.Y] = true;
            if (Check_Pixel(sor, pos.X, pos.Y, check_color))
            {
                dis.SetPixel(pos.X, pos.Y, set_color);

                Add_List(ref list, sor, check_flag, pos.X - 1, pos.Y - 1);
                Add_List(ref list, sor, check_flag, pos.X - 0, pos.Y - 1);
                Add_List(ref list, sor, check_flag, pos.X + 1, pos.Y - 1);

                Add_List(ref list, sor, check_flag, pos.X - 1, pos.Y - 0);
                Add_List(ref list, sor, check_flag, pos.X + 1, pos.Y - 0);

                Add_List(ref list, sor, check_flag, pos.X - 1, pos.Y + 1);
                Add_List(ref list, sor, check_flag, pos.X - 0, pos.Y + 1);
                Add_List(ref list, sor, check_flag, pos.X + 1, pos.Y + 1);
            }
            else
                dis.SetPixel(pos.X, pos.Y, Color.White);


        }
        public struct stPos
        {
            public int X;
            public int Y;
            public stPos(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    //--------------------------------------------------------------------------------
    //-- 屬性編輯器
    //--------------------------------------------------------------------------------
    public class THMI_Editor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object result = null;
            IWindowsFormsEditorService EditorService = null;

            if (context != null && context.Instance != null && provider != null)
            {
                //建立編輯服務
                EditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (value is THMI_Info_Button) result = Form_Button(EditorService, value);
                if (value is THMI_Info_Lamp) result = Form_Lamp(EditorService, value);
                if (value is THMI_Info_Edit) result = Form_Edit(EditorService, value);
                if (value is THMI_Info_Alarm) result = Form_Alarm(EditorService, value);
                if (value is THMI_Info_Message) result = Form_Message(EditorService, value);
                if (value is THMI_Info_ImageList) result = Form_Image_List(EditorService, value);
               
                return result;
            }
            else
            {
                return null;
            }
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
                //return UITypeEditorEditStyle.DropDown;
                //return UITypeEditorEditStyle.None;
            }
            return base.GetEditStyle(context);
        }
        public object Form_Button(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_Button result = null;

            if (in_value is THMI_Info_Button)
            {

                TForm_HMI_Button form = new TForm_HMI_Button((THMI_Info_Button)in_value);
                if (service.ShowDialog(form) == DialogResult.OK)//畫面彈跳方式
                {
                    result = new THMI_Info_Button();
                    form.Param.Copy(ref result);
                }
            }
            return result;
        }
        public object Form_Lamp(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_Lamp result = null;

            if (in_value is THMI_Info_Lamp)
            {

                TForm_HMI_Lamp form = new TForm_HMI_Lamp((THMI_Info_Lamp)in_value);
                if (service.ShowDialog(form) == DialogResult.OK)//畫面彈跳方式
                {
                    result = new THMI_Info_Lamp();
                    form.Param.Copy(ref result);
                }
            }
            return result;
        }
        public object Form_Edit(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_Edit result = null;

            if (in_value is THMI_Info_Edit)
            {
                TForm_HMI_Edit form = new TForm_HMI_Edit((THMI_Info_Edit)in_value);
                if (service.ShowDialog(form) == DialogResult.OK)//畫面彈跳方式
                {
                    result = new THMI_Info_Edit();
                    form.Param.Copy(ref result);
                }
            }
            return result;
        }
        public object Form_Alarm(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_Alarm result = null; 

            if (in_value is THMI_Info_Alarm)
            {
                TForm_HMI_Alarm form = new TForm_HMI_Alarm((THMI_Info_Alarm)in_value);
                if (service.ShowDialog(form) == DialogResult.OK)//畫面彈跳方式
                {
                    result = new THMI_Info_Alarm();
                    form.Param.Copy(ref result);
                }
            }
            return result;
        }
        public object Form_Message(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_Message result = null;

            if (in_value is THMI_Info_Message)
            {
                TForm_HMI_Message form = new TForm_HMI_Message((THMI_Info_Message)in_value);
                if (service.ShowDialog(form) == DialogResult.OK)//畫面彈跳方式
                {
                    result = new THMI_Info_Message();
                    form.Param.Copy(ref result);
                }
            }
            return result;
        }
        public object Form_Image_List(IWindowsFormsEditorService service, object in_value)
        {
            THMI_Info_ImageList result = null;

            if (in_value is THMI_Info_ImageList)
            {
                THMI_Info_ImageList tmp_obj = (THMI_Info_ImageList)in_value;
                TForm_HMI_ImageList form = new TForm_HMI_ImageList(tmp_obj.Image_Boxs);
                if (service.ShowDialog(form) == DialogResult.OK) 
                {
                    result = new THMI_Info_ImageList();
                    THMI_Image_Box_List boxs = result.Image_Boxs;
                    form.Param.Copy(ref boxs);
                }
            }
            return result;
        }
    }
    public class THMI_Editor_Msg_File : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object result = null;
            IWindowsFormsEditorService EditorService = null;

            if (context != null && context.Instance != null && provider != null)
            {
                //建立編輯服務
                EditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (value is string) result = Value_Get(EditorService, value);
                return result;
            }
            else
            {
                return null;
            }
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
                //return UITypeEditorEditStyle.DropDown;
                //return UITypeEditorEditStyle.None;
            }
            return base.GetEditStyle(context);
        }
        public object Value_Get(IWindowsFormsEditorService service, object in_value)
        {
            string result = "";

            if (in_value is string)
            {
                OpenFileDialog dilog = new OpenFileDialog();
                dilog.Filter = "Alarm Message File|*.msg";
                dilog.FileName = (string)in_value;
                if (dilog.ShowDialog() == DialogResult.OK)
                {
                    result = dilog.FileName;
                }
            }
            return result;
        }
    }
    public class THMI_Editor_Log_File : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object result = null;
            IWindowsFormsEditorService EditorService = null;

            if (context != null && context.Instance != null && provider != null)
            {
                //建立編輯服務
                EditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (value is string) result = Value_Get(EditorService, value);
                return result;
            }
            else
            {
                return null;
            }
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
                //return UITypeEditorEditStyle.DropDown;
                //return UITypeEditorEditStyle.None;
            }
            return base.GetEditStyle(context);
        }
        public object Value_Get(IWindowsFormsEditorService service, object in_value)
        {
            string result = "";

            if (in_value is string)
            {
                OpenFileDialog dilog = new OpenFileDialog();
                dilog.Filter = "Log File|*.log";
                dilog.FileName = (string)in_value;
                if (dilog.ShowDialog() == DialogResult.OK)
                {
                    result = dilog.FileName;
                }
            }
            return result;
        }
    }

    
    //--------------------------------------------------------------------------------
    //-- HMI 共用物件
    //--------------------------------------------------------------------------------
    public interface IHMI_Component
    {
        void Refresh_Component();
    }
    public abstract class THMI_Info_Base
    {
        public Component Owner = null;
        protected THMI_PLC in_HMI_PLC = null;

        public THMI_Info_Base(Component owner = null)
        {
            Owner = owner;
        }
        public THMI_PLC HMI_PLC
        {
            get
            {
                return in_HMI_PLC;
            }
            set
            {
                if (in_HMI_PLC != null) in_HMI_PLC.Component_Remove(Owner);
                in_HMI_PLC = value;
                if (in_HMI_PLC != null) in_HMI_PLC.Component_Add(Owner);
            }
        }
        public void Copy(THMI_Info_Base dis)
        {
            Copy_Base(this, dis);
        }
        public THMI_Info_Base Copy()
        {
            THMI_Info_Base result = New_Base();
            Copy_Base(this, result);
            return result;
        }
        public void Set(THMI_Info_Base sor)
        {
            Copy_Base(sor, this);
        }

        public string Generate_Device(string device)
        {
            string result = "";

            if (in_HMI_PLC != null && in_HMI_PLC.Device_Tool != null)
            {
                result = in_HMI_PLC.Device_Tool.Generate_Device(device);
            }
            else
                result = device;

            return result;
        }
        public void Refresh_Component()
        {
            if (Owner != null)
            {
                Control obj = (Control)Owner;
                IHMI_Component hmi_obj = (IHMI_Component)Owner;
                //string n = obj.Name;
                //obj.Refresh();
                hmi_obj.Refresh_Component();
            }
        }


        abstract public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis);
        abstract public THMI_Info_Base New_Base();
        abstract public bool Edit_Info();
        abstract public void Update_HMI_Data();
    }

    public class THMI_Status
    {
        private string                 in_Name = "";
        private System.Drawing.Color   in_Face_Color = Color.Gray;
        private string                 in_Text = "Default";
        private System.Drawing.Font    in_Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        private System.Drawing.Color   in_Font_Color = Color.Black;
        private int                    in_Image_Index = 0;
        private bool                   in_Disp_Text = false;
        private emHMI_Text_Align       in_Text_Align = emHMI_Text_Align.Middle_Center;


        public THMI_Status()
        {

        }
        public THMI_Status(string name, string text, System.Drawing.Color font_color, System.Drawing.Color face_color, int index = 0)
        {
            in_Name = name;
            in_Text = text;
            in_Font_Color = font_color;
            in_Face_Color = face_color;
            in_Image_Index = index;
        }
        public THMI_Status(int image_index)
        {
            in_Image_Index = image_index;
        }
        public void Copy(THMI_Status sor, THMI_Status dis)
        {
            dis.in_Name = sor.in_Name;
            dis.in_Face_Color = sor.in_Face_Color;
            dis.in_Text = sor.in_Text;
            dis.in_Font = sor.in_Font;
            dis.in_Font_Color = sor.in_Font_Color;
            dis.in_Image_Index = sor.in_Image_Index;
            dis.in_Disp_Text = sor.in_Disp_Text;
            dis.in_Text_Align = sor.in_Text_Align;
        }
        public void Copy(ref THMI_Status dis)
        {
            Copy(this, dis);
        }
        public THMI_Status Copy()
        {
            THMI_Status result = new THMI_Status();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Status sor)
        {
            Copy(sor, this);
        }

        public System.Drawing.Color Face_Color
        {
            get
            {
                return in_Face_Color;
            }
            set
            {
                in_Face_Color = value;
            }
        }
        public string Name
        {
            get
            {
                return in_Name;
            }
            set
            {
                in_Name = value;
            }
        }
        public string Text
        {
            get
            {
                return in_Text;
            }
            set
            {
                in_Text = value;
            }
        }
        public int Image_Index
        {
            get
            {
                return in_Image_Index;
            }
            set
            {
                in_Image_Index = value;
            }
        }
        public System.Drawing.Font Font
        {
            get
            {
                return in_Font;
            }
            set
            {
                in_Font = (System.Drawing.Font)value.Clone();
            }
        }
        public System.Drawing.Color Font_Color
        {
            get
            {
                return in_Font_Color;
            }
            set
            {
                in_Font_Color = value;
            }
        }
        public bool Disp_Text
        {
            get
            {
                return in_Disp_Text;
            }
            set
            {
                if (in_Disp_Text != value)
                {
                    in_Disp_Text = value;
                }
            }
        }
        public emHMI_Text_Align Text_Align
        {
            get
            {
                return in_Text_Align;
            }
            set
            {
                if (in_Text_Align != value)
                {
                    in_Text_Align = value;
                }
            }
        }
        public ContentAlignment Get_Text_Align()
        {
            ContentAlignment result = ContentAlignment.MiddleCenter;

            switch (in_Text_Align)
            {
                case emHMI_Text_Align.Top_Left: result = ContentAlignment.TopLeft; break;
                case emHMI_Text_Align.Top_Center: result = ContentAlignment.TopCenter; break;
                case emHMI_Text_Align.Top_Right: result = ContentAlignment.TopRight; break;

                case emHMI_Text_Align.Middle_Left: result = ContentAlignment.MiddleLeft; break;
                case emHMI_Text_Align.Middle_Center: result = ContentAlignment.MiddleCenter; break;
                case emHMI_Text_Align.Middle_Right: result = ContentAlignment.MiddleRight; break;

                case emHMI_Text_Align.Bottom_Left: result = ContentAlignment.BottomLeft; break;
                case emHMI_Text_Align.Bottom_Center: result = ContentAlignment.BottomCenter; break;
                case emHMI_Text_Align.Bottom_Right: result = ContentAlignment.BottomRight; break;
            }
            return result;
        }
    }
    public sealed class THMI_Status_List : CollectionBase
    {
        public THMI_Status_List()
        {

        }
        public THMI_Status this[int index]
        {
            get
            {
                THMI_Status result = null;
                if (index >= 0 && index < List.Count) result = (THMI_Status)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count) 
                    List[index] = value.Copy();
            }
        }
        public int IndexOf(THMI_Status status)
        {
            return this.List.IndexOf(status);
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            THMI_Status tmp_status = null;

            if (name != "")
            {
                for (int i = 0; i < List.Count; i++)
                {
                    tmp_status = (THMI_Status)List[i];
                    if (tmp_status.Name == name)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result;
        }
        //public void Add(string name, THMI_Status status)
        //{
        //    int no = IndexOf_Name(name);

        //    if (no >= 0)
        //    {
        //        this[no].Set(status);
        //    }
        //    else
        //    {
        //        THMI_Status tmp_status = new THMI_Status();
        //        tmp_status.Set(status);
        //        tmp_status.Name = name;
        //        List.Add(tmp_status);
        //    }
        //}
        public void Add(THMI_Status status)
        {
            int no = IndexOf_Name(status.Name);
            if (no >= 0)
            {
                this[no].Set(status);
            }
            else
                List.Add(status);
        }
        public void Set(int index, THMI_Status status)
        {
            if (index >= 0 && index < Count && status != null)
            {
                this[index].Set(status);
            }
        }
        public void Set(int index, string name, string text, System.Drawing.Color font_color, System.Drawing.Color face_color, int image_index = 0)
        {
            THMI_Status old_status = this[index];
            if (old_status != null)
            {
                THMI_Status status = new THMI_Status(name, text, font_color, face_color, image_index);
                Set(index, status);
            }
        }
        public void Remove(THMI_Status status)
        {
            if (this.IndexOf(status) != -1)
                List.Remove(status);
        }
        public void Copy(THMI_Status_List sor, THMI_Status_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref THMI_Status_List dis)
        {
            Copy(this, dis);
        }
        public THMI_Status_List Copy()
        {
            THMI_Status_List result = new THMI_Status_List();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Status_List sor)
        {
            Copy(sor, this);
        }
        public void Set_Count(int count)
        {
            if (count < Count)
            {
                while (List.Count > count)
                {
                    List.RemoveAt(List.Count - 1);
                }
            }
            else
            {
                int add_count = count - Count;
                for (int i = 0; i < add_count; i++)
                    List.Add(new THMI_Status());
            }
        }
    }

    public class THMI_Meg_Item
    {
        private string in_Str = "";
        private System.Drawing.Color in_Font_Color = Color.White;
        private System.Drawing.Color in_Face_Color = Color.Blue;
        private HorizontalAlignment in_TextAlign = HorizontalAlignment.Left;

        public THMI_Meg_Item()
        {

        }
        public void Copy(THMI_Meg_Item sor, THMI_Meg_Item dis)
        {
            dis.Str = sor.Str;
            dis.in_Font_Color = sor.in_Font_Color;
            dis.in_Face_Color = sor.in_Face_Color;
            dis.in_TextAlign = sor.in_TextAlign;
        }
        public void Copy(ref THMI_Meg_Item dis)
        {
            Copy(this, dis);
        }
        public THMI_Meg_Item Copy()
        {
            THMI_Meg_Item result = new THMI_Meg_Item();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Meg_Item sor)
        {
            Copy(sor, this);
        }

        public string Str
        {
            get
            {
                return in_Str;
            }
            set
            {
                in_Str = value;
            }
        }
        public System.Drawing.Color Face_Color
        {
            get
            {
                return in_Face_Color;
            }
            set
            {
                if (in_Face_Color != value)
                {
                    in_Face_Color = value;
                }
            }
        }
        public System.Drawing.Color Font_Color
        {
            get
            {
                return in_Font_Color;
            }
            set
            {
                if (in_Font_Color != value)
                {
                    in_Font_Color = value;
                }
            }
        }
        public HorizontalAlignment TextAlign
        {
            get
            {
                return in_TextAlign;
            }
            set
            {
                if (in_TextAlign != value)
                {
                    in_TextAlign = value;
                }
            }
        }
    }
    public sealed class THMI_Msg_Collection : CollectionBase 
    {
        public THMI_Msg_Collection()
        {

        }
        public THMI_Meg_Item this[int index]
        {
            get
            {
                THMI_Meg_Item result = null;
                if (index >= 0 && index < List.Count) result = (THMI_Meg_Item)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    List[index] = value.Copy();
                }
            }
        }
        public int IndexOf(THMI_Meg_Item member)
        {
            return this.List.IndexOf(member);
        }
        public void Add(THMI_Meg_Item member)
        {
            THMI_Meg_Item tmp = member.Copy();
            List.Add(tmp);
        }
        public void Remove(THMI_Meg_Item member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Copy(THMI_Msg_Collection sor, THMI_Msg_Collection dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.Add(sor[i]);
        }
        public void Copy(ref THMI_Msg_Collection dis)
        {
            Copy(this, dis);
        }
        public THMI_Msg_Collection Copy()
        {
            THMI_Msg_Collection result = new THMI_Msg_Collection();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Msg_Collection sor)
        {
            Copy(sor, this);
        }
        public void Set_Count(int count)
        {
            if (count < Count)
            {
                while (List.Count > count)
                {
                    List.RemoveAt(List.Count - 1);
                }
            }
            else
            {
                int add_count = count - Count;
                for (int i = 0; i < add_count; i++)
                    List.Add(new THMI_Meg_Item());
            }
        }
    }

    public class THMI_Image_Box
    {
        private string in_Name = "";
        private ImageList in_ImageList = new ImageList();
        //private ArrayList Do_Work_File_List = null;

        public THMI_Image_Box()
        {
            Set_Default();
        }
        public THMI_Image_Box(string name, string path)
        {
            Set_Default();
            in_Name = name;
            Load_From_Path(path);
        }
        public ImageList ImageList
        {
            get
            {
                return in_ImageList;
            }
            set
            {
                if (value != null)
                {
                    HMI_Tool.Copy_ImageList(value, ref in_ImageList);
                }
            }
        }
        public string Name
        {
            get
            {
                return in_Name;
            }
            set
            {
                in_Name = value;
            }
        }
        public void Copy(THMI_Image_Box sor, THMI_Image_Box dis)
        {
            dis.in_Name = sor.in_Name;
            HMI_Tool.Copy_ImageList(sor.in_ImageList, ref dis.in_ImageList);
        }
        public void Copy(ref THMI_Image_Box dis)
        {
            Copy(this, dis);
        }
        public THMI_Image_Box Copy()
        {
            THMI_Image_Box result = new THMI_Image_Box();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Image_Box sor)
        {
            Copy(sor, this);
        }

        private void Set_Default()
        {
            in_ImageList.ImageSize = new Size(64, 64);
        }
        private void Image_List_Add(string key, Image in_image)
        {
            TFrame_ImageList tmp_obj = null;
            int no = 0;

            if (in_ImageList.Images.Keys.IndexOf(key) < 0)
            {
                no = in_ImageList.Images.Count;
                in_ImageList.Images.Add(key, in_image);
                tmp_obj = new TFrame_ImageList();
                //tmp_obj.Name = "JJS_PictureBox" + (Serial_No++).ToString();
                //tmp_obj.Set_Bitmap(in_ImageList, no);
                //tmp_obj.PB_Bitmap.MouseClick += Image_MouseClick;
                //flowLayoutPanel1.Controls.Add(tmp_obj);
            }
        }
        private void Image_List_Add(string filename)
        {
            string key = System.IO.Path.GetFileName(filename);
            Image_List_Add(key, Image.FromFile(filename));
        }
        public void Load_From_Path(string path)
        {
            in_ImageList.Images.Clear();
            Image_List_Add_Range(path);
        }
        private void Image_List_Add_Range(string path)
        {
            ArrayList file_list = new ArrayList();

            file_list = String_Tool.Get_Files_List(path, "*.png");
            Image_List_Add_Range("Load Image List *.png", file_list);

            file_list = String_Tool.Get_Files_List(path, "*.jpg");
            Image_List_Add_Range("Load Image List *.jpg", file_list);

            file_list = String_Tool.Get_Files_List(path, "*.bmp");
            Image_List_Add_Range("Load Image List *.bmp", file_list);
        }
        private void Image_List_Add_Range(string title, ArrayList file_list)
        {
            for (int i = 0; i < file_list.Count; i++)
            {
                Image_List_Add(file_list[i].ToString());
            }
            //Do_Work_File_List = file_list;
            //TForm_Process Process_Bar = new TForm_Process(title, Do_Work_File_List.Count, Do_Work);
        }
        //private void Do_Work(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = (BackgroundWorker)sender;

        //    for (int i = 0; i < Do_Work_File_List.Count; i++)
        //    {
        //        Image_List_Add(Do_Work_File_List[i].ToString());
        //        worker.ReportProgress(i + 1);
        //    }
        //}
    }
    public sealed class THMI_Image_Box_List : CollectionBase
    {
        private string in_Database_Path = "";
        public string Database_Path
        {
            get
            {
                return in_Database_Path;
            }
            set
            {
                if (value != null)
                {
                    in_Database_Path = value;
                    Add_Database(in_Database_Path);
                }
            }
        }



        public THMI_Image_Box_List()
        {
            Database_Path = "E:\\HMI_Database\\";
        }
        public THMI_Image_Box this[int index]
        {
            get
            {
                THMI_Image_Box result = null;
                if (index >= 0 && index < List.Count) result = (THMI_Image_Box)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    THMI_Image_Box tmp_obj = (THMI_Image_Box)List[index];
                    value.Copy(ref tmp_obj);
                }
            }
        }
        public THMI_Image_Box this[string name]
        {
            get
            {
                return this[IndexOf_Name(name)];
            }
            set
            {
                this[IndexOf_Name(name)] = value;
            }
        }
        public int IndexOf(THMI_Image_Box member)
        {
            return this.List.IndexOf(member);
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            THMI_Image_Box tmp_obj = null;
            for (int i = 0; i < List.Count; i++)
            {
                tmp_obj = (THMI_Image_Box)List[i];
                if (name == tmp_obj.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(string name, THMI_Image_Box member)
        {
            int pos = IndexOf_Name(name);
            if (pos >= 0)
            {
                THMI_Image_Box tmp_obj = (THMI_Image_Box)List[pos];
                tmp_obj.Name = name;
                member.Copy(ref tmp_obj);
            }
            else
            {
                THMI_Image_Box tmp_obj = member.Copy();
                tmp_obj.Name = name;
                this.List.Add(tmp_obj);
            }
        }
        public void Add(string name, string path)
        {
            THMI_Image_Box member = new THMI_Image_Box(name, path);
            Add(name, member);
        }
        public void Add_Database(string path)
        {
            string name = "";

            List.Clear();
            ArrayList path_list = String_Tool.Get_Dir_List(path, "info.xml");
            for (int i = 0; i < path_list.Count; i++)
            {
                name = (string)path_list[i];
                Add(name, path + name + "\\");
            }
        }
        public void Remove(THMI_Image_Box member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Remove(string name)
        {
            RemoveAt(IndexOf_Name(name));
        }

        public void Copy(THMI_Image_Box_List sor, THMI_Image_Box_List dis)
        {
            dis.in_Database_Path = sor.in_Database_Path;
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref THMI_Image_Box_List dis)
        {
            Copy(this, dis);
        }
        public THMI_Image_Box_List Copy()
        {
            THMI_Image_Box_List result = new THMI_Image_Box_List();
            Copy(this, result);
            return result;
        }
        public void Set(THMI_Image_Box_List sor)
        {
            Copy(sor, this);
        }

        public void Set_Count(int count)
        {
            if (count < Count)
            {
                while (List.Count > count)
                {
                    List.RemoveAt(List.Count - 1);
                }
            }
            else
            {
                int add_count = count - Count;
                for (int i = 0; i < add_count; i++)
                    List.Add(new THMI_Meg_Item());
            }
        }
        public Bitmap Get_Image(string name, int index)
        {
            Bitmap result = null;

            THMI_Image_Box obj = this[name];
            if (obj != null)
            {
                if (index >= 0 && index < obj.ImageList.Images.Count)
                {
                    result = new Bitmap(obj.ImageList.Images[index]);
                }
            }
            return result;
        }
        public Bitmap Get_Image(string name, int index, System.Drawing.Size size)
        {
            Bitmap result = null;

            result = Get_Image(name, index);
            if (result != null) result = new Bitmap(result, size);
            return result;
        }

        private bool Has(THMI_Image_Box member)
        {
            bool result = false;
            if (IndexOf_Name(member.Name) >= 0) result = true;
            return result;
        }
    }

}
