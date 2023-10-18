using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Vision.Halcon
{
    public static class emSetDraw
    {
        public static string margin = "margin";
        public static string fill = "fill";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "margin",
                "fill"
            };
        }
    }
    public static class emSetColor
    {
        public static string black = "black";
        public static string white = "white";
        public static string red = "red";
        public static string green = "green";
        public static string blue = "blue";
        public static string dim_gray = "dim gray";
        public static string gray = "gray";
        public static string light_gray = "light gray";
        public static string cyan = "cyan";
        public static string magenta = "magenta";
        public static string yellow = "yellow";
        public static string medium_slate_blue = "medium slate blue";
        public static string coral = "coral";
        public static string slate_blue = "slate blue";
        public static string spring_green = "spring green";
        public static string orange_red = "orange red";
        public static string orange = "orange";
        public static string dark_olive_green = "dark olive green";
        public static string pink = "pink";
        public static string cadet_blue = "cadet blue";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "black",
                "white",
                "red",
                "green",
                "blue",
                "dim gray",
                "gray",
                "light gray",
                "cyan",
                "magenta",
                "yellow",
                "medium slate blue",
                "coral",
                "slate blue",
                "spring green",
                "orange red",
                "orange",
                "dark olive green",
                "pink",
                "cadet blue",
            };
        }
    }
    public static class emMeasure_Transition
    {
        public static string positive = "positive";
        public static string negative = "negative";
        public static string all = "all";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "positive",
                "negative",
                "all"
            };
        }
    };
    public static class emMeasure_Select
    {
        public static string first = "first";
        public static string last = "last";
        public static string all = "all";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "first",
                "last",
                "all"
            };
        }
    };
    public static class emMeasure_Interpolation
    {
        public static string nearest_neighbor = "nearest_neighbor";
        public static string bilinear = "bilinear";
        public static string bicubic = "bicubic";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "nearest_neighbor",
                "bilinear",
                "bicubic"
            };
        }
    };
    public static class emSelect_Shape_Features
    {
        public static string area = "area";
        public static string row = "row";
        public static string column = "column";
        public static string width = "width";
        public static string height = "height";
        public static string row1 = "row1";
        public static string column1 = "column1";
        public static string row2 = "row2";
        public static string column2 = "column2";
        public static string circularity = "circularity";
        public static string compactness = "compactness";
        public static string contlength = "contlength";
        public static string convexity = "convexity";
        public static string rectangularity = "rectangularity";
        public static string ra = "ra";
        public static string rb = "rb";
        public static string phi = "phi";
        public static string anisometry = "anisometry";
        public static string bulkiness = "bulkiness";
        public static string struct_factor = "struct_factor";
        public static string outer_radius = "outer_radius";
        public static string inner_radius = "inner_radius";
        public static string inner_width = "inner_width";
        public static string inner_height = "inner_height";
        public static string dist_mean = "dist_mean";
        public static string dist_deviation = "dist_deviation";
        public static string roundness = "roundness";
        public static string num_sides = "num_sides";
        public static string connect_num = "connect_num";
        public static string holes_num = "holes_num";
        public static string area_holes = "area_holes";
        public static string max_diameter = "max_diameter";
        public static string orientation = "orientation";
        public static string euler_number = "euler_number";
        public static string rect2_phi = "rect2_phi";
        public static string rect2_len1 = "rect2_len1";
        public static string rect2_len2 = "rect2_len2";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "area",
                "row",
                "column",
                "width",
                "height",
                "row1",
                "column1",
                "row2",
                "column2",
                "circularity",
                "compactness",
                "contlength",
                "convexity",
                "rectangularity",
                "ra",
                "rb",
                "phi",
                "anisometry",
                "bulkiness",
                "struct_factor",
                "outer_radius",
                "inner_radius",
                "inner_width",
                "inner_height",
                "dist_mean",
                "dist_deviation",
                "roundness",
                "num_sides",
                "connect_num",
                "holes_num",
                "area_holes",
                "max_diameter",
                "orientation",
                "euler_number",
                "rect2_phi",
                "rect2_len1",
                "rect2_len2"
            };
        }
    };
    public static class emSelect_Shape_Operation
    {
        public static string and = "and";
        public static string or = "or";
        public static string[] Get_List()
        {
            return new string[] 
            {
                "and",
                "or"
            };
        }
    }
}
