#include <stdlib.h>
#include <stdio.h>

typedef struct item{
	int val;
	struct item *next;
	struct item *prev;
} item_t;



int main() {
	item_t* head = malloc(sizeof(item_t));
	item_t* tail = malloc(sizeof(item_t));
	item_t* item1 = malloc(sizeof(item_t));

	head -> prev = NULL;
	head -> next = item1;
	head -> val = 1;

	item1 -> prev = head;
	item1 -> next = tail;
	item1 -> val = 4;

	tail -> val = 2;
	tail -> prev = item1;
	tail -> next = NULL;


	int n = tail -> prev-> prev ->val; // Head's value
	printf("%i \n", n);

	n = head -> next -> val; // item1's value
	printf("%i \n", n);

	n = head -> next -> next -> val; // tail's value
	printf("%i \n", n);

}
