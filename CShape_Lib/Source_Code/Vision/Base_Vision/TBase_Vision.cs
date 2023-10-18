using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Collections;
using EFC.INI;
using EFC.CAD;
using EFC.Tool;


namespace EFC.Vision.Halcon
{
  
    //-----------------------------------------------------------------------------------------------------
    //Vision 工具程式庫
    //-----------------------------------------------------------------------------------------------------
    public enum emSort_Region_Mode { Area, Circularity, Compactness, Convexity };
    public static class JJS_Vision
    {
        public static void Display_String(HWindowControl hw, string str, double col, double row, double font_size, string color)
        {
            string font;
            int tmp_font_size = 1;

            tmp_font_size = (int)font_size;
            if (tmp_font_size < 1) tmp_font_size = 1;
            font = string.Format("-Arial-{0:d}-*-*-*-*-*-", (int)tmp_font_size);

            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetTposition((int)row, (int)col);
            hw.HalconWindow.SetFont(font);
            hw.HalconWindow.WriteString(str);
        }
        public static void Display_String(HWindowControl hw, string str, double col, double row, double font_size, double scale, string color)
        {
            Display_String(hw, str, col * scale, row * scale, font_size * scale, color);
        }
        public static void Display_Line(HWindowControl hw, double col1, double row1, double col2, double row2, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DispLine(row1, col1, row2, col2);
        }
        public static void Display_Line(HWindowControl hw, TJJS_Line line, string color)
        {
            Display_Line(hw, line.Start.X, line.Start.Y, line.End.X, line.End.Y, color);
        }
        public static void Display_Hairline(HWindowControl hw, double col, double row, double size, double angle, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DispCross(row, col, Math.Round(size, 0), angle);
        }
        public static void Display_Hairline(HWindowControl hw, HTuple cols, HTuple rows, double size, double angle, string color)
        {
            hw.HalconWindow.SetColor(color);
            for (int i = 0; i < rows.Length; i++)
            {
                hw.HalconWindow.DispCross(rows.DArr[i], cols.DArr[i], size, angle);
            }
        }
        public static void Display_Hairline(HWindowControl hw, double width, double height, string color)
        {
            double col, row, size;

            col = width / 2;
            row = height / 2;
            if (width > height) size = width;
            else size = height;
            Display_Hairline(hw, (double)col, (double)row, size, 0, color);
        }
        public static void Display_Hairline(HWindowControl hw, HImage image, string color)
        {
            string type;
            int w, h;

            image.GetImagePointer1(out type, out w, out h);
            Display_Hairline(hw, w, h, color);
        }

        public static void Display_Rectangle(HWindowControl hw, double col1, double row1, double col2, double row2, string color)
        {
            //hw.HalconWindow.SetDraw("margin");
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DispRectangle1(row1, col1, row2, col2);
        }
        public static void Display_Rectangle(HWindowControl hw, stRect_Double rect, string color)
        {
            Display_Rectangle(hw, rect.X1, rect.Y1, rect.X2, rect.Y2, color);
        }
        public static void Display_Rectangle2(HWindowControl hw, stRectangle2 rect, string color, bool arrow_flag = true)
        {
            //hw.HalconWindow.SetDraw("margin");
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DispRectangle2(rect.Row, rect.Col, rect.Phi, rect.Len1, rect.Len2);
            if (arrow_flag)
            {
                TJJS_Line line = new TJJS_Line();
                TJJS_Angle ang = new TJJS_Angle();

                line.Start = new TJJS_Point(rect.Col + rect.Len1 - 20, rect.Row);
                line.End = new TJJS_Point(rect.Col + rect.Len1 + 40, rect.Row);
                ang.r = rect.Phi;
                line = line.Rotate(new TJJS_Point(rect.Col, rect.Row), -ang.d);
                hw.HalconWindow.DispArrow(line.Start.Y, line.Start.X, line.End.Y, line.End.X, 3);
            }
        }

        public static void Display_Arcline(HWindowControl hw, double col, double row, double StartCol, double StartRow, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth(2);
            hw.HalconWindow.DispArc(row, col, 0.7, StartRow, StartCol);
        }

        public static void Display_Frame(HWindowControl hw, stRect_Double rect, string fill_color, string frame_color, int line_w)
        {
            hw.HalconWindow.SetLineWidth(line_w);
            hw.HalconWindow.SetDraw("fill");
            hw.HalconWindow.SetColor(fill_color);
            hw.HalconWindow.DispRectangle1(rect.Y1, rect.X1, rect.Y2, rect.X2);

            hw.HalconWindow.SetDraw("margin");
            hw.HalconWindow.SetColor(frame_color);
            hw.HalconWindow.DispRectangle1(rect.Y1, rect.X1, rect.Y2, rect.X2);
        }


        public static void Display_Model_XLD(HWindowControl hw, double col, double row, double ang, HXLDCont disp_xld, string color)
        {
            HXLDCont tmp_xld = new HXLDCont();
            HHomMat2D mat2d = new HHomMat2D();

            try
            {
                //顯示標靶輪廓
                hw.HalconWindow.SetColor(color);
                mat2d.VectorAngleToRigid(0.0, 0.0, 0.0, row, col, ang);
                tmp_xld = disp_xld.AffineTransContourXld(mat2d);
                tmp_xld.DispXld(hw.HalconWindow);
            }
            catch
            {

            }
        }
        public static void Display_Model_Rectangle(HWindowControl hw, double col, double row, double ang, HXLDCont disp_xld, string color)
        {
            HXLDCont tmp_xld = new HXLDCont();
            HHomMat2D mat2d = new HHomMat2D();
            HTuple r1, c1, r2, c2;

            try
            {
                //顯示標靶輪廓      
                hw.HalconWindow.SetColor(color);
                mat2d.VectorAngleToRigid(0, 0, 0, row, col, ang);
                tmp_xld = disp_xld.AffineTransContourXld(mat2d);
                tmp_xld.SmallestRectangle1Xld(out r1, out c1, out r2, out c2);
                hw.HalconWindow.SetColor(color);
                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.DispRectangle1(r1.TupleMin(), c1.TupleMin(), r2.TupleMax(), c2.TupleMax());
            }
            catch
            {

            }
        }

        public static void Draw_Rectangle1(HWindowControl hw, string color,out double r1, out double c1, out double r2, out double c2)
        {
            hw.Focus();
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DrawRectangle1(out r1, out c1, out r2, out c2);
        }
        public static void Draw_Rectangle2(HWindowControl hw, string color, out double r, out double c, out double phi, out double len1, out double len2)
        {
            hw.Focus();
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DrawRectangle2(out r, out c, out phi, out len1, out len2);
        }
        public static void Draw_Point(HWindowControl hw, string color, out double r1, out double c1)
        {
            hw.Focus();
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.DrawPoint(out r1, out c1);
        }
        
        public static stRegion_Info Get_Region_Info(HRegion region)
        {
            stRegion_Info result = new stRegion_Info();

            if (region.CountObj() == 1)
            {
                //一個區域的面積（大小）和中
                result.Area = region.AreaCenter(out result.Row, out result.Col);

                //域與圓的相似度的形狀係數
                result.Circularity = region.Circularity();

                //一個區域緻密度的形狀係數
                result.Compactness = region.Compactness();

                //一個區域輪廓(contour)的長度
                result.Cont_Length = region.Contlength();

                //一個區域凸性的形狀係數
                result.Convexity = region.Convexity();

                //一個區域兩個邊界點的最大距離
                region.DiameterRegion(out result.Diameter_Row1, out result.Diameter_Col1, out result.Diameter_Row2, out result.Diameter_Col2, out result.Diameter);

                //一個區域橢圓參數的形狀係數
                result.Eccentricity_Anisometry = region.Eccentricity(out result.Eccentricity_Bulkiness, out result.Eccentricity_Structure_Factor);

                //一個區域相似橢圓的參數
                result.Elliptic_RA = region.EllipticAxis(out result.Elliptic_RB, out result.Elliptic_Phi);

                //一個區域內部最大的圓周
                region.InnerCircle(out result.Inner_Circle_Row, out result.Inner_Circle_Col, out result.Inner_Circle_Radius);

                //一個區域的最小周圓
                region.SmallestCircle(out result.Outer_Circle_Row, out result.Outer_Circle_Col, out result.Outer_Circle_Radius);

                //一個區域內部最大的矩形
                region.InnerRectangle1(out result.Inner_Rect1_Row1, out result.Inner_Rect1_Col1, out result.Inner_Rect1_Row2, out result.Inner_Rect1_Col2);
                result.Inner_Rect1_Len1 = (result.Inner_Rect1_Row2 - result.Inner_Rect1_Row1);
                result.Inner_Rect1_Len2 = (result.Inner_Rect1_Col2 - result.Inner_Rect1_Col1);

                //一個區域平行於坐標軸的包圍某區域的 Rect1 最小矩形
                region.SmallestRectangle1(out result.Outer_Rect1_Row1, out result.Outer_Rect1_Col1, out result.Outer_Rect1_Row2, out result.Outer_Rect1_Col2);
                result.Outer_Rect1_Len1 = (result.Outer_Rect1_Row2 - result.Outer_Rect1_Row1);
                result.Outer_Rect1_Len2 = (result.Outer_Rect1_Col2 - result.Outer_Rect1_Col1);

                //一個區域平行於坐標軸的包圍某區域的 Rect2 最小矩形
                region.SmallestRectangle2(out result.Outer_Rect2_Row, out result.Outer_Rect2_Col, out result.Outer_Rect2_Phi, out result.Outer_Rect2_Len1, out result.Outer_Rect2_Len2);
            }
            return result;
        }
        public static stRegion_Info[] Get_Regions_Info(HRegion region)
        {
            stRegion_Info[] result = new stRegion_Info[0];
            HRegion tmp_region = new HRegion();
            int count = 0;

            count = region.CountObj();
            Array.Resize(ref result, count);
            for (int i = 0; i < count; i++)
            {
                tmp_region = region.SelectObj(i + 1);
                result[i] = Get_Region_Info(tmp_region);
            }
            return result;
        }
        public static HRegion Region_Sort(HRegion in_region, emSort_Region_Mode mode, bool reverse = false)
        {
            HRegion result = new HRegion();
            ArrayList out_list = new ArrayList();
            TSort_Data tmp_data = null;
            int count = 0;

            count = in_region.CountObj();
            if (count > 1)
            {
                for (int i = 0; i < count; i++)
                {
                    switch (mode)
                    {
                        case emSort_Region_Mode.Area:
                            out_list.Add(new TSort_Data(i + 1, in_region.SelectObj(i + 1).Area));
                            break;

                        case emSort_Region_Mode.Circularity:
                            out_list.Add(new TSort_Data(i + 1, in_region.SelectObj(i + 1).Circularity()));
                            break;

                        case emSort_Region_Mode.Compactness:
                            out_list.Add(new TSort_Data(i + 1, in_region.SelectObj(i + 1).Compactness()));
                            break;

                        case emSort_Region_Mode.Convexity:
                            out_list.Add(new TSort_Data(i + 1, in_region.SelectObj(i + 1).Convexity()));
                            break;
                    }
                }
                out_list.Sort(new TSort_Data_Compare());
                if (reverse) out_list.Reverse();

                for (int i = 0; i < out_list.Count; i++)
                {
                    tmp_data = (TSort_Data)out_list[i];
                    if (i == 0) result = in_region.SelectObj(tmp_data.Index);
                    else result = result.ConcatObj(in_region.SelectObj(tmp_data.Index));
                }
            }
            else result = in_region.Clone();

            return result;
        }


