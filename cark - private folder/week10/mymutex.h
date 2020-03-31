#ifndef __my_mutex_h
#define __mymutex_h

typedef long long my_mutex_t;

void init_my_mutex(my_mutex_t *mutex);

void lock_my_mutex(my_mutex_t *mutex);

void unlock_my_mutex(my_mutex_t *mutex);

#endif
