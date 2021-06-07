using System;

public class DataTypes
{
    //A few Value types (in the order of less to more memory)
    private bool _boolean = true;
    private byte _byte = 255; //From 0 to 255, 8-bit integers
    private sbyte _sbyte = -128; //From -128 to 127
    private short _short = 32767; //16-bit integer (add a u at the beginning to make it unsigned)
    private ushort _ushort = 65535; //Higher number but only from 0 to positive nums
    private char _char = 'A';//16-bit integer but holds a single character
    private int _nums = 2147483647;//32-bit integer
    private long _long = 9223372036854775807; //64-bit integer
    
    private double _decimals = 4.56; //Also 64-bit integer buuuut can hold a lot more decimal places (more accurate)
}