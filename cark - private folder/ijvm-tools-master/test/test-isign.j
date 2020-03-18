.method main
.args 2
.define v = 1


	bipush 1
	bipush 2
	iadd
	iload v
	isign
	bipush 1
	iadd
	iload v
	isign
	ireturn
