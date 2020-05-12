#include <stdio.h>

typedef struct test_st {
    long a;
    long b;
} test_t;

extern int my_cmpr_swap(test_t *old, test_t *cur, test_t *mod);

void main(){
    test_t t1,t2,t3;

    t1.a=10;
    t1.b=10;

    t2.a=10;
    t2.b=10;

    t3.a=100;
    t3.b=200;

    int result = my_cmpr_swap(&t1,&t2,&t3);

    printf("The function returned %d.\n",result);
    printf("t1 is: (%ld,%ld)\n", t1.a,t1.b);
    printf("t2 is: (%ld,%ld)\n", t2.a,t2.b);
    printf("t3 is: (%ld,%ld)\n", t3.a,t3.b);
}
