using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;


namespace RandomizedAlgo{
    class Generation{
        public static IEnumerable<Tuple<ulong,int>> CreateStream(int n, int l){
            //generating a random uint64 number
            Random rnd = new System.Random();
            ulong a = 0UL;
            Byte [] b = new Byte[8];
            rnd.NextBytes(b);
            for(int i = 0; i < 8; ++i){
                a = (a << 8) + (ulong)b[i];
            }
            //we demand that our random number has 30 zeros on the least
            //sig bits and then a one
            a = (a | ((1UL << 31) - UL)) ^ ((1UL << 30)-UL);

            ulong x = 0UL;
            for (int i = 0; i < n/3; i++){
                x = x + a;
                yield return Tuple.Create(x & (((1UL << 1)-1UL) << 30),1);
            }
            for (int i = 0; i < (n + 1)/3; i++){
                yield return Tuple.Create(x & (((1UL << 1) - 1UL) << 30), -1);
            }
            for (int i = 0; i < (n+2)/3; i++){
                x = x + a;
                yield return Tuple.Create(x & (((1UL << 1)-1UL)<<30),1);
            }
        }
    }
}