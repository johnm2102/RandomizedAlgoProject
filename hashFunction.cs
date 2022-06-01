using System;
using System.Numerics;
/*
This goal of this program is to implement multiply shift and 
multiply-mod-hashing
*/
namespace RandomizedAlgo{
    public class HashFuncs{
        /*
        Implementing a multiply shift hashing which is parameterized of "a" 
        and "l", where "a" is a 64 bit integer, and 
        where "l" is positive number less than 64.
        More precisely, the hashfunction needs to be:
            h(x) = (a*x)>>(64-l),
            where a is an uneven 64 bit number 
        */
        public static Func<ulong, ulong> mulShift(ulong a, int l = 5){
            return new Func<ulong, ulong>(x => ((a * x) >> (64 - l)));
        }

        /*
        Implementing multiply-mod-prime hashing where p = 2^{89} - 1, and 
        is parameterized as a, b, l, where a and b are numbers less than
        p and where l is a positive number less than 64. More precisely:
            h(x) = ((a*x + b) mod p) mod 2^l
        where a and b are uniform
        Use of bigInt here allows 
        */
        public Func<ulong, ulong> mulModPrime(BigInteger a, BigInteger b, int l = 5, int s = 89){
            BigInteger p = ((BigInteger)1<<s)-1;
            BigInteger m = ((BigInteger)1<<l)-1;
            if (a < p && b < p && l < 64){
                return new Func<ulong, ulong>((((a*x)+b)& p)+(((a*x)+b)>>s));
            }else{
                throw new Exception("Does not work");
            }
        }
    }
}