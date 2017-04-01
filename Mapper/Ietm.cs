using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public static class Ietm
    {
        public static string TransLat(string src)
        {
            string str = src;
            str = str.Replace("А", "A");
            str = str.Replace("Б", "B");
            str = str.Replace("В", "V");
            str = str.Replace("Г", "G");
            str = str.Replace("Д", "D");
            str = str.Replace("Е", "E");
            str = str.Replace("Ж", "ZH");
            str = str.Replace("З", "Z");
            str = str.Replace("И", "I");
            str = str.Replace("К", "K");
            str = str.Replace("Л", "L");
            str = str.Replace("М", "M");
            str = str.Replace("Н", "N");
            str = str.Replace("О", "O");
            str = str.Replace("П", "P");
            str = str.Replace("Р", "R");
            str = str.Replace("С", "S");
            str = str.Replace("Т", "T");
            str = str.Replace("С", "C");
            str = str.Replace("Ф", "F");
            str = str.Replace("У", "U");
            str = str.Replace("Ю", "JU");
            str = str.Replace("Я", "JA");
            return str;
        }
        public static string TransRu(string src)
        {
            string str = src;
            str = str.Replace("A", "А");
            str = str.Replace("B", "Б");
            str = str.Replace("V", "В");
            str = str.Replace("G", "Г");
            str = str.Replace("D", "Д");
            str = str.Replace("E", "Е");
            str = str.Replace("ZH", "Ж");
            str = str.Replace("Z", "З");
            str = str.Replace("I", "И");
            str = str.Replace("K", "К");
            str = str.Replace("L", "Л");
            str = str.Replace("M", "М");
            str = str.Replace("N", "Н");
            str = str.Replace("O", "О");
            str = str.Replace("P", "П");
            str = str.Replace("R", "Р");
            str = str.Replace("S", "С");
            str = str.Replace("T", "Т");
            str = str.Replace("C", "С");
            str = str.Replace("F", "Ф");
            str = str.Replace("U", "У");
            str = str.Replace("JU", "Ю");
            str = str.Replace("JA", "Я");
            return str;
        }
    }
}
