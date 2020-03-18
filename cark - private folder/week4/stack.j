.method main
.args 3
.define a = 1
.define b = 2

	ldc_w 1234
	istore a
	iload a 
	dup
	pop
	iload b
	swap 

	ireturn
