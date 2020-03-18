.method main
.args 3
.define a = 1
.define b = 2
	iinc a, 1
	iload a
	iload b
	isub 
	ldc_w -3
	iand 
	ireturn
