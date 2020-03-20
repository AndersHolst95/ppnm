/* fac.c */
#include <stdio.h>
#include <stdlib.h>

long long fac(long long a) { 
    long long r; 
    if (a == 0) { 
        r = 1; 
    } else { 
        r = a * 
            fac(a - 1); 
    } 
    return r; 
} 

int main (int argc, char * argv[]) {
    long long a = 0;
    long long r = 0;
    a = atoll(argv[1]);
    r = fac(a); 
    printf("fac(%llu) = %llu\n",a,r);
    return 0; 
}
