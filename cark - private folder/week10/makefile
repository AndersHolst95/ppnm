all: count-primes
	./count-primes 

count-primes: count-primes.c mymutex.o
	gcc -O2 -pthread count-primes.c mymutex.o -o count-primes 

mymutex.o: mymutex.c
	gcc -c mymutex.c -o mymutex.o
