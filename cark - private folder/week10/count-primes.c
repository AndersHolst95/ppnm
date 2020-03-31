#include <pthread.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdio.h>
#include <stdbool.h>
#include "mymutex.h"
#define MAX 100000

bool isPrime(long n){
	long test=2;
	while (test*test <= n) {
		if (n%test == 0) return false;
		test++;
		}
	return true;
}

int totalprimes=0;
int primesfound1=0, primesfound2=0;
pthread_mutex_t lock;

int countPrimes(long start, long end){
	long i =0;
	int result=0;
	for (i=start ; i<end ; i++){
		if (isPrime(i)) {
			lock_my_mutex(&lock);
			totalprimes++;
			unlock_my_mutex(&lock);
			result++;
		}
	}
	return result;
}

void * thread_function(void *arg){
	int id = * ((int *)arg);
	printf("id: %d \n",id);
	if (id == 0){
		primesfound1=countPrimes(2,MAX/2);
	} 
	else {
		primesfound2=countPrimes(MAX/2,MAX);
	}
}

long main(int argc, void **args){
	init_my_mutex(&lock);
	pthread_t thread1, thread2;
	int id1 = 0, id2=1;
	pthread_create(&thread1, NULL, thread_function, &id1);
	pthread_create(&thread2, NULL, thread_function, &id2);
	pthread_join(thread1, NULL);pthread_join(thread2, NULL);
	pthread_mutex_destroy(&lock);
	printf("Count complete, %d total primes found.\n", totalprimes);
	printf("Thread 1 found %d prime.\n", primesfound1);
	printf("Thread 2 found %d prime.\n", primesfound2);
}