        public static bool Is_Empty(HImage image)
        {
            bool result = true;
            try
            {
                if (image != null)
                {
                    int w, h;
                    image.GetImageSize(out w, out h);
                    if (w > 0 && h > 0) result = false;
                }
            }
            catch
            {

            }
            return result;
        }
        public static bool Is_Empty(HRegion region)
        {
            bool result = true;
            try
            {
                if (region != null)
                {
                    if (region.CountObj() > 0) result = false;
                }
            }
            catch
            {
            }
            return result;
        }
        public static bool Is_Empty(HShapeModel model)
        {
            bool result = true;
            try
            {
                if (model != null)
                {
                    if (model.IsInitialized()) result = false;
                }
            }
            catch
            {

            }
            return result;
        }
        public static bool Is_Empty(HNCCModel model)
        {
            bool result = true;
            try
            {
                if (model != null)
                {
                    if (model.IsInitialized()) result = false;
                }
            }
            catch
            {

            }
            return result;
        }
        public static bool Is_Empty(HXLD xld)
        {
            bool result = true;
            try
            {
                if (xld != null)
                {
                    if (xld.IsInitialized()) result = false;
                }
            }
            catch
            {

            }
            return result;
        }

        public static bool Is_Not_Empty(HImage image)
        {
            return !Is_Empty(image);
        }
        public static bool Is_Not_Empty(HRegion region)
        {
            return !Is_Empty(region);
        }
        public static bool Is_Not_Empty(HShapeModel model)
        {
            return !Is_Empty(model);
        }
        public static bool Is_Not_Empty(HNCCModel model)
        {
            return !Is_Empty(model);
        }
        public static bool Is_Not_Empty(HXLD xld)
        {
            return !Is_Empty(xld);
        }

        public static void Copy_Obj(HImage sor, ref HImage dis)
        {
            if (Is_Not_Empty(sor)) dis = sor.Clone();
            else dis = null;
        }
        public static void Copy_Obj(THImage_RGB sor, ref THImage_RGB dis)
        {
            if (sor != null)
            {
                dis = new THImage_RGB();
                Copy_Obj(sor.R, ref dis.R);
                Copy_Obj(sor.G, ref dis.G);
                Copy_Obj(sor.B, ref dis.B);
            }
            else dis = null;
        }
        public static void Copy_Obj(THImage_HSV sor, ref THImage_HSV dis)
        {
            if (sor != null)
            {
                dis = new THImage_HSV();
                Copy_Obj(sor.H, ref dis.H);
                Copy_Obj(sor.S, ref dis.S);
                Copy_Obj(sor.V, ref dis.V);
            }
            else dis = null;
        }
        public static void Copy_Obj(HRegion sor, ref HRegion dis)
        {
            if (Is_Not_Empty(sor)) dis = sor.Clone();
            else dis = null;
        }
        public static void Copy_Obj(HShapeModel sor, ref HShapeModel dis)
        {
            if (Is_Not_Empty(sor)) dis = sor.Clone();
            else dis = null;
        }
        public static void Copy_Obj(HXLDCont sor, ref HXLDCont dis)
        {
            if (Is_Not_Empty(sor)) dis = (HXLDCont)sor.Clone();
            else dis = null;
        }

        public static void Union2(HRegion in_region, ref HRegion out_region)
        {
            if (Is_Not_Empty(in_region))
            {
                if (Is_Not_Empty(out_region)) out_region = out_region.Union2(in_region);
                else out_region = in_region.Clone();
            }
        }



        public static void Dispose(HImage obj)
        {
            if (obj != null) obj.Dispose();
            obj = null;
        }
        public static void Dispose(HRegion obj)
        {
            if (obj != null) obj.Dispose();
            obj = null;
        }

        public static string Get_File_Ext(string filename)
        {
            string result = "";

            result = System.IO.Path.GetExtension(filename);
            result = result.ToLower();
            result = result.Replace(".", "");
            if (result == "jpg") result = "jpeg";
            return result;
        }

        public static Rectangle[] Get_Window_Rect(Rectangle in_rect, Rectangle win_rect, int x_num, int y_num)
        {
            //in_rect 存放HWindows 的容器範圍
            //win_rect HWindows的大小
            //x_num = X 數量
            //y_num = Y 數量

            Rectangle[] result = new Rectangle[x_num * y_num];
            int width, height;
            double scale_x, scale_y;
            int no;

            scale_x = (in_rect.Width - 6.0) / (win_rect.Width * x_num);
            scale_y = (in_rect.Height - 6.0) / (win_rect.Height * y_num);
            if (scale_x < scale_y)
            {
                width = (int)(win_rect.Width * scale_x);
                height = (int)(win_rect.Height * scale_x);
            }
            else
            {
                width = (int)(win_rect.Width * scale_y);
                height = (int)(win_rect.Height * scale_y);
            }
            for (int y = 0; y < y_num; y++)
            {
                for (int x = 0; x < x_num; x++)
                {
                    no = y * x_num + x;
                    result[no].X = x * (width + 3);
                    result[no].Y = y * (height + 3);
                    result[no].Width = width;
                    result[no].Height = height;
                }
            }
            return result;
        }
        public static Rectangle Get_Window_Rect(int disp_x, int disp_y, int image_x, int image_y)
        {
            Rectangle result = new Rectangle();
            double disp_scale, image_scale;

            disp_scale = (double)disp_x / disp_y;
            image_scale = (double)image_x / image_y;
            if (disp_scale < image_scale)
            {
                result.X = 0;
                result.Y = 0;
                result.Width = (int)disp_x;
                result.Height = (int)(disp_x * image_scale);
            }
            else
            {
                result.X = 0;
                result.Y = 0;
                result.Width = (int)(disp_y * image_scale);
                result.Height = (int)(disp_y);
            }
            return result;
        }

        public static void SetPart(HWindowControl hw, HImage image)
        {
            int w, h;

            if (!Is_Empty(image))
            {
                image.GetImageSize(out w, out h);
                SetPart(hw, 0, 0, w, h);
            }
        }
        public static void SetPart(HWindowControl hw, double width, double height)
        {
            SetPart(hw, 0, 0, width, height);
        }
        public static void SetPart(HWindowControl hw, double x1, double y1, double x2, double y2)
        {
            SetPart(hw, new stRect_Double(x1, y1, x2, y2));
        }
        public static void SetPart(HWindowControl hw, stRect_Double rect)
        {
            stRect_Double tmp_rect = rect.Round(0);
            hw.HalconWindow.SetPart((int)tmp_rect.Y1, (int)tmp_rect.X1, (int)tmp_rect.Y2, (int)tmp_rect.X2);
        }

        public static void Set_HW_Size(HWindowControl hw, HImage image)
        {
            int w, h;
            if (!Is_Empty(image))
            {
                image.GetImageSize(out w, out h);
                Set_HW_Size(hw, w, h);
            }
        }
        public static void Set_HW_Size(HWindowControl hw, int w, int h)
        {
            Set_HW_Size(hw, hw.Left, hw.Top, hw.Left + w, hw.Top + h);
        }
        public static void Set_HW_Size(HWindowControl hw, double x1, double y1, double x2, double y2)
        {
            Set_HW_Size(hw, new stRect_Double(x1, y1, x2, y2));
        }
        public static void Set_HW_Size(HWindowControl hw, stRect_Double rect)
        {
            stRect_Double tmp_rect = rect.Round(0);

            hw.Left = (int)rect.X1;
            hw.Top = (int)rect.Y1;
            hw.Width = (int)rect.Width();
            hw.Height = (int)rect.Height();
        }

        public static void Copy_HW(HWindowControl sor_hw, HWindowControl dist_hw)
        {
            HImage dump_image;

            dump_image = new HImage();
            dump_image = sor_hw.HalconWindow.DumpWindowImage();
            dist_hw.HalconWindow.ClearWindow();
            dump_image.DispObj(dist_hw.HalconWindow);
        }
        public static HImage Affine_Trans_Image(HImage in_image, double dis_col, double dis_row, double dis_ang, double sor_col, double sor_row, double sor_ang)
        {
            HImage result = new HImage();
            HHomMat2D HomMat2D = new HHomMat2D();
            double d_angle;

            d_angle = dis_ang - sor_ang;
            HomMat2D.VectorAngleToRigid(sor_row, sor_col, sor_ang, dis_row, dis_col, dis_ang);
            if (Is_Not_Empty(in_image)) result = in_image.AffineTransImage(HomMat2D, "weighted", "false");
            return result;
        }
        public static HRegion Affine_Trans_Region(HRegion in_region, double dis_col, double dis_row, double dis_ang, double sor_col, double sor_row, double sor_ang)
        {
            HRegion result = new HRegion();
            HHomMat2D HomMat2D = new HHomMat2D();
            double d_angle;

            d_angle = dis_ang - sor_ang;
            HomMat2D.VectorAngleToRigid(sor_row, sor_col, sor_ang, dis_row, dis_col, d_angle);
            if (Is_Not_Empty(in_region)) result = in_region.AffineTransRegion(HomMat2D, "nearest_neighbor");
            return result;
        }
        public static HXLDCont Affine_Trans_XLD(HXLDCont in_xld, double dis_col, double dis_row, double dis_ang, double sor_col, double sor_row, double sor_ang)
        {
            HXLDCont result = new HXLDCont();
            HHomMat2D HomMat2D = new HHomMat2D();
            double d_angle;

            d_angle = dis_ang - sor_ang;
            HomMat2D.VectorAngleToRigid(dis_row, dis_col, d_angle, sor_row, sor_col, sor_ang);
            result = in_xld.AffineTransContourXld(HomMat2D);
            return result;
        }
        public static double Get_Scale(HImage image, double min = 1.0)
        {
            double result = 1;
            int w = 1, h = 1;
            string type;

            if (!JJS_Vision.Is_Empty(image))
            {
                image.GetImagePointer1(out type, out w, out h);
                result = min + w / 640.0;
            }
            return result;
        }
        public static HRegion Select_Region_Filter(HRegion region, string[] filter_list)
        {
            HRegion result = new HRegion();
            ArrayList list = new ArrayList();
            string features;
            string operation;
            double min, max;

            result = region.Clone();
            for (int i = 0; i < filter_list.Length; i++)
            {
                String_Tool.Break_String(filter_list[i], ",", ref list);
                if (list.Count == 4)
                {
                    try
                    {
                        features = list[0].ToString();
                        operation = list[1].ToString();
                        min = Convert.ToDouble(list[2].ToString());
                        max = Convert.ToDouble(list[3].ToString());
                        result = result.SelectShape(features, operation, min, max);
                    }
                    catch { }
                }
            }
            return result;
        }
        public static HRegion Select_Shape_Max(HRegion region)
        {
            HRegion result = null;
            HRegion tmp_region = null;

            if (region.CountObj() > 0)
            {
                result = region.SelectObj(1);
                for (int i = 1; i < region.CountObj(); i++)
                {
                    tmp_region = region.SelectObj(i + 1);
                    if (tmp_region.Area > result.Area) result = tmp_region.Clone();
                }
            }
            return result;
        }
        public static HRegion Select_Shape_Min(HRegion region)
        {
            HRegion result = null;
            HRegion tmp_region = null;

            if (region.CountObj() > 0)
            {
                result = region.SelectObj(1);
                for (int i = 1; i < region.CountObj(); i++)
                {
                    tmp_region = region.SelectObj(i + 1);
                    if (tmp_region.Area < result.Area) result = tmp_region.Clone();
                }
            }
            return result;
        }

