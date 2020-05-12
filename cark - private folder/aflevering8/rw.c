#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <semaphore.h>
#include <unistd.h>


int B = 0;
sem_t readers;
pthread_mutex_t lock;

void rw_read(int id){
	printf("Reader %i is active.\n", id);
	pthread_mutex_lock(&lock);
	sem_post(&readers);
	pthread_mutex_unlock(&lock);
	printf("Reader %i is reading %i.\n",id,B);	
	sem_wait(&readers);
	printf("Reader %i is finished.\n", id);
}

void rw_write(int id){
	pthread_mutex_lock(&lock);
	int semVal;
	while(sem_getvalue(&readers, &semVal) != 0 || semVal != 0){}// Readers can finish what they are currently doing.
	printf("Writer %i is changing B from %i", id, B);
	B++;
	printf(" to %i.\n", B);
	pthread_mutex_unlock(&lock);
}

void* readerFunc(void* arg){
	while(true){
		rw_read(*((int*)arg));
	//	usleep(1);
	}
}

void* writerFunc(void* arg){
	while(true){
		rw_write(*((int*) arg));
	//	sleep(1);
	}
}

void main(int argc, void** args){	
	int r = atoi(args[1]);
	int w = atoi(args[2]);
	pthread_mutex_init(&lock, NULL); // Initialize lock
	sem_init(&readers, 0, 0);
	pthread_t* r_threads = malloc(r*sizeof(pthread_t));
	pthread_t* w_threads = malloc(w*sizeof(pthread_t));
	int* r_ids = malloc(r*sizeof(pthread_t));
	int* w_ids = malloc(w*sizeof(pthread_t));
	
	for(int i = 0;i <r; i++){
		r_ids[i] = i;
		pthread_create(&r_threads[i], NULL, readerFunc, &r_ids[i]);
	}
	for(int j=0; j <w; j++){
		w_ids[j] = j;
		pthread_create(&w_threads[j], NULL, writerFunc, &w_ids[j]);		
	}

	for(int i=0; i<r; i++){
		pthread_join(r_threads[i], NULL);
	}

	for(int j=0; j<w; j++){
		pthread_join(w_threads[j], NULL);
	}
	
}


