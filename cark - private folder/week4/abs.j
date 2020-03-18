.method main
.args 3

.define a = 1
.define b = 2
	
	iload a 
	iload b
	iload a
	iload b
	iadd
	IFLT neg

	goto add

neg: 
	ldc_w 0
	iload a
	iload b
	iadd
	isub
	ireturn

add:
	iadd

	ireturn