        public static bool Get_Region_Smallest_Rect1(HRegion region, ref stRect_Double rect)
        {
            bool result = false;
            HRegion tmp_region = new HRegion();
            int r1, c1, r2, c2;

            try
            {
                if (Is_Not_Empty(region))
                {
                    for (int i = 0; i < region.CountObj(); i++)
                    {
                        tmp_region = region.CopyObj(i + 1, 1);
                        tmp_region.SmallestRectangle1(out r1, out c1, out r2, out c2);
                        if (i == 0)
                        {
                            rect.X1 = c1;
                            rect.Y1 = r1;
                            rect.X2 = c2;
                            rect.Y2 = r2;
                        }
                        else
                        {
                            if (c1 < rect.X1) rect.X1 = c1;
                            if (r1 < rect.Y1) rect.Y1 = r1;
                            if (c2 > rect.X2) rect.X2 = c2;
                            if (r2 > rect.Y2) rect.Y2 = r2;
                        }
                    }
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public static bool Get_Model_Smallest_Rect(HShapeModel model, ref stRect_Double rect)
        {
            bool result = false;

            if (JJS_Vision.Is_Not_Empty(model))
            {
                HXLDCont xld = model.GetShapeModelContours(1);
                result = Get_XLD_Smallest_Rect(xld, ref rect);
            }
            return result;
        }

        public static HRegion XLD_To_Region(HXLDCont xld)
        {
            HRegion result = new HRegion();
            HRegion tmp_region = new HRegion();
            HXLDCont tmp_xld = new HXLDCont();
            HTuple col, row;

            result.GenEmptyRegion();
            if (!Is_Empty(xld))
            {
                for (int i = 0; i < xld.CountObj(); i++)
                {
                    tmp_xld = xld.SelectObj(i + 1);
                    tmp_xld.GetContourXld(out row, out col);
                    tmp_region.GenRegionPolygon(row, col);
                    result = result.ConcatObj(tmp_region);
                }
            }
            return result;
        }
        public static HXLDCont Select_XLD(HXLDCont in_xld, string mode)
        {
            HXLDCont result = null;
            HXLDCont tmp_xld = new HXLDCont();
            double length = 0, tmp_length;
            int count = 0;

            if (in_xld != null)
            {
                count = in_xld.CountObj();
                for (int i = 0; i < count; i++)
                {
                    tmp_xld = in_xld.CopyObj(i + 1, 1);
                    switch (mode)
                    {
                        case "max_length":
                            tmp_length = tmp_xld.LengthXld();
                            if (tmp_length > length)
                            {
                                length = tmp_length;
                                result = tmp_xld.CopyObj(1, -1);
                            }
                            break;
                    }
                }
            }
            return result;
        }

        public static TJJS_Line Get_XLD_Line(HTuple point_rows, HTuple point_cols)
        {
            HXLDCont xld = new HXLDCont();
            xld.GenContourPolygonXld(point_rows, point_cols);

            return Get_XLD_Line(xld);
        }
        public static TJJS_Line Get_XLD_Line(HXLDCont in_xld)
        {
            TJJS_Line result = null;
            double out_s_col, out_s_row, out_e_col, out_e_row, out_nr, out_nc, out_dist;

            try
            {
                if (in_xld != null && in_xld.CountObj() == 1)
                {
                    in_xld.FitLineContourXld("tukey", -1, 0, 5, 2,
                                               out out_s_row, out out_s_col, out out_e_row, out out_e_col,
                                               out out_nr, out out_nc,
                                               out out_dist);
                    result = new TJJS_Line();
                    result.Start = new TJJS_Point(out_s_col, out_s_row);
                    result.End = new TJJS_Point(out_e_col, out_e_row);
                }
            }
            catch { }

            return result;
        }
        public static TJJS_Circle Get_XLD_Circle(HTuple point_rows, HTuple point_cols)
        {
            HXLDCont xld = new HXLDCont();
            if (point_rows.Length >= 1)
            {
                xld.GenContourPolygonXld(point_rows, point_cols);
            };

            return Get_XLD_Circle(xld);
        }
        public static TJJS_Circle Get_XLD_Circle(HXLDCont in_xld)
        {
            TJJS_Circle result = new TJJS_Circle();
            HTuple t_row = new HTuple();
            HTuple t_column = new HTuple();
            HTuple t_radius = new HTuple();
            HTuple t_startPhi = new HTuple();
            HTuple t_endPhi = new HTuple();
            HTuple t_pointOrder = new HTuple();

            try
            {
                if (in_xld != null && in_xld.CountObj() == 1)
                {
                    in_xld.FitCircleContourXld("algebraic", -1, 0, 0, 3, 2, out t_row, out t_column, out t_radius, out t_startPhi, out t_endPhi, out t_pointOrder);

                    result = new TJJS_Circle();
                    result.Center.X = t_column;
                    result.Center.Y = t_row;
                    result.R = t_radius;
                }
            }
            catch { }

            return result;
        }
        public static bool Get_XLD_Smallest_Rect(HXLDCont xld, ref stRect_Double rect)
        {
            bool result = false;
            HXLDCont tmp_xld = new HXLDCont();
            double r1, c1, r2, c2;

            try
            {
                if (xld != null)
                {
                    for (int i = 0; i < xld.CountObj(); i++)
                    {
                        tmp_xld = xld.CopyObj(i + 1, 1);
                        tmp_xld.SmallestRectangle1Xld(out r1, out c1, out r2, out c2);
                        if (i == 0)
                        {
                            rect.X1 = c1;
                            rect.Y1 = r1;
                            rect.X2 = c2;
                            rect.Y2 = r2;
                        }
                        else
                        {
                            if (c1 < rect.X1) rect.X1 = c1;
                            if (r1 < rect.Y1) rect.Y1 = r1;
                            if (c2 > rect.X2) rect.X2 = c2;
                            if (r2 > rect.Y2) rect.Y2 = r2;
                        }
                    }
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        
        
        
        public static HImage Sub_Image_EFC(HImage image_min, HImage image_max, HImage in_image)
        {
            HImage result = new HImage();
            //int w, h;
            //string type;
            //IntPtr min_ptr = new IntPtr();
            //IntPtr max_ptr = new IntPtr();
            //IntPtr sub_ptr = new IntPtr();
            //IntPtr result_ptr = new IntPtr();

            result = in_image.Clone();
            //unsafe
            //{
            //    sub_ptr = in_image.GetImagePointer1(out type, out w, out h);
            //    min_ptr = image_min.GetImagePointer1(out type, out w, out h);
            //    max_ptr = image_max.GetImagePointer1(out type, out w, out h);
            //    result_ptr = result.GetImagePointer1(out type, out w, out h);

            //    byte* b_sub_ptr = (byte*)sub_ptr;
            //    byte* b_min_ptr = (byte*)min_ptr;
            //    byte* b_max_ptr = (byte*)max_ptr;
            //    byte* b_result_ptr = (byte*)result_ptr;
            //    byte sub, min, max;
            //    byte d_max, d_min;
            //    for (int i = 0; i < w * h; i++)
            //    {
            //        sub = *(b_sub_ptr + i);
            //        min = *(b_min_ptr + i);
            //        max = *(b_max_ptr + i);
            //        d_max = (byte)(sub - max);
            //        d_min = (byte)(min - sub);
            //        if (d_max > 127) d_max = 127;
            //        if (d_min > 127) d_min = 127;
            //        if (i == 142 + 229 * w)
            //        {
            //            *(b_result_ptr + i) = 128;
            //        }

            //        if (sub > max)
            //            *(b_result_ptr + i) = (byte)(128 + d_max);
            //        else if (sub < min)
            //            *(b_result_ptr + i) = (byte)(128 - d_min);
            //        else
            //            *(b_result_ptr + i) = 128;
            //    }
            //}
            return result;
        }
        public static HImage Scale_Image_EFC(HImage in_image, double percent = 100.0)
        {
            HImage result = null;
            int w = 0, h = 0;
            double min = 0.0, max = 255.0, range = 255.0;
            HRegion region = new HRegion();
            double mut, ofs;

            in_image.GetImageSize(out w, out h);
            region.GenRectangle1(0.0, 0.0, h, w);
            in_image.MinMaxGray(region, 0, out min, out max, out range);
            range = range * percent / 100;

            mut = 255.0 / range;
            ofs = -min * 255.0 / range;
            result = in_image.ScaleImage(mut, ofs);
            result = result.ConvertImageType("byte");
            return result;
        }
        public static HImage Scale_Image_EFC(HImage in_image, double min, double max)
        {
            HImage result = null;
            double range = 255.0;
            double mut, ofs;

            range = max - min;
            mut = 255.0 / range;
            ofs = -min * 255.0 / range;
            result = in_image.ScaleImage(mut, ofs);
            result = result.ConvertImageType("byte");
            return result;
        }




        public static HImage Mean_Image_Light(HImage image, int size_x, int size_y)
        {
            HImage result = new HImage();
            HImage tmp_image = new HImage();

            tmp_image = image.MeanImage(size_x, size_y);
            tmp_image = tmp_image.InvertImage();
            result = image.AddImage(tmp_image, 0.5, 0);
            return result;
        }
        public static TShape_Model_Param Get_ShapeModel_Param(HShapeModel model)
        {

            TShape_Model_Param result = new TShape_Model_Param();

            if (JJS_Vision.Is_Not_Empty(model))
            {
                double angleStart;
                double angleExtent;
                double angleStep;
                HTuple scaleMin = new HTuple();
                HTuple scaleMax = new HTuple();
                HTuple scaleStep = new HTuple();
                string metric;
                int minContrast;

                model.GetShapeModelParams(out angleStart, out angleExtent, out angleStep, out scaleMin, out scaleMax, out scaleStep,
                                          out metric, out minContrast);

                result.Angle_Start = angleStart;
                result.Angle_Extent = angleExtent;
                result.Angle_Step = angleStep;
                result.Scale_Min = scaleMin;
                result.Scale_Max = scaleMax;
                result.Scale_Step = scaleStep;
                result.Metric = metric;
                result.Min_Contrast = minContrast;

                model.GetShapeModelOrigin(out result.Origin_Row, out result.Origin_Col);

                //result.Num_Levels = 7;
                //result.Optimization = "none";
                //result.Metric = "ignore_local_polarity";
                if (result.Scale_Step.D == 0) result.Scale_Step = "auto";
            }
            return result;
        }

        public static bool Find_Line_Edge_Sub_Pixel(HImage in_image, double col1, double row1, double col2, double row2, out TJJS_Line out_line)
        {
            bool result = false;
            HImage tmp_image = new HImage();
            HRegion region = new HRegion();

            out_line = new TJJS_Line(0, 0, 0, 0);
            region.GenRectangle1(row1, col1, row2, col2);
            tmp_image = in_image.ReduceDomain(region);
            result = Find_Line_Edge_Sub_Pixel(tmp_image, out out_line);

            tmp_image.Dispose();
            region.Dispose();
            return result;
        }
        public static bool Find_Line_Edge_Sub_Pixel(HImage in_image, double col, double row, double len1, double len2, double phi, out TJJS_Line out_line)
        {
            bool result = false;
            HImage tmp_image = new HImage();
            HRegion region = new HRegion();

            out_line = new TJJS_Line(0, 0, 0, 0);
            region.GenRectangle2(row, col, len1, len2, phi);
            tmp_image = in_image.ReduceDomain(region);
            result = Find_Line_Edge_Sub_Pixel(tmp_image, out out_line);

            tmp_image.Dispose();
            region.Dispose();
            return result;
        }
        public static bool Find_Line_Edge_Sub_Pixel(HImage in_image, out TJJS_Line out_line)
        {
            bool result = false;
            stEdge_Sub_Pixel_Param param = new stEdge_Sub_Pixel_Param();

            param.Set_Default();
            result = Find_Line_Edge_Sub_Pixel(in_image, param, out out_line);
            return result;
        }
        public static bool Find_Line_Edge_Sub_Pixel(HImage in_image, stEdge_Sub_Pixel_Param param, out TJJS_Line out_line)
        {
            bool result = false;
            HRegion region = new HRegion();
            HImage tmp_image = new HImage();
            HXLDCont xld = new HXLDCont();
            HXLDCont select_xld = new HXLDCont();

            out_line = new TJJS_Line(0, 0, 0, 0);
            try
            {
                xld = in_image.EdgesSubPix(param.Filter, param.Alpha, param.Low, param.High);
                xld = xld.SegmentContoursXld(param.Mode, param.Smooth_Count, param.Max_Line_Dist1, param.Max_Line_Dist2);
                select_xld = Select_XLD(xld, "max_length");
                out_line = Get_XLD_Line(select_xld);
                if (out_line != null) result = true;
            }
            catch { };

            if (region != null) region.Dispose();
            if (tmp_image != null) tmp_image.Dispose();
            if (xld != null) xld.Dispose();
            if (select_xld != null) select_xld.Dispose();
            return result;
        }

        //-----------------------------------------------------------------------------------------------------
        // 功能:用兩同心圓取得量測矩形
        // flag = false, 方向向圓心 flag = true, 方向向外
        //-----------------------------------------------------------------------------------------------------
        public static stRectangle2[] Get_Measure_Rect(double row, double col, double radius1, double radius2, double start_ang, double end_ang, int step, bool flag = false)
        {
            stRectangle2[] result = new stRectangle2[step + 1];
            TJJS_Point center = new TJJS_Point();
            TJJS_Point p = new TJJS_Point();
            TJJS_Angle ang = new TJJS_Angle();

            for (int i = 0; i < result.Length; i++) result[i] = new stRectangle2();
            double ofs = (radius1 + radius2) / 2;
            double c = 0, r = 0;
            double phi = 0;
            double len1 = Math.Abs((radius2 - radius1) / 2);
            double len2 = 3;
            double step_ang = 0;

            center.Set(col, row);
            step_ang = (end_ang - start_ang) / (step - 1);
            for (int i = 0; i < step; i++)
            {
                phi = start_ang + step_ang * i;

                ang.r = -phi;
                p.Set(col + ofs, row);
                p = p.Rotate(center, ang.d);
                c = p.X;
                r = p.Y;

                if (flag)
                    result[i].Set(r, c, len1, len2, phi);
                else
                    result[i].Set(r, c, len1, len2, Math.PI + phi);
            }
            return result;
        }

        //-----------------------------------------------------------------------------------------------------
        // 功能:用一條直線取得量測矩形
        // flag = 量測矩形方向
        //-----------------------------------------------------------------------------------------------------
        static public stRectangle2[] Get_Measure_Rect(TJJS_Line l, double len1, double len2, int step, bool flag = false)
        {
            stRectangle2[] result = new stRectangle2[step + 1];
            double ofs_c = (l.End.X - l.Start.X) / step;
            double ofs_r = (l.End.Y - l.Start.Y) / step;
            double c = 0, r = 0;
            double phi = l.V.Angle.r + Math.PI / 2;

            for (int i = 0; i < step + 1; i++)
            {
                c = l.Start.X + ofs_c * i;
                r = l.Start.Y + ofs_r * i;

                if (flag)
                    result[i].Set(r, c, len1, len2, phi);
                else
                    result[i].Set(r, c, len1, len2, Math.PI + phi);
            }
            return result;
        }

        //-----------------------------------------------------------------------------------------------------
        // 功能:取得量測矩形的點
        //-----------------------------------------------------------------------------------------------------
        static public void Measure_Pos_Rect2(HImage image, stRectangle2[] rect, double sigma, double threshold, string transition, string select, out HTuple point_r, out HTuple point_c)
        {
            HMeasure measure_rect = new HMeasure();
            int w, h;
            HTuple rows = new HTuple();
            HTuple cols = new HTuple();
            HTuple amps = new HTuple();
            HTuple dists = new HTuple();

            point_r = new HTuple();
            point_c = new HTuple();
            image.GetImageSize(out w, out h);
            for (int i = 0; i < rect.Length; i++)
            {
                try
                {
                    measure_rect.GenMeasureRectangle2(rect[i].Row, rect[i].Col, rect[i].Phi, rect[i].Len1, rect[i].Len2, w, h, emMeasure_Interpolation.nearest_neighbor);
                    measure_rect.MeasurePos(image, sigma, threshold, transition, select, out rows, out cols, out amps, out dists);
                    if (rows.Length > 0)
                    {
                        for (int j = 0; j < rows.Length; j++)
                        {
                            point_r.Append(rows.DArr[j]);
                            point_c.Append(cols.DArr[j]);
                        }
                    }
                }
                catch { }
            }
        }

        static public void Read_File(ref HRegion region, string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                if (region == null) region = new HRegion();
                region.ReadRegion(filename);
            }
        }
        static public void Read_File(ref HImage image, string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                if (image == null) image = new HImage();
                image.ReadImage(filename);
            }
        }
        static public void Read_File(ref THImage_HSV image_hsv, string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                HImage image = new HImage();
                Read_File(ref image, filename);
                if (image_hsv == null) image_hsv = new THImage_HSV();
                image_hsv.Set_Image(image);
            }
        }
        static public void Write_File(HRegion region, string filename)
        {
            File_Path_Tool.CreateDirectory(filename);
            if (JJS_Vision.Is_Not_Empty(region)) region.WriteRegion(filename);
        }
        static public void Write_File(HImage image, string filename)
        {
               string ext = File_Path_Tool.Get_FileName_Ext(filename);

                if (ext.ToUpper() == "BMP") Write_File(image, "bmp", 0, filename);
                else Write_File(image, "jpg", 0, filename);
        }
        static public void Write_File(HImage image, string format, int fillcolor, string filename)
        {
            File_Path_Tool.CreateDirectory(filename);
            if (JJS_Vision.Is_Not_Empty(image))
            {
                image.WriteImage(format, fillcolor, filename);
            }
        }

        static public bool Edit_Region(HImage in_image, ref HRegion out_region)
        {
            bool result = false;

            TForm_Select_Area form = new TForm_Select_Area(in_image, out_region);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Copy_Obj(form.Select_Region, ref out_region);
                result = true;
            }

            return result;
        }


    }

    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class Dialog_Tool
    {
        public static string Open_Dialog(string filter, string directory = "", string default_filename = "", int fielter_index = 1)
        {
            string result = "";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (directory != "") dialog.InitialDirectory = directory;
            if (default_filename != "") dialog.FileName = default_filename;
            dialog.FilterIndex = fielter_index;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.FileName;
            }
            return result;
        }
        public static HImage Open_Dialog_Image(string directory = "", string default_filename = "", int fielter_index = 1)
        {
            HImage result = new HImage();
            string get_filename = "";
            string filter = "影像檔案(*.jpg)|*.jpg|影像檔案(*.bmp)|*.bmp";

            get_filename = Open_Dialog(filter, directory, default_filename, fielter_index);
            if (get_filename != "")
            {
                result.ReadImage(get_filename);
            }
            return result;
        }
        public static HShapeModel Open_Dialog_Model(string directory = "", string default_filename = "")
        {
            HShapeModel result = new HShapeModel();
            string get_filename = "";
            string filter = "Model File(*.mod)|*.mod";

            get_filename = Open_Dialog(filter, directory, default_filename);
            if (get_filename != "")
            {
                result.ReadShapeModel(get_filename);
            }
            return result;
        }
        public static HRegion Open_Dialog_Regionl(string directory = "", string default_filename = "")
        {
            HRegion result = new HRegion();
            string get_filename = "";
            string filter = "Region File(*.rgn)|*.rgn";

            get_filename = Open_Dialog(filter, directory, default_filename);
            if (get_filename != "")
            {
                result.ReadRegion(get_filename);
            }
            return result;
        }

        public static string Save_Dialog(string filter, string directory = "", string default_filename = "")
        {
            string result = "";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = filter;
            if (directory != "") dialog.InitialDirectory = directory;
            if (default_filename != "") dialog.FileName = default_filename;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                result = dialog.FileName;
            }
            return result;
        }
        public static bool Save_Dialog_Image(HImage image, string directory = "", string default_filename = "")
        {
            bool result = false;
            string get_filename = "";
            string filter = "影像檔案(*.jpg)|*.jpg|影像檔案(*.bmp)|*.bmp";
            string ext = "";

            get_filename = Save_Dialog(filter, directory, default_filename);
            if (get_filename != null && JJS_Vision.Is_Not_Empty(image))
            {
                ext = System.IO.Path.GetExtension(get_filename).ToUpper();
                switch (ext)
                {
                    case ".BMP": image.WriteImage("bmp", 0, get_filename); result = true; break;
                    case ".JPG": image.WriteImage("jpg", 0, get_filename); result = true; break;
                }
            }
            return result;
        }
        public static bool Save_Dialog_Model(HShapeModel model, string directory = "", string default_filename = "")
        {
            bool result = false;
            string get_filename = "";
            string filter = "Model File(*.mod)|*.mod";

            get_filename = Save_Dialog(filter, directory, default_filename);
            if (get_filename != null && JJS_Vision.Is_Not_Empty(model))
            {
                model.WriteShapeModel(get_filename);
                result = true;
            }
            return result;
        }
        public static bool Save_Dialog_Regionl(HRegion region, string directory = "", string default_filename = "")
        {
            bool result = false;
            string get_filename = "";
            string filter = "Region File(*.rgn)|*.rgn";

            get_filename = Save_Dialog(filter, directory, default_filename);
            if (get_filename != null && JJS_Vision.Is_Not_Empty(region))
            {
                region.WriteRegion(get_filename);
                result = true;
            }
            return result;
        }

    }

