using System;

public static IEnumerable<Tuple<ulong,int>> CreateStream(int n, int l){
    //generating a random uint64 number
    Random rnd = new System.Random();
    ulong a = OUL;
    Byte [] b = new Byte[8];
    rnd.NextBytes(b);
    for(int i = 0; i < 8; ++i){
        a = (a << 8) + (ulong)b[i];
    }
}