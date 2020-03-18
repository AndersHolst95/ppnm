.method main
.args 4

.define a = 1
.define b = 2
.define c = 3
	
	bipush 111
	iload a
	invokevirtual abs
	istore a

	bipush 111
	iload b
	invokevirtual abs
	istore b

	bipush 111
	iload c
	invokevirtual abs
	istore c

	iload a
	iload b
	iload c

	iadd 
	iadd
	ireturn

.method abs
.args 2
.define x = 1

	iload x
	IFLT neg

	goto pos

neg:
	ldc_w 0
	iload x
	isub
	ireturn

pos:
	iload x
	ireturn