    //-----------------------------------------------------------------------------------------------------
    //Vision 物件
    //-----------------------------------------------------------------------------------------------------
    public struct stRegion_Info
    {
        public double       X,
                            Y;

        public double       Area,
                            Col,
                            Row;

        public double       Circularity;
        public double       Compactness;
        public double       Cont_Length;
        public double       Convexity;

        public int          Diameter_Col1,
                            Diameter_Row1,
                            Diameter_Col2,
                            Diameter_Row2;
        public double       Diameter;

        public double       Eccentricity_Anisometry,
                            Eccentricity_Bulkiness,
                            Eccentricity_Structure_Factor;

        public double       Elliptic_RA,
                            Elliptic_RB,
                            Elliptic_Phi;

        public double       Inner_Circle_Row,
                            Inner_Circle_Col,
                            Inner_Circle_Radius;

        public double       Outer_Circle_Row,
                            Outer_Circle_Col,
                            Outer_Circle_Radius;

        public int          Inner_Rect1_Row1,
                            Inner_Rect1_Col1,
                            Inner_Rect1_Row2,
                            Inner_Rect1_Col2;
        public double       Inner_Rect1_Len1,
                            Inner_Rect1_Len2;

        public int          Outer_Rect1_Row1,
                            Outer_Rect1_Col1,
                            Outer_Rect1_Row2,
                            Outer_Rect1_Col2;
        public double       Outer_Rect1_Len1,
                            Outer_Rect1_Len2;

        public double       Outer_Rect2_Row,
                            Outer_Rect2_Col,
                            Outer_Rect2_Phi,
                            Outer_Rect2_Len1,
                            Outer_Rect2_Len2;

        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                X = ini.ReadFloat(section, "X", 0.0);
                Y = ini.ReadFloat(section, "Y", 0.0);
 
                Area = ini.ReadFloat(section, "Area", 0.0);
                Col = ini.ReadFloat(section, "Col", 0.0);
                Row = ini.ReadFloat(section, "Row", 0.0);

                Circularity = ini.ReadFloat(section, "Circularity", 0.0);
                Compactness = ini.ReadFloat(section, "Compactness", 0.0);
                Cont_Length = ini.ReadFloat(section, "Cont_Length", 0.0);
                Convexity = ini.ReadFloat(section, "Convexity", 0.0);

                Diameter_Col1 = ini.ReadInteger(section, "Diameter_Col1", 0);
                Diameter_Row1 = ini.ReadInteger(section, "Diameter_Row1", 0);
                Diameter_Col2 = ini.ReadInteger(section, "Diameter_Col2", 0);
                Diameter_Row2 = ini.ReadInteger(section, "Diameter_Row2", 0);
                Diameter = ini.ReadFloat(section, "Diameter", 0.0);

                Eccentricity_Anisometry = ini.ReadFloat(section, "Eccentricity_Anisometry", 0.0);
                Eccentricity_Bulkiness = ini.ReadFloat(section, "Eccentricity_Bulkiness", 0.0);
                Eccentricity_Structure_Factor = ini.ReadFloat(section, "Eccentricity_Structure_Factor", 0.0);

                Elliptic_RA = ini.ReadFloat(section, "Elliptic_RA", 0.0);
                Elliptic_RB = ini.ReadFloat(section, "Elliptic_RB", 0.0);
                Elliptic_Phi = ini.ReadFloat(section, "Elliptic_Phi", 0.0);

                Inner_Circle_Row = ini.ReadFloat(section, "Inner_Circle_Row", 0.0);
                Inner_Circle_Col = ini.ReadFloat(section, "Inner_Circle_Col", 0.0);
                Inner_Circle_Radius = ini.ReadFloat(section, "Inner_Circle_Radius", 0.0);

                Outer_Circle_Row = ini.ReadFloat(section, "Outer_Circle_Row", 0.0);
                Outer_Circle_Col = ini.ReadFloat(section, "Outer_Circle_Col", 0.0);
                Outer_Circle_Radius = ini.ReadFloat(section, "Outer_Circle_Radius", 0.0);


                Inner_Rect1_Row1 = ini.ReadInteger(section, "Inner_Rect1_Row1", 0);
                Inner_Rect1_Col1 = ini.ReadInteger(section, "Inner_Rect1_Col1", 0);
                Inner_Rect1_Row2 = ini.ReadInteger(section, "Inner_Rect1_Row2", 0);
                Inner_Rect1_Col2 = ini.ReadInteger(section, "Inner_Rect1_Col2", 0);
                Inner_Rect1_Len1 = ini.ReadFloat(section, "Inner_Rect1_Len1", 0.0);
                Inner_Rect1_Len2 = ini.ReadFloat(section, "Inner_Rect1_Len2", 0.0);

                Outer_Rect1_Row1 = ini.ReadInteger(section, "Outer_Rect1_Row1", 0);
                Outer_Rect1_Col1 = ini.ReadInteger(section, "Outer_Rect1_Col1", 0);
                Outer_Rect1_Row2 = ini.ReadInteger(section, "Outer_Rect1_Row2", 0);
                Outer_Rect1_Col2 = ini.ReadInteger(section, "Outer_Rect1_Col2", 0);
                Outer_Rect1_Len1 = ini.ReadFloat(section, "Outer_Rect1_Len1", 0.0);
                Outer_Rect1_Len2 = ini.ReadFloat(section, "Outer_Rect1_Len2", 0.0);


                Outer_Rect2_Row = ini.ReadFloat(section, "Outer_Rect2_Row", 0.0);
                Outer_Rect2_Col = ini.ReadFloat(section, "Outer_Rect2_Col", 0.0);
                Outer_Rect2_Phi = ini.ReadFloat(section, "Outer_Rect2_Phi", 0.0);
                Outer_Rect2_Len1 = ini.ReadFloat(section, "Outer_Rect2_Len1", 0.0);
                Outer_Rect2_Len2 = ini.ReadFloat(section, "Outer_Rect2_Len2", 0.0);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);

                ini.WriteFloat(section, "Area", Area);
                ini.WriteFloat(section, "Col", Col);
                ini.WriteFloat(section, "Row", Row);
               
                ini.WriteFloat(section, "Circularity", Circularity);
                ini.WriteFloat(section, "Compactness", Compactness);
                ini.WriteFloat(section, "Cont_Length", Cont_Length);
                ini.WriteFloat(section, "Convexity", Convexity);
                  
                ini.WriteInteger(section, "Diameter_Col1", Diameter_Col1);
                ini.WriteInteger(section, "Diameter_Row1", Diameter_Row1);
                ini.WriteInteger(section, "Diameter_Col2", Diameter_Col2);
                ini.WriteInteger(section, "Diameter_Row2", Diameter_Row2);
                ini.WriteFloat(section, "Diameter", Diameter);
                 
                ini.WriteFloat(section, "Eccentricity_Anisometry", Eccentricity_Anisometry);
                ini.WriteFloat(section, "Eccentricity_Bulkiness", Eccentricity_Bulkiness);
                ini.WriteFloat(section, "Eccentricity_Structure_Factor", Eccentricity_Structure_Factor);

                ini.WriteFloat(section, "Elliptic_RA", Elliptic_RA);
                ini.WriteFloat(section, "Elliptic_RB", Elliptic_RB);
                ini.WriteFloat(section, "Elliptic_Phi", Elliptic_Phi);
                  
                ini.WriteFloat(section, "Inner_Circle_Row", Inner_Circle_Row);
                ini.WriteFloat(section, "Inner_Circle_Col", Inner_Circle_Col);
                ini.WriteFloat(section, "Inner_Circle_Radius", Inner_Circle_Radius);
                  
                ini.WriteFloat(section, "Outer_Circle_Row", Outer_Circle_Row);
                ini.WriteFloat(section, "Outer_Circle_Col", Outer_Circle_Col);
                ini.WriteFloat(section, "Outer_Circle_Radius", Outer_Circle_Radius);

                ini.WriteInteger(section, "Inner_Rect1_Row1", Inner_Rect1_Row1);
                ini.WriteInteger(section, "Inner_Rect1_Col1", Inner_Rect1_Col1);
                ini.WriteInteger(section, "Inner_Rect1_Row2", Inner_Rect1_Row2);
                ini.WriteInteger(section, "Inner_Rect1_Col2", Inner_Rect1_Col2);
                ini.WriteFloat(section, "Inner_Rect1_Len1", Inner_Rect1_Len1);
                ini.WriteFloat(section, "Inner_Rect1_Len2", Inner_Rect1_Len2);

                ini.WriteInteger(section, "Outer_Rect1_Row1", Outer_Rect1_Row1);
                ini.WriteInteger(section, "Outer_Rect1_Col1", Outer_Rect1_Col1);
                ini.WriteInteger(section, "Outer_Rect1_Row2", Outer_Rect1_Row2);
                ini.WriteInteger(section, "Outer_Rect1_Col2", Outer_Rect1_Col2);
                ini.WriteFloat(section, "Outer_Rect1_Len1", Outer_Rect1_Len1);
                ini.WriteFloat(section, "Outer_Rect1_Len2", Outer_Rect1_Len2);
             
                ini.WriteFloat(section, "Outer_Rect2_Row", Outer_Rect2_Row);
                ini.WriteFloat(section, "Outer_Rect2_Col", Outer_Rect2_Col);
                ini.WriteFloat(section, "Outer_Rect2_Phi", Outer_Rect2_Phi);
                ini.WriteFloat(section, "Outer_Rect2_Len1", Outer_Rect2_Len1);
                ini.WriteFloat(section, "Outer_Rect2_Len2", Outer_Rect2_Len2);
            }
        }                
    }
    public struct stRectangle2
    {
        public double Col,
                      Row,
                      Len1,
                      Len2,
                      Phi;
        public void Set(double row, double col, double len1, double len2, double phi)
        {
            Col = col;
            Row = row;
            Len1 = len1;
            Len2 = len2;
            Phi = phi;
        }

        //-----------------------------------------------------------------------------------------------------
        //用四方形決定，flag = false X軸向， flag = true Y軸向
        //-----------------------------------------------------------------------------------------------------
        public void Set(double c1, double r1, double c2, double r2, bool flag = false)
        {
            TJJS_Line line = new TJJS_Line();
            double ofs = 0.0;

            if (!flag)
            {
                line.Start = new TJJS_Point(c1, (r2 + r1) / 2);
                line.End = new TJJS_Point(c2, (r2 + r1) / 2);
                ofs = (r2 - r1) / 2;
            }
            else
            {
                line.Start = new TJJS_Point((c2 + c1) / 2, r1);
                line.End = new TJJS_Point((c2 + c1) / 2, r2);
                ofs = (c2 - c1) / 2;
            }
            Set(line, ofs);
        }

        //-----------------------------------------------------------------------------------------------------
        //一條直線決定， ofs = len1, line長 = len2
        //-----------------------------------------------------------------------------------------------------
        public void Set(TJJS_Line line, double ofs)
        {
            TJJS_Angle ang = new TJJS_Angle();
            ang.d = -line.V.Angle.d - 90;

            Len1 = ofs;
            Len2 = line.Length() / 2;
            Phi = ang.r;
            Col = line.Mid.X;
            Row = line.Mid.Y;
        }
    }
    public struct stEdge_Sub_Pixel_Param
    {
        public string Filter;
        public double Alpha;
        public int Low;
        public int High;

        public string Mode;
        public int Smooth_Count;
        public double Max_Line_Dist1;
        public double Max_Line_Dist2;

        public void Set_Default()
        {
            Filter = "canny";
            Alpha = 1;
            Low = 20;
            High = 40;

            Mode = "lines";
            Smooth_Count = 5;
            Max_Line_Dist1 = 4;
            Max_Line_Dist2 = 2;
        }
        public void Set(string filter, double alpha, double low, double high, string mode, int smooth_count, double dist1, double dist2)
        {
            Filter = filter;
            Alpha = alpha;
            Low = (int)low;
            High = (int)high;

            Mode = mode;
            Smooth_Count = smooth_count;
            Max_Line_Dist1 = dist1;
            Max_Line_Dist2 = dist2;
        }
    }
    public class TJJS_ShapeModel : TBase_Class
    {
        private string               FFile_Name;
        public string                Default_Path,
                                     Default_FileName;

        public HShapeModel           Model = new HShapeModel();
        public HXLDCont              XLD = new HXLDCont();

        public string File_Name
        {
            get
            {
                return FFile_Name;
            }
        }
        public TJJS_ShapeModel()
        {
            FFile_Name = "";
            Default_Path = "";
            Default_FileName = "";
            Set_Default();
        }
        public void Set_Default()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TJJS_ShapeModel();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_ShapeModel && dis_base is TJJS_ShapeModel)
            {
                TJJS_ShapeModel sor = (TJJS_ShapeModel)sor_base;
                TJJS_ShapeModel dis = (TJJS_ShapeModel)dis_base;

                dis.FFile_Name = sor.FFile_Name;
                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                try
                {
                    dis.Model = sor.Model.Clone();
                    dis.XLD = sor.XLD.CopyObj(1, -1);
                }
                catch
                {

                }
            }
        }
        public bool Read(string file_name)
        {
            bool result = false;

            FFile_Name = file_name;
            try
            {
                if (System.IO.File.Exists(FFile_Name))
                {
                    Model.ReadShapeModel(FFile_Name);
                    XLD = Model.GetShapeModelContours(1);
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool Read()
        {
            return Read(Default_Path + Default_FileName);
        }
        public bool Write(string file_name)
        {
            bool result = false;
            string path = "";

            FFile_Name = file_name;
            try
            {
                path = System.IO.Path.GetDirectoryName(FFile_Name);
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FFile_Name));
                Model.WriteShapeModel(FFile_Name);
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool Write()
        {
            return Write(Default_Path + Default_FileName);
        }
        public void Set_Part(HWindowControl hw)
        {
            stRect_Double rect = new stRect_Double();

            try
            {
                JJS_Vision.Get_XLD_Smallest_Rect(XLD, ref rect);
                rect = rect.To_Square();
                rect = rect.Offset(rect.Width() * 0.1);
                hw.HalconWindow.SetPart((int)rect.Y1, (int)rect.X1, (int)rect.Y2, (int)rect.X2);
            }
            catch (Exception)
            {

            }
        }
    }
    public class TJJS_NCC_Model : TBase_Class
    {
        private string FFile_Name;
        public string  Default_Path,
                       Default_FileName;

        public HNCCModel Model = new HNCCModel();
        public HImage Image = new HImage();

        public string File_Name
        {
            get
            {
                return FFile_Name;
            }
        }
        public TJJS_NCC_Model()
        {
            FFile_Name = "";
            Default_Path = "";
            Default_FileName = "";
            Set_Default();
        }
        public void Set_Default()
        {

        }
        override public TBase_Class New_Class()
        {
             return new TJJS_NCC_Model();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_NCC_Model && dis_base is TJJS_NCC_Model)
            {
                TJJS_NCC_Model sor = (TJJS_NCC_Model)sor_base;
                TJJS_NCC_Model dis = (TJJS_NCC_Model)dis_base;

                dis.FFile_Name = sor.FFile_Name;
                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                try
                {
                    dis.Model = sor.Model.Clone();
                    dis.Image = sor.Image.Clone();
                }
                catch
                {

                }
            }
        }
        public bool Read(string file_name)
        {
            bool result = false;

            FFile_Name = file_name;
            try
            {
                if (System.IO.File.Exists(FFile_Name))
                {
                    Model.ReadNccModel(FFile_Name);
                    Image.ReadImage(FFile_Name + ".bmp");
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool Read()
        {
            return Read(Default_Path + Default_FileName);
        }
        public bool Write(string file_name)
        {
            bool result = false;
            string path = "";

            FFile_Name = file_name;
            try
            {
                path = System.IO.Path.GetDirectoryName(FFile_Name);
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FFile_Name));
                Model.WriteNccModel(FFile_Name);
                Image.WriteImage("bmp", 1, FFile_Name + ".bmp");
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool Write()
        {
            return Write(Default_Path + Default_FileName);
        }
        public void Set_Part(HWindowControl hw)
        {
            stRect_Double rect = new stRect_Double();

            try
            {
                JJS_Vision.SetPart(hw, Image);
            }
            catch (Exception)
            {

            }
        }
    }
    public class TJJS_Region : TBase_Class
    {
        private string               FFile_Name;
        public string                Default_Path,
                                     Default_FileName;
        public HRegion               Region = new HRegion();

        public string File_Name
        {
            get
            {
                return FFile_Name;
            }
        }
        public TJJS_Region()
        {
            FFile_Name = "";
            Default_Path = "";
            Default_FileName = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Region.GenEmptyRegion();
        }
        public override TBase_Class New_Class()
        {
            return new TJJS_Region();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Region && dis_base is TJJS_Region)
            {
                TJJS_Region sor = (TJJS_Region)sor_base;
                TJJS_Region dis = (TJJS_Region)dis_base;

                dis.FFile_Name = sor.FFile_Name;
                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.Region = sor.Region.Clone();
            }
        }

        public bool Read(string file_name)
        {
            bool result = false;

            FFile_Name = file_name;
            if (System.IO.File.Exists(FFile_Name))
            {
                Region.ReadRegion(FFile_Name);
                result = true;
            }
            return result;
        }
        public bool Read()
        {
            return Read(Default_Path + Default_FileName);
        }
        public bool Write(string file_name)
        {
            bool result = false;

            FFile_Name = file_name;
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FFile_Name));               
                Region.WriteRegion(FFile_Name);
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }
        public bool Write()
        {
            return Write(Default_Path + Default_FileName);
        }
    }
    public class TShape_Model_Param : TBase_Class
    {
        public HTuple    Num_Levels = new HTuple();
        public double    Angle_Start,
                         Angle_Extent;
        public HTuple    Angle_Step = new HTuple();
        public double    Scale_Min,
                         Scale_Max;
        public HTuple    Scale_Step = new HTuple();
        //public HTuple    Optimization = new HTuple();
        public string    Metric;
        public int       Min_Contrast;
        public double    Origin_Col,
                         Origin_Row;

        public void Set_Default()
        {
            Num_Levels = 0;
            Angle_Start = -0.39;
            Angle_Extent = 0.79;
            Angle_Step = 0;
            Scale_Min = 0.9;
            Scale_Max = 1.1;
            Scale_Step = 0;
            //Optimization = "auto";
            Metric = "use_polarity";
            Min_Contrast = 0;
            Origin_Col = 0.0;
            Origin_Row = 0.0;
        }
        public TShape_Model_Param()
        {
            Set_Default();
        }
        public override TBase_Class New_Class()
        {
            return new TShape_Model_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TShape_Model_Param && dis_base is TShape_Model_Param)
            {
                TShape_Model_Param sor = (TShape_Model_Param)sor_base;
                TShape_Model_Param dis = (TShape_Model_Param)dis_base;
                dis.Num_Levels = sor.Num_Levels;
                dis.Angle_Start = sor.Angle_Start;
                dis.Angle_Extent = sor.Angle_Extent;
                dis.Angle_Step = sor.Angle_Step;
                dis.Scale_Min = sor.Scale_Min;
                dis.Scale_Max = sor.Scale_Max;
                dis.Scale_Step = sor.Scale_Step;
                //dis.Optimization = sor.Optimization;
                dis.Metric = sor.Metric;
                dis.Min_Contrast = sor.Min_Contrast;
                dis.Origin_Col = sor.Origin_Col;
                dis.Origin_Row = sor.Origin_Row;
            }
        }
    }
    abstract public class TBase_Param : TBase_Class, ITBase_Ini 
    {
        protected string  In_Default_Path;
        public string     Default_FileName,
                          FileName,
                          Info;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TBase_Param()
        {
            In_Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TBase_Param && dis_base is TBase_Param)
            {
                TBase_Param sor = (TBase_Param)sor_base;
                TBase_Param dis = (TBase_Param)dis_base;

                dis.In_Default_Path = sor.In_Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;
            }
        }
        abstract public TBase_Result New_Base_Result();
 
        virtual public void Set_Default()
        {
            In_Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = In_Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                Read(ini, section);
                Read_Other_File();
            };
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            if (filename == "") filename = In_Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Write(ini, section);
            ini.Save_File();
            Write_Other_File();
            return result;
        }
        virtual public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                FileName = ini.ReadString(section, "FileName", "");
                Info = ini.ReadString(section, "Info", "");
            }
        }
        virtual public void Write(TJJS_XML_File ini, string section)
        {
            ini.WriteString(section, "FileName", FileName);
            ini.WriteString(section, "Info", Info);
        }
        virtual public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        abstract public void Read_Other_File();
        abstract public void Write_Other_File();
        abstract public bool Set_Param(HImage image);
        abstract public bool Find_Base(HImage image, ref TBase_Result f_result);
    }
    abstract public class TBase_Result : TBase_Class, ITBase_Ini
    {
        private string   In_Default_Path;
        public string    Default_FileName,
                         FileName,
                         Info;
        public bool      Reflash;

        public bool      Find_OK;
        //public double    Col,
        //                 Row;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TBase_Result()
        {
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TBase_Result && dis_base is TBase_Result)
            {
                TBase_Result sor = (TBase_Result)sor_base;
                TBase_Result dis = (TBase_Result)dis_base;

                dis.In_Default_Path = sor.In_Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;
                dis.Find_OK = sor.Find_OK;

                //dis.Msg_Name = sor.Msg_Name;
                //dis.Msg_Scale = sor.Msg_Scale;
                //dis.Msg_X = sor.Msg_X;
                //dis.Msg_Y = sor.Msg_Y;
                //dis.Msg_Font_Size = sor.Msg_Font_Size;
                //dis.Msg = sor.Msg;
                //dis.Msg_Color_OK = sor.Msg_Color_OK;
                //dis.Msg_Color_NG = sor.Msg_Color_NG;
                //dis.Model_Color_OK = sor.Model_Color_OK;
                //dis.Model_Color_NG = sor.Model_Color_NG;
                //dis.Col = sor.Col;
                //dis.Row = sor.Row;
            }
        }

        abstract public void Reset();
        virtual public void Set_Default()
        {
            //Msg_Name = "";
            //Msg_Scale = 1.0;
            //Msg_X = 10.0;
            //Msg_Y = 60.0;
            //Msg_Font_Size = 14.0;
            //Msg_Color_OK = "green";
            //Msg_Color_NG = "red";

            //Model_Color_OK = "green";
            //Model_Color_NG = "red";
            //Hairline_Size = 30;
            //Line_Width = 2;
            Reflash = false;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = In_Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                Read(ini, section);
                //ini.UpdateFile();
            };
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            if (filename == "") filename = In_Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Write(ini, section);
            ini.Save_File();

            return result;
        }
        virtual public void Read(TJJS_XML_File ini, string section)
        {
            //Msg_Name = ini.ReadString(section, "Msg_Name", "");

            //Msg_Scale = ini.ReadFloat(section, "Msg_Scale", 1.0);
            //Msg_X = ini.ReadFloat(section, "Msg_X", 10.0);
            //Msg_Y = ini.ReadFloat(section, "Msg_Y", 60.0);
            //Msg_Font_Size = ini.ReadFloat(section, "Msg_Font_Size", 14.0);

            //Msg_Color_OK = ini.ReadString(section, "Msg_Color_OK", "green");
            //Msg_Color_NG = ini.ReadString(section, "Msg_Color_NG", "red");
            //Model_Color_OK = ini.ReadString(section, "Model_Color_OK", "green");
            //Model_Color_NG = ini.ReadString(section, "Model_Color_NG", "red");
        }
        virtual public void Write(TJJS_XML_File ini, string section)
        {
            //Msg_Name = ini.ReadString(section, "Msg_Name", "");

            //ini.WriteFloat(section, "Msg_Scale", Msg_Scale);
            //ini.WriteFloat(section, "Msg_X", Msg_X);
            //ini.WriteFloat(section, "Msg_Y", Msg_Y);
            //ini.WriteFloat(section, "Msg_Font_Size", Msg_Font_Size);

            //ini.WriteString(section, "Msg_Color_OK", Msg_Color_OK);
            //ini.WriteString(section, "Msg_Color_NG", Msg_Color_NG);
            //ini.WriteString(section, "Model_Color_OK", Model_Color_OK);
            //ini.WriteString(section, "Model_Color_NG", Model_Color_NG);
        }
        virtual public void Read_Other_File()
        {
            
        }
        virtual public void Write_Other_File()
        {

        }
        virtual public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
       
        public void Display(HWindowControl hw)
        {
            Display_Message(hw);
            Display_Model(hw);
        }
        abstract public void Display_Message(HWindowControl hw);
        abstract public void Display_Model(HWindowControl hw);
        abstract public string Get_Message();
    }
    public class TBase_Disp_Param : TBase_Class
    {
        public string    Msg_Name = "";
        public double    Msg_X = 50;
        public double    Msg_Y= 50;
        public double    Msg_Font_Size= 20;
        public string    Msg_Color_OK = emSetColor.green;
        public string    Msg_Color_NG = emSetColor.red;

        public string    Model_Color_OK = emSetColor.green;
        public string    Model_Color_NG = emSetColor.red;
        public string    Model_Set_Draw = emSetDraw.margin;

        public double    Hairline_Size = 30;
        public double    Line_Width = 2;
        public double    Scale = 1;

        public TBase_Disp_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TBase_Disp_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TBase_Disp_Param && dis_base is TBase_Disp_Param)
            {
                TBase_Disp_Param sor = (TBase_Disp_Param)sor_base;
                TBase_Disp_Param dis = (TBase_Disp_Param)dis_base;

                dis.Msg_Name = sor.Msg_Name;
                dis.Msg_X = sor.Msg_X;
                dis.Msg_Y = sor.Msg_Y;
                dis.Msg_Font_Size = sor.Msg_Font_Size;
                dis.Msg_Color_OK = sor.Msg_Color_OK;
                dis.Msg_Color_NG = sor.Msg_Color_NG;
                dis.Model_Color_OK = sor.Model_Color_OK;
                dis.Model_Color_NG = sor.Model_Color_NG;
                dis.Model_Set_Draw = sor.Model_Set_Draw;

                dis.Hairline_Size = sor.Hairline_Size;
                dis.Line_Width = sor.Line_Width;
                dis.Scale = sor.Scale;
            }
        }
        virtual public void Set_Default()
        {
            Msg_Name = "";
            Msg_X = 10.0;
            Msg_Y = 60.0;
            Msg_Font_Size = 14.0;
            Msg_Color_OK = "green";
            Msg_Color_NG = "red";

            Model_Color_OK = "green";
            Model_Color_NG = "red";
            Model_Set_Draw = emSetDraw.margin;

            Hairline_Size = 30;
            Line_Width = 2;
            Scale = 1;
        }
        virtual public void Read(TJJS_XML_File ini, string section)
        {
            Msg_Name = ini.ReadString(section, "Msg_Name", Msg_Name);
            Msg_X = ini.ReadFloat(section, "Msg_X", Msg_X);
            Msg_Y = ini.ReadFloat(section, "Msg_Y", Msg_Y);
            Msg_Font_Size = ini.ReadFloat(section, "Msg_Font_Size", Msg_Font_Size);
            Msg_Color_OK = ini.ReadString(section, "Msg_Color_OK", Msg_Color_OK);
            Msg_Color_NG = ini.ReadString(section, "Msg_Color_NG", Msg_Color_NG);

            Model_Color_OK = ini.ReadString(section, "Model_Color_OK", Model_Color_OK);
            Model_Color_NG = ini.ReadString(section, "Model_Color_NG", Model_Color_NG);

            Hairline_Size = ini.ReadFloat(section, "Hairline_Size", Hairline_Size);
            Line_Width = ini.ReadFloat(section, "Line_Width", Line_Width);
            Scale = ini.ReadFloat(section, "Scale", Scale); 
        }
        virtual public void Write(TJJS_XML_File ini, string section)
        {
            ini.WriteString(section, "Msg_Name", Msg_Name);
            ini.WriteFloat(section, "Msg_X", Msg_X);
            ini.WriteFloat(section, "Msg_Y", Msg_Y);
            ini.WriteFloat(section, "Msg_Font_Size", Msg_Font_Size);
            ini.WriteString(section, "Msg_Color_OK", Msg_Color_OK);
            ini.WriteString(section, "Msg_Color_NG", Msg_Color_NG);

            ini.WriteString(section, "Model_Color_OK", Model_Color_OK);
            ini.WriteString(section, "Model_Color_NG", Model_Color_NG);

            ini.WriteFloat(section, "Hairline_Size", Hairline_Size);
            ini.WriteFloat(section, "Line_Width", Line_Width);
            ini.WriteFloat(section, "Scale", Scale);
        }
        public void Set_Scale(double image_width, double hw_width)
        {
            Scale = image_width / hw_width;
        }
    }
    public class THalcon_System_Param
    {
        public HWindowControl HW = null;

        private int inColored = 12;

        public THalcon_System_Param()
        {

        }
        public THalcon_System_Param(HWindowControl hw)
        {
            HW = hw;
        }
        public int Line_Width
        {
            get
            {
                if (HW != null)
                {
                    return HW.HalconWindow.GetLineWidth();
                }
                else
                    return 0;
            }
            set
            {
                if (HW != null)
                {
                    HW.HalconWindow.SetLineWidth(value);
                }
            }
        }
        public string Draw
        {
            get
            {
                if (HW != null)
                {
                    return HW.HalconWindow.GetDraw();
                }
                else
                    return "fill";
            }
            set
            {
                if (HW != null)
                {
                    HW.HalconWindow.SetDraw(value);
                }
            }
        }
        public int Colored
        {
            get
            {
                return inColored;
            }
            set
            {
                if (HW != null)
                {
                    inColored = value;
                    HW.HalconWindow.SetColored(value);
                }
            }
        }
        public bool Edit_Param()
        {
            bool result = false;
           
            TForm_Halcon_System form = new TForm_Halcon_System();
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Line_Width = form.Line_Width;
                Colored = form.Colored;
                Draw = form.Draw;
                result = true;
            }
            return result;
        }
        public void Set_Line_Width(double disp_w, double old_w, double old_line_width = 1.0)
        {
            int line_w = 1;
            double tmp_w = old_line_width * old_w / disp_w;
            if (tmp_w > 1) line_w = (int)Math.Round(tmp_w, 0);
            Line_Width = line_w;
        }
    }

    //------------------------------------------------------------------------------------------------------
    //- THImage_RGB
    //------------------------------------------------------------------------------------------------------
    abstract public class HImage_Tool
    {
        static public THImage_RGB Get_Image_RGB(HImage in_image)
        {
            THImage_RGB result = new THImage_RGB();
            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                result.R = in_image.Decompose3(out result.G, out result.B);
            }
            return result;
        }
        static public THImage_HSV Get_Image_HSV(HImage in_image)
        {
            THImage_HSV result = new THImage_HSV();
            THImage_RGB image_rgb = null;

            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                image_rgb = Get_Image_RGB(in_image);
                result = image_rgb.Get_Image_HSV();
                image_rgb.Dispose();
            }
            return result;
        }
        static public void Get_Image_RGB_HSV(HImage in_image, ref THImage_RGB image_rgb, ref THImage_HSV image_hsv)
        {
            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                image_rgb = Get_Image_RGB(in_image);
                image_hsv = image_rgb.Get_Image_HSV();
            }
        }

        static public THImage_RGB AddImage_RGB(THImage_RGB image1, THImage_RGB image2, double mult, double add)
        {
            THImage_RGB result = new THImage_RGB();

            if (image1.Is_Not_Empty() && image2.Is_Not_Empty())
            {
                result.R = image1.R.AddImage(image2.R, mult, add);
                result.G = image1.G.AddImage(image2.G, mult, add);
                result.B = image1.B.AddImage(image2.B, mult, add);
            }
            return result;
        }
        static public THImage_HSV AddImage_HSV(THImage_HSV image1, THImage_HSV image2, double mult, double add)
        {
            THImage_HSV result = new THImage_HSV();

            if (image1 != null && image2 != null && image1.Is_Not_Empty() && image2.Is_Not_Empty())
            {
                result.H = image1.H.AddImage(image2.H, mult, add);
                result.S = image1.S.AddImage(image2.S, mult, add);
                result.V = image1.V.AddImage(image2.V, mult, add);
            }
            return result;
        }

        static public THImage_RGB SubImage_RGB(THImage_RGB image1, THImage_RGB image2, double mult, double add)
        {
            THImage_RGB result = new THImage_RGB();

            if (image1.Is_Not_Empty() && image2.Is_Not_Empty())
            {
                result.R = image1.R.SubImage(image2.R, mult, add);
                result.G = image1.G.SubImage(image2.G, mult, add);
                result.B = image1.B.SubImage(image2.B, mult, add);
            }
            return result;
        }
        static public THImage_HSV SubImage_HSV(THImage_HSV image1, THImage_HSV image2, double mult, double add)
        {
            THImage_HSV result = new THImage_HSV();

            if (image1.Is_Not_Empty() && image2.Is_Not_Empty())
            {
                result.H = image1.H.SubImage(image2.H, mult, add);
                result.S = image1.S.SubImage(image2.S, mult, add);
                result.V = image1.V.SubImage(image2.V, mult, add);
            }
            return result;
        }


        static public HImage Tile_Images(HImage[] image_list, int num_col, string tileOrder)
        {
            HImage result = new HImage();
            HImage tmp_image = new HImage();

            tmp_image.GenEmptyObj();
            for (int i = 0; i < image_list.Length; i++)
            {
                tmp_image = tmp_image.ConcatObj(image_list[i]);
            }
            result = tmp_image.TileImages(num_col, tileOrder);
            return result;
        }
        static public HRegion Tile_Regions(HRegion region_list, int num_x, int num_y, double image_size_x, double image_size_y, string tileOrder)
        {
            HRegion result = new HRegion();
            HRegion tmp_region = null;
            double dis_col = 0, dis_row = 0;
            int no_x = 0, no_y = 0;

            if (JJS_Vision.Is_Not_Empty(region_list))
            {
                int count = region_list.CountObj();

                result.GenEmptyRegion();
                for (int i = 0; i < count; i++)
                {
                    switch (tileOrder)
                    {
                        case "horizontal":
                            no_x = i % num_x;
                            no_y = i / num_x;
                            break;

                        case "vertical":
                            no_x = i / num_x;
                            no_y = i % num_x;
                            break;
                    }

                    tmp_region = region_list.CopyObj(i + 1, 1);
                    dis_col = no_x * image_size_x;
                    dis_row = no_y * image_size_y;
                    tmp_region = JJS_Vision.Affine_Trans_Region(tmp_region, dis_col, dis_row, 0, 0, 0, 0);
                    result = result.Union2(tmp_region);
                }
                result.Union1();
                result = result.DilationCircle(1.0);
                result = result.ErosionCircle(1.0);
            }
            return result;
        }
        static public THImage_HSV Region_To_Bin(HRegion in_region, TGray_HSV fore, TGray_HSV back, int width, int height)
        {
            THImage_HSV result = new THImage_HSV();

            result.H = in_region.RegionToBin(fore.H, back.H, width, height);
            result.S = in_region.RegionToBin(fore.S, back.S, width, height);
            result.V = in_region.RegionToBin(fore.V, back.V, width, height);
            return result;
        }
    }


    //------------------------------------------------------------------------------------------------------
    //- THImage_RGB
    //------------------------------------------------------------------------------------------------------
    public class THImage_RGB : TBase_Class
    {
        public HImage R = new HImage();
        public HImage G = new HImage();
        public HImage B = new HImage();

        public THImage_RGB()
        {
        }
        override public TBase_Class New_Class()
        {
            return new THImage_RGB();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is THImage_RGB && dis_base is THImage_RGB)
            {
                THImage_RGB sor = (THImage_RGB)sor_base;
                THImage_RGB dis = (THImage_RGB)dis_base;

                JJS_Vision.Copy_Obj(sor.R, ref dis.R);
                JJS_Vision.Copy_Obj(sor.G, ref dis.G);
                JJS_Vision.Copy_Obj(sor.B, ref dis.B);
            }
        }
        public void Dispose()
        {
            if (R != null) R.Dispose();
            if (G != null) G.Dispose();
            if (B != null) B.Dispose();
        }

        
        public HImage Get_Image()
        {
            HImage result = null;

            if (JJS_Vision.Is_Not_Empty(R) && JJS_Vision.Is_Not_Empty(G) && JJS_Vision.Is_Not_Empty(B))
            {
                result = R.Compose3(G, B);
            }
            return result;
        }
        public THImage_HSV Get_Image_HSV()
        {
            THImage_HSV result = new THImage_HSV();

            if (Is_Not_Empty())
            {
                result.H = R.TransFromRgb(G, B, out result.S, out result.V, "hsv");
                return result;
            }
            return result;
        }
        public void Set_Image(HImage image)
        {
            if (JJS_Vision.Is_Not_Empty(image))
            {
                R = image.Decompose3( out G, out B);
            }
        }
        public void Set_Image(THImage_HSV image_hsv)
        {
            if (image_hsv != null && image_hsv.Is_Not_Empty())
            {
                R = image_hsv.H.TransToRgb(image_hsv.S, image_hsv.V, out G, out B, "hsv");
            }
        }
        public bool Is_Empty()
        {
            return !Is_Not_Empty();
        }
        public bool Is_Not_Empty()
        {
            bool result = false;

            if (JJS_Vision.Is_Not_Empty(R) && JJS_Vision.Is_Not_Empty(G) && JJS_Vision.Is_Not_Empty(B)) result = true;
            return result;
        }
    }

    //------------------------------------------------------------------------------------------------------
    //- THImage_HSV
    //------------------------------------------------------------------------------------------------------
    public class THImage_HSV : TBase_Class
    {
        public HImage H = new HImage();
        public HImage S = new HImage();
        public HImage V = new HImage();

        public THImage_HSV()
        {
        }
        override public TBase_Class New_Class()
        {
            return new THImage_RGB();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is THImage_HSV && dis_base is THImage_HSV)
            {
                THImage_HSV sor = (THImage_HSV)sor_base;
                THImage_HSV dis = (THImage_HSV)dis_base;

                JJS_Vision.Copy_Obj(sor.H, ref dis.H);
                JJS_Vision.Copy_Obj(sor.S, ref dis.S);
                JJS_Vision.Copy_Obj(sor.V, ref dis.V);
            }
        }
        public void Dispose()
        {
            if (H != null) H.Dispose();
            if (S != null) S.Dispose();
            if (V != null) V.Dispose();
        }
        
        
        public HImage Get_Image()
        {
            HImage result = null;

            if (Is_Not_Empty())
            {
                THImage_RGB image_rgb = Get_Image_RGB();
                result = image_rgb.Get_Image();
            }
            return result;
        }
        public THImage_RGB Get_Image_RGB()
        {
            THImage_RGB result = null;

            if (Is_Not_Empty())
            {
                result = new THImage_RGB();
                result.R = H.TransToRgb(S, V, out result.G, out result.B, "hsv");
                return result;
            }
            return result;
        }
        public void Set_Image(HImage image)
        {
            Set_Image(HImage_Tool.Get_Image_RGB(image));
        }
        public void Set_Image(THImage_RGB image_rgb)
        {
            if (image_rgb != null && image_rgb.Is_Not_Empty())
            {
                H = image_rgb.R.TransFromRgb(image_rgb.G, image_rgb.B, out S, out V, "hsv");
            }
        }
        public bool Is_Empty()
        {
            return !Is_Not_Empty();
        }
        public bool Is_Not_Empty()
        {
            bool result = false;

            if (JJS_Vision.Is_Not_Empty(H) && JJS_Vision.Is_Not_Empty(S) && JJS_Vision.Is_Not_Empty(V)) result = true;
            return result;
        }
    }

    //------------------------------------------------------------------------------------------------------
    //- TRecipe_HSV
    //------------------------------------------------------------------------------------------------------
    public class TGray_HSV : TBase_Class
    {
        public int H;
        public int S;
        public int V;


        public TGray_HSV()
        {
            Set_Default();
        }
        public TGray_HSV(int h, int s, int v)
        {
            H = h;
            S = s;
            V = v;
        }
        override public TBase_Class New_Class()
        {
            return new TGray_HSV();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TGray_HSV && dis_base is TGray_HSV)
            {
                TGray_HSV sor = (TGray_HSV)sor_base;
                TGray_HSV dis = (TGray_HSV)dis_base;

                dis.H = sor.H;
                dis.S = sor.S;
                dis.V = sor.V;
            }
        }
        public void Dispose()
        {

        }
        public static TGray_HSV operator +(TGray_HSV sor, TGray_HSV in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H + in_value.H;
            result.S = sor.S + in_value.S;
            result.V = sor.V + in_value.V;
            return result;
        }
        public static TGray_HSV operator +(TGray_HSV sor, int in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H + in_value;
            result.S = sor.S + in_value;
            result.V = sor.V + in_value;
            return result;
        }
        public static TGray_HSV operator -(TGray_HSV sor, TGray_HSV in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H - in_value.H;
            result.S = sor.S - in_value.S;
            result.V = sor.V - in_value.V;
            return result;
        }
        public static TGray_HSV operator -(TGray_HSV sor, int in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H - in_value;
            result.S = sor.S - in_value;
            result.V = sor.V - in_value;
            return result;
        }
        public static TGray_HSV operator *(TGray_HSV sor, int in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H * in_value;
            result.S = sor.S * in_value;
            result.V = sor.V * in_value;
            return result;
        }
        public static TGray_HSV operator /(TGray_HSV sor, int in_value)
        {
            TGray_HSV result = new TGray_HSV();
            result.H = sor.H / in_value;
            result.S = sor.S / in_value;
            result.V = sor.V / in_value;
            return result;
        }



        public void Set_Default()
        {
            H = 0;
            S = 0;
            V = 0;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                H = ini.ReadInteger(section, "H", H);
                S = ini.ReadInteger(section, "S", S);
                V = ini.ReadInteger(section, "V", V);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "H", H);
                ini.WriteInteger(section, "S", S);
                ini.WriteInteger(section, "V", V);
            }
            return true;
        }
    }


}
